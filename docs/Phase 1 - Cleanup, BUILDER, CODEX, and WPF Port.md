# Phase 1 - Cleanup, BUILDER, CODEX, and WPF Port

**Date:** 2026-08-24

## ASCEND Track A cleanup

- Deleted `App.config`, `packages.config`, the `packages\` folder (10 dead .NET-Framework-era
  compatibility-shim packages, unreferenced via `PackageReference` and confirmed dead by a clean
  build without them), `Properties\AssemblyInfo.cs` (empty - just a BOM), and the unused
  `Properties\Settings.settings`/`Settings.Designer.cs` pair (zero actual settings defined,
  nothing in the codebase read `Properties.Settings.Default.*`).
- Deleted the stray `Teron Doom Launcher.csproj.user` (old name, untracked fossil referencing an
  even older `Launcher_Window.cs` filename and a since-renamed folder path).
- Migrated `TeronDoomLauncher.sln` to `TeronDoomLauncher.slnx` (`dotnet sln migrate`).

## BUILDER + CODEX

- Added `Directory.Build.props` (consolidated `Build\<Config>\<Project>\` output, matching
  `Teron_Raid_Manager`/`Teron_SQL_Database_Editor`).
- Replaced the hardcoded `<Version>1.9.0</Version>`/`<FileVersion>`/`<AssemblyVersion>` with
  `MajorMinorPatchVersion` (bumped to 2.0.0 - a major version bump for the WPF rewrite, matching
  the other two apps' precedent) + `BuildNumberFile` + the `IncrementBuildNumber` MSBuild target.
- Updated both publish profiles' `PublishDir` and `Installer\TeronDoomLauncher.iss`'s
  `MyPublishDir`/`OutputDir` from `bin\Publish\TeronDoomLauncher_Win_<arch>\` /
  `bin\InstallerPackage` to `Build\Publish\TeronDoomLauncher\win-<arch>\` /
  `Build\InstallerPackage`, and added `/Build/` to `.gitignore`.

## WinForms to WPF port (ASCEND Track C)

One window (`LauncherWindow`, 3 tabs: Profiles, Game Options, Launcher Options) plus several
code-only WinForms dialogs built entirely in C# (no designer) in `Logic.cs`:
`WAD_Options.EditWadEntry`/`EditModEntry`, `Engine_Options.Edit_Engine`, `Prompt.ShowDialog`.

### Control/API translation

Same core mechanical translations established on the first two ports (`Form`→`Window`,
`MessageBoxButtons`/`Icon`→`MessageBoxButton`/`Image`, native file dialogs move to
`Microsoft.Win32`), plus:

- **WinForms `CheckedListBox` (`mods_selection`) has no WPF equivalent** - replaced with a plain
  `ListBox` whose `ItemTemplate` renders a `CheckBox` per row, backed by a small
  `CheckableItem : INotifyPropertyChanged` wrapper (`Text` + `IsChecked`). Items are still added/
  cleared via the same `Items.Add`/`Items.Clear()` calls as before (a WPF `ListBox` used without
  `ItemsSource` still applies `ItemTemplate` to objects added directly to `Items`), so the load/
  clear call sites barely changed. `CheckedItems`/`SetItemChecked(i, bool)` became a
  `Where(m => m.IsChecked)` LINQ filter and direct `IsChecked` assignment respectively.
- **WinForms' `ItemCheck` (fires *before* the checked state commits, which is why the original
  deferred `SyncConfig()` via `BeginInvoke`) has no direct WPF equivalent** - not needed anyway,
  since WPF's `CheckBox.Checked`/`Unchecked` events fire *after* the bound `IsChecked` property
  has already committed. `SyncConfig()` is called directly from those events with no deferral.
- **`Screen.AllScreens` (used by `Window_Options` to check whether a saved window position is
  still on *some* monitor before restoring it) has no WPF equivalent without a WinForms
  reference** - approximated with the combined virtual-desktop bounds
  (`SystemParameters.VirtualScreenLeft/Top/Width/Height`) instead of a per-monitor loop. Slightly
  less precise for unusual multi-monitor gaps, but covers the actual failure mode (a saved
  position now entirely off any monitor) without pulling in `System.Windows.Forms` just for one
  settings check.
- **`Form.Bounds`/`.RestoreBounds`/`.WindowState` (WinForms)** → WPF `Window` has direct
  equivalents with the same names (`Left`/`Top`/`Width`/`Height`, `RestoreBounds`, `WindowState`),
  just typed `double`/`Rect` instead of `int`/`Rectangle` - cast to `int` when persisting to JSON.
- **Code-only dialogs** (`EditWadEntry`, `EditModEntry`, `Edit_Engine`, `Prompt.ShowDialog`) -
  the originals were built with absolute `Left`/`Top`/`Width` positioning directly in C#, no
  designer. Ported to WPF `Window`s built the same way, using a `Canvas` with
  `Canvas.SetLeft`/`SetTop` for a direct 1:1 translation of the original coordinates -
  `FormBorderStyle.FixedDialog`→`ResizeMode.NoResize`, `FormStartPosition.CenterParent`→
  `WindowStartupLocation.CenterOwner` + explicit `Owner` assignment, `DialogResult.OK` button
  pattern → a captured `bool accepted` flag set in the OK button's `Click` handler before
  `Close()`.
- **`profile_details_textbox` genuinely uses rich formatting** (bold headings, regular values) -
  unlike every `RichTextBox` in the SQL Database Editor port, this one was correctly kept as a
  real WPF `RichTextBox`. `SelectionFont = new Font(rtb.Font, FontStyle.Bold)` +
  `AppendText(...)` became building a `Paragraph` of `Run`/`Bold(Run(...))` inlines with
  `LineBreak()`s, added once to `Document.Blocks` per refresh.
- **`ListBox.MouseDoubleClick` (WinForms-only, does not exist on WPF `ListBox`)** - replaced with
  `PreviewMouseLeftButtonUp` + checking `e.ClickCount == 2` and walking up the visual tree for a
  `ListBoxItem` ancestor (equivalent to the original's `IndexFromPoint(e.Location) ==
  ListBox.NoMatches` check for "did this land on an actual row").

### Disclosed simplifications

- Dropped the WinForms `Form`-level `Click` handler (`LauncherWindow_Click` → `SyncConfig()`) -
  every actual data-changing control already triggers its own `SyncConfig()` call, so this looked
  like a redundant safety net rather than load-bearing behavior; no original comment explained a
  specific reason for it.
- Dropped `add_mod_button`/`remove_mod_button` (`Enabled = false; Visible = false` in the
  original - dead, unreachable controls) and the equally-dead `tableLayoutPanel1` Designer field
  that produced the one pre-existing compiler warning.
- Dropped several empty no-op label `Click` handlers (`label1_Click`/`label2_Click`/
  `profile_select_label_Click`/`mods_selection_label_Click`) rather than reproducing them -
  WPF `Label` doesn't even have a `Click` event, so reproducing these faithfully would have meant
  adding pointless `MouseLeftButtonUp` wiring for handlers that do nothing.

### Real bitmap resources moved off `Properties.Resources`

The four button icons (`45706.png` edit, `add-icon-2.png` add, `Red-Minus-Symbol-PNG-Image.png`
remove, `R.png` - disabled/unused) were embedded `System.Drawing.Bitmap` resources via
`Properties\Resources.resx`. Since nothing else in the app used that resx (confirmed by grep) and
the actual PNG source files already existed under `Resources\`, the whole resx/Designer.cs pair
was dropped in favor of referencing the loose PNGs directly
(`pack://siteoforigin:,,,/Resources/<file>.png`, matching the SQL Database Editor's DBC editor
toolbar icons) - added as `<Content Include="Resources\*.png" CopyToOutputDirectory=
"PreserveNewest" />` in the `.csproj`.

## Verification (TRIAL)

- Clean rebuild, both Debug and Release, 0 warnings / 0 errors, after a full `Build\`/`bin`/`obj`
  delete (the one pre-existing warning is gone, since the dead Designer field it came from no
  longer exists).
- Both `win-x64` and `win-x86` publish profiles succeed; both installers build correctly
  (`TeronDoomLauncherSetup-x64.exe`/`-x86.exe`), Resources PNGs included in the publish output.
- **This machine's RESIDENCY folder held real, substantial pre-existing user data** - a real
  WAD/mod/engine library (11 IWADs, 14 mods, 3 real GZDoom/UZDoom engine entries with real
  `G:\...` paths) and 9 real saved profiles, unlike the other two apps' folders (confirmed empty
  before their respective test passes). Per the updated [[testing-verification-procedure]]
  (TRIAL) step added this session, snapshotted all 5 config files
  (`launcher_config.json`/`engine_config.json`/`wad_config.json`/`mods_config.json`/
  `game_config.json`) to a scratch backup folder before the first live launch, and restored them
  afterward (the live pass did change `LastSelectedProfile` by selecting a different profile to
  verify the details view updates - restored to the original "Project Brutality DooM 1" value
  after testing).
- Live UI Automation pass (PID/AutomationId-scoped only, no synthetic input) confirmed, using the
  real data as an incidental extra layer of validation beyond what a fresh/empty config could
  have shown:
  - Main window opens with the correct title; both tab-lazy-realization false alarms already
    known from the SQL Database Editor port recurred here in new forms and were resolved the
    same way: `engine_selection`'s `ComboBox` showed 0 `ListItem` results until its dropdown
    `Popup` was actually expanded via `ExpandCollapsePattern.Expand()` (WPF `ComboBox` items live
    in a `Popup` not realized in the automation tree until opened) - after expanding, all 3 real
    engines were confirmed present and correctly labeled.
  - `wad_selection`/`mods_selection` correctly show all 11 real WADs / 14 real mods.
  - `profile_select` correctly shows all 9 real saved profiles; selecting a different profile
    (`Hexen`) correctly refreshed `profile_details_textbox`'s bold/regular formatted content to
    that profile's real saved settings, confirming both the `CheckableItem`/mods_selection
    translation and the `RichTextBox`/`Paragraph`/`Run` rich-formatting translation work
    end-to-end against real data.
  - Install/launch/uninstall cycle confirmed clean; the RESIDENCY config was re-verified
    untouched (still showing the restored `LastSelectedProfile`) after the brief installed-copy
    launch test.
- Not tested: an actual game launch (`PlayGame` → `Process.Start` on a real engine executable) -
  the configured engine paths (`G:\GZDooM...\gzdoom.exe`) may not exist on this exact machine/
  session, and actually launching a game process is out of scope for a UI-port verification pass.
  `GenerateExecutable`'s command-line-building logic is unchanged from the original either way.
