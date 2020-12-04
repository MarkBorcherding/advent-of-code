// Learn more about F# at http://docs.microsoft.com/dotnet/fsharp

open System

type PasswordRule = {
    Character: string
    Min: int
    Max: int
}

type Line = {
    Rule: PasswordRule
    Password: string
}

let r = System.Text.RegularExpressions.Regex @"(\d+)-(\d+) ([a-z]): (.*)"

let parseLine line : option<Line> = 
    match r.Match line with 
        | l when l.Groups.Count = 5 -> 
            let groups = 
                l.Groups.Values |> 
                    Seq.map (fun f -> f.Value ) |>
                    Seq.toArray
            Some { 
                Password = groups.[4]
                Rule = {
                    Character = groups.[3]
                    Min = groups.[1] |> Int32.Parse
                    Max = groups.[2] |> Int32.Parse
                }
            }
        | l -> None

let Matches l =

    let c:char = l.Rule.Character.ToCharArray() |> Seq.head
    let count = l.Password.ToCharArray() |> 
                    Array.filter (fun a -> a = c) |>
                    Array.length

    l.Rule.Min <= count && count <= l.Rule.Max



[<EntryPoint>]
let main argv =
    let result = 
        Day02.Data.input |>
        Array.map parseLine |>
        Array.choose id |>
        Array.filter Matches |>
        Array.length

    printfn "%i" result

    Console.ReadKey() |> ignore
    0 // return an integer exit code