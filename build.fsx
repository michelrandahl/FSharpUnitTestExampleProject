// include Fake libs
#r "./packages/FAKE/tools/FakeLib.dll"

open Fake
open Fake.Testing // NUnit3 is in here


// Directories
let buildDir  = "./build/"
let testDir = "./test/"

// version info
let version = "0.1"  // or retrieve from CI server

// Targets
Target "Clean" (fun _ ->
    CleanDirs [buildDir; testDir]
)

Target "Build" (fun _ ->
    !! "src/MyProject/*.fsproj"
    |> MSBuildRelease buildDir "Build"
    |> Log "AppBuild-Output: "
)

Target "BuildTest" (fun _ ->
                    !! "src/NUnit.Test.MyTests/*.fsproj"
                    |> MSBuildDebug testDir "Build"
                    |> Log "TestBuild-Output: "
)

Target "Test" (fun _ ->
               !! (testDir + "/NUnit.Test.*.dll")
               |> NUnit3 (fun p ->
                         { p with
                               ToolPath = "packages/NUnit.ConsoleRunner/tools/nunit3-console.exe" })
)


Target "Default" (fun _ -> trace "HEEEELLOOOOOO world from FAKE!!!")

"Clean"
 ==> "Build"
 ==> "BuildTest"
 ==> "Test"
 ==> "Default"

RunTargetOrDefault "Default"
