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

let xor a b = (a || b) && (a <> b)

let get index list =
    Array.tryItem (index - 1) list

let matches expected actual  =
    match actual with
        | Some(a) -> a = expected
        | None -> false

let Part2Matches l =
    let ruleChar:char = l.Rule.Character.ToCharArray() |> Seq.head
    let passwordChars = l.Password.ToCharArray()

    let matchesFirst = 
        passwordChars |>
            get l.Rule.Min |>
            matches ruleChar

    let matchesSecond = 
        passwordChars |>
            get l.Rule.Max |>
            matches ruleChar

    xor matchesFirst matchesSecond

let part1 input = 
    input  |>
        Array.map parseLine |>
        Array.choose id |>
        Array.filter Matches |>
        Array.length

let part2 input =
    input |>
        Array.map parseLine |>
        Array.choose id |>
        Array.filter Part2Matches |>
        Array.length


[<EntryPoint>]
let main argv =

    printfn "part 1 %i" (part1 Day02.Data.input)
    printfn "part 2 %i" (part2 Day02.Data.input)

    Console.ReadKey() |> ignore
    0 // return an integer exit code