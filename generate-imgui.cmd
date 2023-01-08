@echo off
setlocal

:: Start in the directory containing this script
cd %~dp0

:: Ensure Dear ImGui has been cloned
if not exist vendor\imgui\ (
    echo Dear ImGui source not found! 1>&2
    exit /B 1
)

:: Run generator (will also build Nerv.DearImGui.Native)
echo Generating Nerv.DearImGui...
dotnet run --configuration Release --project Nerv.DearImGui.Generator -- "vendor/imgui/" "Nerv.DearImGui.Native/" "Nerv.DearImGui/#Generated/"
