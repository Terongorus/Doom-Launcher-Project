; Inno Setup script for Teron's Doom Launcher.
;
; Normally you don't need to run this directly: publishing the win-x64 or win-x86 profile
; (via "dotnet publish -p:PublishProfile=win-x64" or Visual Studio's Publish dialog) builds
; this automatically as a post-publish MSBuild step - see the BuildInnoSetupInstaller target
; in DoomLauncherProject.csproj. The lines below are only needed to run it manually:
;   dotnet publish -p:PublishProfile=win-x64 -c Release
;   dotnet publish -p:PublishProfile=win-x86 -c Release
;   ISCC DoomLauncherProject.iss              (defaults to x64)
;   ISCC /DArch=x86 DoomLauncherProject.iss    (x86 build)
;
; Output goes to bin\InstallerPackage\DoomLauncherProjectSetup-<arch>.exe

#ifndef Arch
  #define Arch "x64"
#endif

#ifndef MyAppVersion
  #define MyAppVersion "1.7.0"
#endif

#define MyAppName "Teron's Doom Launcher"
#define MyAppPublisher "Teronverse"
#define MyAppExeName "DoomLauncherProject.exe"
#define MyPublishDir "..\bin\Publish\TeronDoomLauncher_Win_" + Arch

[Setup]
AppId={{B6EC303A-AFD9-4B98-AD07-34A30D2B4BC4}
AppName={#MyAppName}
AppVersion={#MyAppVersion}
AppPublisher={#MyAppPublisher}
DefaultDirName={autopf}\DoomLauncherProject
DefaultGroupName={#MyAppName}
DisableProgramGroupPage=yes
LicenseFile=..\LICENSE.txt
SetupIconFile=..\TDL.ico
UninstallDisplayIcon={app}\{#MyAppExeName}
OutputDir=..\bin\InstallerPackage
OutputBaseFilename=TeronDoomLauncher-{#Arch}
Compression=lzma2/max
SolidCompression=yes
WizardStyle=modern
ArchitecturesAllowed={#(Arch == "x64" ? "x64compatible" : "x86compatible")}
ArchitecturesInstallIn64BitMode={#(Arch == "x64" ? "x64compatible" : "")}

[Languages]
Name: "english"; MessagesFile: "compiler:Default.isl"

[Tasks]
Name: "desktopicon"; Description: "Create a &desktop shortcut"; GroupDescription: "Additional shortcuts:"

[Files]
Source: "{#MyPublishDir}\*"; DestDir: "{app}"; Flags: ignoreversion recursesubdirs createallsubdirs

[Icons]
Name: "{group}\{#MyAppName}"; Filename: "{app}\{#MyAppExeName}"
Name: "{group}\Uninstall {#MyAppName}"; Filename: "{uninstallexe}"
Name: "{autodesktop}\{#MyAppName}"; Filename: "{app}\{#MyAppExeName}"; Tasks: desktopicon

[Run]
Filename: "{app}\{#MyAppExeName}"; Description: "Launch {#MyAppName}"; Flags: nowait postinstall skipifsilent
