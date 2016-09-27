namespace MyProject

module MyProject =

    open MyProject.MyFunctions

    [<EntryPoint>]
    let main argv =
        if Array.length argv > 0
        then printfn "%s" (sayHello argv.[0])
        else printfn "no name provided"
        0 // return an integer exit code
