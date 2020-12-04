open System


type Space = Tree | Open

type Cell = Empty | Tree

type Row = Cell array

type TreeMap = Row array

let mapChar c : Cell =
    match c with
        | '.' -> Empty
        | '#' -> Tree
        | _ -> Empty

let intoRow (rowAsString:string): Row =
    rowAsString.ToCharArray() |>
        Array.map mapChar

let parse (input:string):TreeMap  = 
    input.Split("\n") |>
        Array.map intoRow

    
let rec countTrees moveX moveY x y (treemap:TreeMap) =

    let row = treemap.[y]
    let cell = row.[x]
    let incrementBy = match cell with
                        | Tree -> 1
                        | Empty -> 0
    let nextX = (x + moveX) % row.Length
    let nextY = y + moveY
        
    let allDone = nextY >= treemap.Length
    match allDone with 
        | true  -> incrementBy
        | false -> incrementBy + countTrees moveX moveY nextX nextY treemap


let printTreeMap (treemap:TreeMap) =

    treemap |> 
        Array.map (fun row -> 
            row |>
                Array.map (fun cell -> 
                    match cell with 
                        | Empty -> "."
                        | Tree -> "#"
                ) |>
                String.concat ""
        ) |> 
        String.concat "\n" |>
        printfn "%s"
    treemap



[<EntryPoint>]
let main argv =
    let treemap = parse Day03.Data.input

    let thing = countTrees 3 1
    let treeCount = thing 0 0 treemap


    let sampleAnswer = 
        Day03.Data.sample |>
            parse |>
            thing 0 0

    let myAnswer = 
        Day03.Data.input |>
            parse |>
            thing 0 0

    printfn "Sample answer is %i" sampleAnswer
    printfn "My answer is %i" myAnswer


    0 // return an integer exit code