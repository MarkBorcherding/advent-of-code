open System

let rec AddsTwo target list = 
    match list with
        | [] -> None
        | head :: tail -> 
            match tail |> List.tryFind (fun cur -> target - head = cur)  with
                | Some a -> Some (a,head)
                | None -> AddsTwo target tail

let rec AddsThree target list =
    match list with
        | [] -> None
        | head :: tail ->
            match AddsTwo (target - head) tail  with
                | None -> AddsThree target tail
                | Some(b , c) -> Some(head, b, c)

[<EntryPoint>]
let main argv =
    let input = Day01.Data.input
    let target = Day01.Data.target

    match AddsTwo target input with
        | Some (a,b) -> 
            let c = a * b
            printfn "found %i * %i = %i" a b c
        | None ->
            printfn "Couldn't find any match for two"


    match AddsThree target input with
        | Some (a,b,c) ->
            let d = a * b * c
            printfn "found %i * %i * %i = %i" a b c d
        | None ->
            printfn "Couldn't find any match for three"

    System.Console.ReadKey() |> ignore 
    0 
