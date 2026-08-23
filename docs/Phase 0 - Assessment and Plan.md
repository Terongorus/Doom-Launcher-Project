# Phase 0 - Assessment and Plan

**Date:** 2026-08-24

## Starting state

`Teron_Doom_Launcher` was the worst-compliant app remaining in the portfolio - last in the
confirmed worst-to-least-by-size WPF-port queue (`Teron_Raid_Manager` first,
`Teron_SQL_Database_Editor` second, this app third), and unlike those two, it had never had
*any* DOCTRINE pass at all before this one. Found needing work on multiple fronts at once:

- Already SDK-style and targeting `net10.0-windows`, but with dead .NET-Framework-era artifacts
  never cleaned up: `App.config` (net481 binding redirects), `packages.config` +
  a full local `packages\` NuGet cache (10 compatibility-shim packages like
  `System.Text.Json`/`System.Memory`/`System.ValueTuple` that modern .NET no longer needs and
  that weren't even referenced via `PackageReference` - confirmed dead by a clean build with
  them removed), an empty `Properties\AssemblyInfo.cs`, and an empty, unused
  `Properties\Settings.settings`/`Settings.Designer.cs` pair.
- A stray leftover `Teron Doom Launcher.csproj.user` (old name, with a space) sitting alongside
  the correctly-named `TeronDoomLauncher.csproj.user`, referencing an even older filename
  (`Launcher_Window.cs`) and a since-renamed folder path - a fossil from at least two renames
  ago. Never tracked in git (matches the generic `*.user` ignore rule), just disk clutter.
- Legacy `.sln` (not yet migrated to `.slnx`).
- No `Directory.Build.props` (BUILDER's `Build\` output convention) and no
  `BuildNumber.txt`/auto-increment target (CODEX) - publish/installer output still used the
  older `bin\Publish\TeronDoomLauncher_Win_<arch>\` naming this portfolio has since moved away
  from elsewhere.
- Still WinForms, needing the same portfolio-wide UI move to WPF as the other two apps (ASCEND
  Track C).

Confirmed via a clean build before touching anything that none of the dead artifacts above were
actually load-bearing (same 1 pre-existing warning either way - an unused
`tableLayoutPanel1` Designer field, which disappears entirely once the Designer-generated UI is
replaced by hand-written XAML).

## Plan

1. ASCEND Track A cleanup: delete `App.config`/`packages.config`/`packages\`/`AssemblyInfo.cs`/
   `Settings.settings`/`Settings.Designer.cs`/the stray `.csproj.user`; migrate `.sln` to
   `.slnx`.
2. BUILDER: add `Directory.Build.props` (consolidated `Build\` output, matching the other two
   apps); CODEX: add `BuildNumber.txt` + the version/build-number MSBuild target, replacing the
   old hardcoded `<Version>1.9.0</Version>` etc.
3. Update publish profiles and the `.iss` installer script to the `Build\...` output convention
   used elsewhere in the portfolio (was `bin\Publish\TeronDoomLauncher_Win_<arch>\`).
4. ASCEND Track C: inventory `LauncherWindow` (3 tabs: Profiles, Game Options, Launcher Options)
   and `Logic.cs` (config store, WAD binary-format lump scanner, all the `*_Options` classes)
   completely before writing any XAML, to port behavior faithfully.
5. Port to WPF: `LauncherWindow.xaml`/`.xaml.cs`, translate every WinForms control API site in
   `Logic.cs`, `Init.cs`.
6. TRIAL: build (both configurations), publish (both RIDs), install/launch/uninstall
   verification - with extra care here specifically, since this machine's RESIDENCY folder
   (`%LocalAppData%\TeronDoomLauncher\`) turned out to hold real, substantial pre-existing user
   data (a real WAD/mod/engine library and 9 real saved profiles) rather than being empty like
   the other two apps' folders were.
7. CHANGELOG/README updates, commit to `dev`.

Each step is logged in its own file in this folder as it's completed.
