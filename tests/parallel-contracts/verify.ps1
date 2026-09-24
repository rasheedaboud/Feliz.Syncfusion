$ErrorActionPreference = 'Stop'
$here = $PSScriptRoot

dotnet build (Join-Path $here 'Positive.fsproj') --nologo
if ($LASTEXITCODE -ne 0) { throw 'The positive contract did not compile.' }

$negativeOutput = & dotnet build (Join-Path $here 'Negative.fsproj') --nologo 2>&1
$negativeExit = $LASTEXITCODE
$negativeText = $negativeOutput | Out-String
if ($negativeExit -eq 0) { throw 'The negative contract unexpectedly compiled.' }
if ($negativeText -notmatch 'Negative\.fs\(\d+,\d+\): error FS0001:.*Choice|Negative\.fs\(\d+,\d+\): error FS0001:.*Other' -or
    $negativeText -notmatch 'Negative\.fs\(\d+,\d+\): error FS0001:' -or
    $negativeText -notmatch 'Negative\.fs\(\d+,\d+\): error FS0193:' -or
    $negativeText -notmatch 'IFileUploaderProperty.*IDatePickerProperty') {
    throw "The negative build failed for an unexpected reason:`n$negativeText"
}
Write-Output 'Positive contract compiled; negative property and event contracts were rejected.'
