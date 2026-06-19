# Working instructions

## Changelog

After making a notable code change (feature, fix, or refactor), append an entry
to the top of `CHANGELOG.md` describing it, under a version heading. Use the
existing section style (`### New Features` / `### Improvements` / `### Bug Fixes`).

Bump the version in `Teron Doom Launcher.csproj` (`Version`, `FileVersion`,
`AssemblyVersion`) when the change warrants a new release entry. The repo uses
`major.minor.hotfix` versioning (e.g. `1.2.0`) — no build/revision segment —
bump `minor` for new features, `hotfix` for bug fixes within the same feature
set, resetting the segment(s) to the right of whichever one is bumped.
