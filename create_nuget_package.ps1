function CreateNuPack() {
    remove-item .\NuPack -force -recurse -erroraction silentlycontinue
    mkdir NuPack
    mkdir NuPack\lib
    mkdir NuPack\lib\net40
    mkdir NuPack\tools
    mkdir NuPack\content
    
    Copy-Item .\Build\*.* .\NuPack\lib\net40
    Remove-Item .\NuPack\lib\net40\*.pdb
    Remove-Item .\NuPack\lib\net40\xunit.*
    Remove-Item .\NuPack\lib\net40\*Test.*
      
    $version = [System.Diagnostics.FileVersionInfo]::GetVersionInfo((ls .\NuPack\lib\net40\*.dll).FullName).FileVersion
    $nupack = [xml](get-content .\NSupport.nuspec)
    $nupack.package.metadata.version = $version
    
    $writerSettings = new-object System.Xml.XmlWriterSettings
    $writerSettings.OmitXmlDeclaration = $true
    $writerSettings.NewLineOnAttributes = $true
    $writerSettings.Indent = $true
    
    $base_dir  = resolve-path .
    
    $writer = [System.Xml.XmlWriter]::Create("$base_dir\Nupack\NSupport.nuspec", $writerSettings)

    $nupack.WriteTo($writer)
    $writer.Flush()
    $writer.Close()
      
    ./.nuget/nuget.exe pack .\NuPack\NSupport.nuspec
}

function BuildSolution() {
    remove-item .\Build -force -recurse -erroraction silentlycontinue
    
    $v4_net_version = (ls "$env:windir\Microsoft.NET\Framework\v4.0*").Name    
    
    &"C:\Windows\Microsoft.NET\Framework\$v4_net_version\MSBuild.exe" ".\NSupport.sln" /p:OutDir="..\Build\" /p:Configuration=Release
}

function Clean() {
    remove-item .\NuPack -force -recurse -erroraction silentlycontinue
    remove-item .\Build -force -recurse -erroraction silentlycontinue
}

BuildSolution
CreateNuPack
Clean
