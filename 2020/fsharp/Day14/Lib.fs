namespace Day14

open System.Globalization
open Day14

open Bitwise

type Register = int

type Operation = Set of (Register * Unsigned36) | Mask of Mask

type State = {
    mask: Mask
    registers: Map<Register, Unsigned36>
}
module State =
    let empty = {
        mask = String.replicate 36 "X" |> Mask.ofString;
        registers = Map.empty;
    }


module Parse = 
    let line (s:string) =
        match s.Split(" = ") with
            | [| "mask"; Mask.Mask mask |] -> Mask mask
            | [| mem; Unsigned36.Unsigned36 value |] -> Set ((mem |> Util.onlyNumbers |> int), value)
            | _ -> failwith "This should not happen"        
    
    let lines (s: string) =
        s.Split("\n") |> Array.map line

    
module Engine =
    
    let write register value (state:State) =
        let next = Mask.apply state.mask value
        let registers =  Map.add register next state.registers
        
        { state with registers = registers }
    
    let rec advance operations state =
        match operations with
            | [] -> state
            | Mask mask :: tail -> { state with mask = mask } |> advance tail
            | Set (register, value) :: tail -> write register value state  |> advance tail
    
    
    
            
    
    