@echo off
setlocal enabledelayedexpansion

:: Start in the directory containing this script
cd %~dp0

:: Determine platform RID and build folder
call ..\tooling\determine-rid.cmd || exit /B !ERRORLEVEL!
set BUILD_FOLDER=..\obj\Nerv.DearImGui.Native\cmake\%PLATFORM_RID%

:: Ensure build folder is protected from Directory.Build.* influences
if not exist %BUILD_FOLDER% (
    mkdir %BUILD_FOLDER%
    echo ^<Project^>^</Project^> > %BUILD_FOLDER%/Directory.Build.props
    echo ^<Project^>^</Project^> > %BUILD_FOLDER%/Directory.Build.targets
    echo # > %BUILD_FOLDER%/Directory.Build.rsp
)

cmake -S . -B %BUILD_FOLDER% || exit /B 1
echo ==============================================================================
echo Building Nerv.DearImGui.Native %PLATFORM_RID% debug build...
echo ==============================================================================
cmake --build %BUILD_FOLDER% --config Debug || exit /B 1
echo ==============================================================================
echo Building Nerv.DearImGui.Native %PLATFORM_RID% release build...
echo ==============================================================================
cmake --build %BUILD_FOLDER% --config Release || exit /B 1
