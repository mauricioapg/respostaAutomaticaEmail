@echo off
mkdir lib
mkdir lib\net40
copy ..\bin\Release\System.Net.Pop3.dll lib\net40\
nuget.exe pack spec.nuspec
pause