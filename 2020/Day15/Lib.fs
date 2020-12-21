namespace Day15

open Aoc.Lib.String

module Lib =
                                             
    type Found = Map<int, int list>
    type State = {
        found: Found;
        seq: int list
        turn: int;
    }
    
    let next state =
       let head = List.head state.seq
       let found = Map.tryFind head state.found
       
       let nextValue = match found with
                        | None -> 0
                        | Some list -> match list with
                                        | [] -> 0 // should never happen
                                        | _ :: []  ->  0
                                        | v :: p :: _  -> v - p
       let nextSeq = nextValue :: state.seq
       
       let nextFound = Map.add nextValue
                               (match Map.tryFind nextValue state.found with
                                    | None -> [state.turn]
                                    | Some list -> state.turn :: list)
                               state.found
       { seq = nextSeq; found = nextFound; turn = (state.turn + 1) }
    
        
    let rec advance n state =
        match n with
            | 0 -> List.head state.seq
            | remaining -> advance (remaining - 1) (next state) 
    
    let find n s =
        let starting = s |> split "," |> Array.map ( trim >> int) |> List.ofArray 
        
        let toKeyValue list = List.mapi (fun index i -> (i, [index + 1])) list
        let initialFound = starting |> toKeyValue |> Map.ofList
                            
        advance (n - (List.length starting)) {found = initialFound; seq = starting |> List.rev; turn = List.length starting |> (+) 1}
        
        
   
    
    

