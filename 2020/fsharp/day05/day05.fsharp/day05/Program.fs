// Learn more about F# at http://docs.microsoft.com/dotnet/fsharp

open System

type SeatGroup = Left | Right

type RowGroup = Forward | Back

type Instruction = {
    Rows: RowGroup list;
    Seats: SeatGroup list;
}

type SeatAssignment = {
    Row: int;
    Seat: int;
}



let intoRow c =
    match c with 
        | 'F' -> Forward
        | 'B' -> Back
        | _ -> raise (ApplicationException "boom")

let intoSeat c =
    match c with 
        | 'L' -> Left
        | 'R' -> Right
        | _ -> raise (ApplicationException "boom")

let toTuple n list =
    Seq.fold 

let parseLine (line:string) : Instruction  =
    {
        Rows = line.Substring(0, 7).ToCharArray() |> Array.map intoRow |> Array.toList
        Seats = line.Substring(7, 3).ToCharArray() |> Array.map intoSeat |> Array.toList
    }

let parseLines (lines: string list): Instruction list =
    List.map parseLine lines

let row (instruction:Instruction) =
    let maxRow = (1 <<< instruction.Rows.Length) - 1
    instruction.Rows |>
        List.fold (fun (min, max) cur -> 
            let mid = ((max - min + 1) / 2) + min
            match cur with 
                | Forward ->  (min, mid)
                | Back ->  (mid, max))
         (0, maxRow) |> 
         (fun (r, _) -> r)

let seat (instruction:Instruction) =
    let maxSeat = (1 <<< instruction.Seats.Length) - 1

    instruction.Seats |>
        List.fold (fun (min, max) cur -> 
            let mid = ((max - min + 1) / 2) + min
            match cur with 
                | Left ->  (min, mid)
                | Right ->  (mid, max))
         (0, maxSeat) |>
         (fun (s, _) -> s)
        

let seatAssignment instruction = 
    let row = row instruction
    let seat = seat instruction
    { Row = row; Seat = seat }

let calc seatAssignment = 
    8 * seatAssignment.Row + seatAssignment.Seat


[<EntryPoint>]
let main argv =

    let samples = Day05.Data.samples |> List.map (fun s -> s.Input)

    let magic = List.map (parseLine >> seatAssignment >> calc) 
    let s = magic samples

    let myData = Day05.Data.input.Split("\n") |> Array.toList 

    let seats = magic myData  |> List.sort
    
    let max = List.max seats
    let min = List.min seats

    let all = seq { min .. max } |> Seq.sum
    let found = List.sum seats

    let mine = all - found










    
    0 // return an integer exit code