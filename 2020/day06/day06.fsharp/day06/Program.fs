// Learn more about F# at http://docs.microsoft.com/dotnet/fsharp
open System

let split (delim:string) (s:string) = s.Split(delim)

let distinctChars (s:string) =
    let a = s.Split("\n")
    let b = String.Join("", a) 
    b.ToCharArray() |> Set.ofArray


[<EntryPoint>]
let main argv =

    let calc s = Seq.sumBy Set.count (s |> split "\n\n" |> Seq.map distinctChars)

    printfn "sample %i" (calc Day06.Data.sample)
    printfn "answer %i" (calc Day06.Data.input)


    let allThings s =
        let count = split "\n" s |> Seq.length

        s.Replace("\n","").ToCharArray() |>
            Array.groupBy (id) |>
            Array.filter (fun (_, a) -> a.Length = count) |>
            Array.length

    let calc2 s = Seq.sumBy allThings (s |> split "\n\n")

    printfn "part 2"
    printfn "sample %i" (calc2 Day06.Data.sample)
    printfn "answer %i" (calc2 Day06.Data.input)
    0 // return an integer exit code