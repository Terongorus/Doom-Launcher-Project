# Phase 2 - Compliance Gap Remediation

**Date:** 2026-08-24

A follow-up compliance re-check of Phase 1 (the ASCEND cleanup + WPF port) found that the
naming convention pass (ARCHIVIST) was never actually run against the ported source - Phase 1
covered project-file identity (`TeronDoomLauncher.csproj`/`.slnx`, `RootNamespace`/`AssemblyName`)
but the internal class names carried over from the WinForms-era code untouched.

## Findings and fixes

- **Six classes in `Logic.cs` still used old-style underscored names**: `Window_Options`,
  `WAD_Options`, `Engine_Options`, `Mods_Options`, `Game_Options`, `Profile_Options`. Renamed to
  plain PascalCase (`WindowOptions`, `WADOptions`, `EngineOptions`, `ModsOptions`, `GameOptions`,
  `ProfileOptions`) across both files that reference them (`Logic.cs`, `LauncherWindow.xaml.cs`)
  - `WAD` is kept upper-case as an acronym (the Doom resource-file format), matching this
    developer's convention for initialisms. Verified exact occurrence counts matched between a
    whole-word grep and a plain grep before replacing, so no partial/unintended matches were
    touched.

## Not a bug, re-confirmed as already correct

The earlier audit pass flagged the main window's title bar as broken (stuck at the WPF designer
default `Title="Form1"`, no `AppInfo.cs`-style helper found). Re-checking the actual runtime
behavior: `LauncherWindow`'s constructor calls `GameOptions.ProductDetails(this)` right after
`InitializeComponent()`, and that method (in `Logic.cs`) already reads
`AssemblyProductAttribute`/`AssemblyInformationalVersionAttribute` live and sets `self.Title`
to `"<DisplayName> v<Version>"` - correctly overriding the static XAML default before the window
is ever shown. This is the same "fix a pre-existing WinForms-era method in place rather than
introduce a parallel helper class" pattern used on this app's own `ProductDetails`
method historically, carried through the WPF port correctly. Nothing needed changing here; the
earlier audit's grep for `AppInfo.cs`/`Title=` in the `.xaml.cs` file alone missed that the
assignment happens one call away, inside `Logic.cs`.

## Version

Bumped `2.0.0` -> `2.0.1` (hotfix - internal naming only, no user-facing behavior change), synced
across `TeronDoomLauncher.csproj`'s `MajorMinorPatchVersion` and
`Installer/TeronDoomLauncher.iss`'s `MyAppVersion` fallback.

## Verification

`dotnet build TeronDoomLauncher.csproj -c Debug` and a clean `-c Release` rebuild (deleting
`Build\` first) - both 0 warnings, 0 errors, confirming the rename didn't break any reference.
