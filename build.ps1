properties {
	$pwd = Split-Path $psake.build_script_file	
	$build_directory  = "$pwd\Build\"
	$solution_name = "ConDep.Dsl"
	$solution_file = "$solution_name.sln"
	$tools_directory  = "$pwd\tools\"
	$version          = "1.0.0.0"
	$configuration = "Debug"
}
�
include .\tools\psake_ext.ps1
�
task default -depends Build
task ci -depends Build

task Build -depends Clean, Init { 
	Exec { msbuild "$solution_file" /t:Build /p:Configuration=$configuration /p:OutDir=$build_dir }
}

task Init {  
    Generate-Assembly-Info `
        -file "$pwd\AssemblyVersionInfo.cs" `
        -company "ConDep" `
        -product "ConDep $version" `
        -copyright "Copyright � ConDep 2012" `
        -version $version `
        -clsCompliant "true"
        
    if ((Test-Path $build_directory) -eq $false) {
        New-Item $build_directory -ItemType Directory
    }
}
�
task Clean {
	Write-Host "Cleaning Build output"  -ForegroundColor Green
	Remove-Item $build_directory -Force -Recurse -ErrorAction SilentlyContinue
}
