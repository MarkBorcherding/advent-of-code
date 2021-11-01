namespace Day11.Tests

module Lib=
    
    
    type Floor =
        member this.ToString = "."
        
    type EmptySeat =
        member this.ToString = "L"
       
    type FilledSeat =
        member this.ToString = "#"
        
            
    
    type Cell = Floor  | EmptySeat | FilledSeat
    
    type SeatMap = { width: int;  cells: Cell array}
    
    type SeatCoordinate = int option
    type Neighbors = {
           aboveLeft: SeatCoordinate;
           above: SeatCoordinate;
           aboveRight: SeatCoordinate;
           
           right: SeatCoordinate
           me: int;
           left: SeatCoordinate;
           
           belowLeft: SeatCoordinate;
           below: SeatCoordinate;
           belowRight: SeatCoordinate;
         }
    
    
    type Seat(map: SeatMap, seat: int)=
        let width = map.width
        let myRow = seat / width
        let myCol = seat % width
        let lastCol = myCol = (width - 1)
        let firstCol = myCol = 0
        let firstRow = myRow = 0
        let lastRow = myRow = ((map.cells.Length / width) - 1)
        
        let adjust f = Option.map2 (fun o _ -> f o)
        let adjustLeft = adjust ((+) -1)
        let adjustRight = adjust ((+) 1)
        
        let cell c = Option.map (fun i -> map.cells.[i]) c
        
        let rec nearest (f: Seat -> int option) (seat: Seat) =
            let next = f seat |> Option.map (fun idx -> Seat(seat.map, idx))
            match next with
                | Some n ->
                    match n.me with
                        | Floor -> nearest f (Seat(n.map, n.index))
                        | _ -> next
                | _ -> next
                
        member this.index = seat
        member this.map = map
        
        member this._above = if firstRow then None else Some (seat - width)
        member this._left = if firstCol then None else Some (seat - 1)
        member this._right = if lastCol then None else Some (seat + 1)
        member this._below = if lastRow then None else Some (seat + width)
        member this._aboveLeft = adjustLeft this._above this._left
        member this._aboveRight = adjustRight this._above this._right
        member this._belowLeft = adjustLeft this._below this._left
        member this._belowRight = adjustRight this._below this._right
        
        member this.aboveLeft = cell this._aboveLeft
        member this.above = cell this._above
        member this.aboveRight = cell this._aboveRight
        member this.left = cell this._left
        member this.right = cell this._right
        member this.me = cell (Some (this.index)) |> Option.get
        member this.belowLeft = cell this._belowLeft
        member this.below = cell this._below
        member this.belowRight = cell this._belowRight
        
        
        
        member this.neighbors = this.aboveLeft :: this.above :: this.aboveRight ::
                                this.left :: this.right ::
                                this.belowLeft :: this.below :: this.belowRight :: [] |>
                                List.choose (id) |>
                                List.filter (fun s -> s <> Floor)
                                
                                
        member this.neihboringSeats =
                nearest (fun s -> s._aboveLeft) ::
                nearest (fun s -> s._above) ::
                nearest (fun s -> s._aboveRight) ::
                nearest (fun s -> s._left) ::
                nearest (fun s -> s._right) ::
                nearest (fun s -> s._belowLeft) ::
                nearest (fun s -> s._below) ::
                nearest (fun s -> s._belowRight) :: [] |>
                List.map (fun f -> f this) |>
                List.choose (id) |>
                List.map (fun s -> s.me) |>
                List.filter (fun s -> s <> Floor)
                
                
    
    let charToCell (c:char) =
        match c with
            | '.' -> Floor
            | 'L' -> EmptySeat
            | '#' -> FilledSeat
            | _ -> failwithf "Unknown cell type '%c'" c
            
            
    let notNewLines (c:char) = c <> '\n'
    
    let parse (s:string) =
        let width = s.IndexOf "\n"
        let cells = s.ToCharArray() |> Array.filter notNewLines |> Array.map charToCell
        { width = width; cells = cells }
        
    let nextRound (map: SeatMap) =
        
        let allEmpty = List.forall ((=) EmptySeat)
        let tooCrowded l = l |> List.filter ((=) FilledSeat) |> List.length |> ((<=) 5)
        
        let nextSeat (s:Seat) = match s.me with
                                    | EmptySeat when s.neihboringSeats |> allEmpty -> FilledSeat
                                    | FilledSeat when s.neihboringSeats |> tooCrowded->  EmptySeat
                                    | _ -> s.me
            
        {
            width = map.width;
            cells = map.cells |> Array.mapi (fun c _ -> Seat(map, c) |> nextSeat )
        }
        
    let rec findStable (map: SeatMap) =
        let next = nextRound map
        if next = map then
            map
        else
            findStable next
                    
            
            
            
            
        
                
        
        
        
        
        
        
    
    

