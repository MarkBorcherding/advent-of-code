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

    printfn "part 1 "
    printfn "Sample answer is %i" sampleAnswer
    printfn "My answer is %i" myAnswer

    printfn "\npart 2"


    let m = Day03.Data.input |>
                parse


    let slopes = [
        countTrees 1 1
        countTrees 3 1
        countTrees 5 1 
        countTrees 7 1
        countTrees 1 2
    ]

    let part2 map = 
        let m = parse map
        (List.map ((fun slope -> slope 0 0 m) >> int64) slopes) |>
            List.fold (*) 1L 
                        
        

    let sample2 = part2 Day03.Data.sample
    let my2 = part2 Day03.Data.input

    printfn "sample 2 %i" sample2
    printfn "my 2 %i" my2
    






    0 // return an integer exit code