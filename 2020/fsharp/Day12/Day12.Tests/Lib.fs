namespace Day12

module Lib=

    type CompassDirection = North | South | East | West
    type TurnDirection = Left | Right
    type Distance = Distance of int
    type NavigationDirection =
        | TurnDirection of TurnDirection
        | CompassDirection of CompassDirection
        | Forward
    type NavigationInstruction = (NavigationDirection * int)

    type Position = { x:int; y:int; facing: CompassDirection }

    let start = {x = 0; y = 0; facing = East;}



    let intoNavigationInstruction (s:string) =
        let distance = s.Substring(1) |> int
        let direction = match s.Substring(0,1) with
                            | "L" -> TurnDirection Left
                            | "R" -> TurnDirection Right
                            | "N" -> CompassDirection North
                            | "E" -> CompassDirection East
                            | "S" -> CompassDirection South
                            | "W" -> CompassDirection West
                            | "F" -> Forward
                            | d -> failwithf "Unknown direction '%A'" d
        (direction, distance)

    let parse lines = lines |> Array.map intoNavigationInstruction |> List.ofArray
                
    module part1 =
        let rec turn (direction:TurnDirection) (amount:int) (position:Position)  : Position =
            let leftTurn p = 
                match p with
                    | { facing = East } -> {position with facing = North}
                    | { facing = West } -> {position with facing = South}
                    | { facing = North } -> {position with facing = West}
                    | { facing = South } -> {position with facing = East}
            let rightTurn p = 
                match p with
                    | { facing = East } -> {position with facing = South}
                    | { facing = West } -> {position with facing = North}
                    | { facing = North } -> {position with facing = East}
                    | { facing = South } -> {position with facing = West}
            if amount = 0 then
                position
            else
                let remaining = amount - 90
                let nowFacing = match direction with
                                    | Right -> rightTurn position
                                    | Left -> leftTurn position
                turn direction remaining nowFacing
                    
            
        let advanceForward distance position =
            match position with
                | { facing = East } -> {position with x = position.x + distance}
                | { facing = West } -> {position with x = position.x - distance}
                | { facing = North } -> {position with y = position.y + distance}
                | { facing = South } -> {position with y = position.y - distance}

        let advance position (direction:NavigationInstruction) =
            match direction with
                | (TurnDirection dir, dis)  -> position |> turn dir dis 
                | (Forward,d) -> position |> advanceForward d
                | (CompassDirection c, d)  -> match c with
                                                | North -> {position with y = position.y + d}
                                                | South -> {position with y = position.y - d}
                                                | East -> {position with x = position.x + d}
                                                | West -> {position with x = position.x - d}
                                                

        let rec navigate directions from =
            match directions with
                | [] -> from
                | head :: tail -> navigate tail (advance from head)
                
        let go directions = navigate directions start
        
    module part2 =
        
        type Point = {x: int; y: int; }
        type State = { position: Point; waypoint: Point }
        
        let start = {
            position = { x = 0; y = 0 }
            waypoint = { x = 10; y = 1; }
        }
        
        let move (distance: int) (from: State) =
            let deltaX = from.waypoint.x * distance
            let deltaY = from.waypoint.y  * distance
            { from with position = {
                        x = from.position.x + deltaX;
                        y = from.position.y + deltaY } }
            
        
        let rec rotate (direction:TurnDirection) degrees (from: State) =
            if degrees = 0 then
                from
            else 
                match direction with
                    | Right -> rotate direction (degrees - 90) { from with waypoint = { x = from.waypoint.y; y = -1 * from.waypoint.x } }
                    | Left -> rotate direction (degrees - 90) { from with waypoint = { x = -1 * from.waypoint.y; y = from.waypoint.x } }
            
        let offset (direction: CompassDirection) (amount:int) (from:State) : State =
            match direction with
                | North -> { from with waypoint = { from.waypoint with y = from.waypoint.y + amount } }
                | South -> { from with waypoint = { from.waypoint with y = from.waypoint.y - amount } }
                | East -> { from with waypoint = { x = from.waypoint.x + amount; y = from.waypoint.y  } }
                | West -> { from with waypoint = { x = from.waypoint.x - amount; y = from.waypoint.y  } }
        
        let rec navigate (directions: NavigationInstruction list) (from: State) =
            match directions with
                | [] -> from
                | head :: tail ->
                    let f = match head with
                                | (Forward, distance) -> move distance
                                | (TurnDirection direction, degrees) -> rotate direction degrees
                                | (CompassDirection direction, amount) -> offset direction amount
                    navigate tail (f from) 
                
        let go directions = navigate directions start
        
           