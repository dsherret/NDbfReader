@ECHO off

CALL .\build.cmd
IF %ERRORLEVEL% GTR 0 EXIT /b

RMDIR ".\opencover" /s /q

MKDIR ".\opencover"
.\packages\OpenCover.4.5.2506\OpenCover.Console.exe^
 -register:user^
 -target:".\packages\xunit.runners.1.9.2\tools\xunit.console.clr4.exe"^
 -targetargs:".\NDbfReader.Tests\bin\Debug\NDbfReader.Tests.dll /noshadow /silent"^
 -filter:+[NDbfReader]*^
 -output:.\opencover\output.xml

 MKDIR ".\opencover\report" /s /q
.\packages\ReportGenerator.1.9.1.0\ReportGenerator.exe^
 -reports:.\opencover\output.xml^
 -targetdir:.\opencover\report^
 -reporttypes:Html,HtmlSummary
 .\opencover\report\index.htm