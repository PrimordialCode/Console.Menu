$src_directory = Resolve-Path .
$sln = "$src_directory\src\EasyConsoleApplication.sln"
$configurationdefault = "Release"
$artifacts = "$src_directory\artifacts"

$configuration = Read-Host 'Configuration to build [default: Release] ?'
if ($configuration -eq '') {
    $configuration = $configurationdefault
}
# $runtests = Read-Host 'Run Tests (y / n) [default:n] ?'

# Install gitversion tool
dotnet tool restore
$output = dotnet tool run dotnet-gitversion | out-string # /nofetch

# GitVersion
Write-Host $output
$version = $output | ConvertFrom-Json
$assemblyVersion = $version.AssemblySemver
$assemblyFileVersion = $version.AssemblySemver
#$assemblyInformationalVersion = ($version.SemVer + "." + $version.Sha)
$assemblyInformationalVersion = ($version.InformationalVersion)
$nugetVersion = $version.NuGetVersion
Write-Host $assemblyVersion
Write-Host $assemblyFileVersion
Write-Host $assemblyInformationalVersion
Write-Host $nugetVersion

# Display minimal restore information
#& dotnet restore $sln --verbosity m

# Build
Write-Host "Building: $nugetversion $configuration $sln"
& dotnet build $sln --configuration $configuration /p:AssemblyVersion=$assemblyVersion /p:FileVersion=$assemblyFileVersion /p:InformationalVersion=$assemblyInformationalVersion /p:ContinuousIntegrationBuild=True

# Testing
# if ($runtests -eq "y") {
#     Write-Host "Executing Tests"
#     dotnet test ./src/EasyConsoleApplication.sln -c $configuration --no-build
#     Write-Host "Tests Execution Complated"
# }

# NuGet packages
Write-Host "NuGet Packages creation: $nugetversion"
& dotnet pack "$src_directory/src/EasyConsoleApplication/EasyConsoleApplication.csproj" --configuration $configuration --no-build -o $artifacts /p:PackageVersion=$nugetversion --include-symbols