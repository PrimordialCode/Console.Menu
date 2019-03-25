$configurationdefault = "Release"
$artifacts = "./artifacts"

$configuration = Read-Host 'Configuration to build [default: Release] ?'
if ($configuration -eq '') {
    $configuration = $configurationdefault
}
# $runtests = Read-Host 'Run Tests (y / n) [default:n] ?'

# Consider using NuGet to download the package (GitVersion.CommandLine)
choco install gitversion.portable --pre --y
choco upgrade gitversion.portable --pre --y

# Display minimal restore information
dotnet restore ./src/EasyConsoleApplication.sln --verbosity m

# GitVersion 
$str = gitversion /updateAssemblyInfo | out-string
$json = convertFrom-json $str
$nugetversion = $json.NuGetVersion

# Build
Write-Host "Building: "$nugetversion
dotnet build ./src/EasyConsoleApplication.sln -c $configuration --no-restore

# Testing
# if ($runtests -eq "y") {
#     Write-Host "Executing Tests"
#     dotnet test ./src/EasyConsoleApplication.sln -c $configuration --no-build
#     Write-Host "Tests Execution Complated"
# }

# NuGet packages
Write-Host "NuGet Packages creation"
dotnet pack ./src/EasyConsoleApplication/EasyConsoleApplication.csproj -c $configuration --no-build -o $artifacts /p:PackageVersion=$nugetversion