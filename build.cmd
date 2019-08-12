echo OFF
dotnet build %~dp0\HiddenWindow.sln /p:Configuration=Release && (echo Build successful) || goto buildfailed

echo Completed Successfully

exit 0

:buildfailed
   echo Build Failed
   exit 1
