namespace Day08

open System

    
module Part1 =
    
    type Operation = Jump | Noop | Acc
    type Instruction = ( Operation * int )
    
    type ResultType = Finish | Loop
    type Result = (ResultType  * int)
    
    let intoInstruction (str:string) : Instruction =
        let split = str.Split(" ")
        let arg = split.[1] |> int
        let op = match split.[0] with
            | "acc" -> Acc
            | "jmp" -> Jump
            | "nop" -> Noop
            | _ -> raise (ApplicationException("Unknown operation"))
        (op, arg)
    
    let parse (input:string) =
            input.Split("\n")  |>
            Array.map intoInstruction
    
    
    let rec advance (input: Instruction array) (visited: int Set) (current: int) (acc: int) =
        if visited.Contains current then
            (Loop,  acc)
        else if current = Array.length input then
            (Finish, acc)
        else
            let next = advance input (Set.add current visited)
            match input.[current] with
                | (Noop, _ ) -> next (current+1) acc 
                | (Jump, offset) -> next (current + offset) acc
                | (Acc, inc) -> next (current + 1) (acc + inc)
                
    let runStart instructions = advance instructions Set.empty 0 0
        
    let run input = parse input |> runStart
        
    let rec solveNext (input:Instruction array) (nextChange: int) =
        let nextInput = Array.copy input
        let nextInstruction = match nextInput.[nextChange] with
                                | (Jump, op) -> (Noop, op)
                                | (Noop, op) -> (Jump, op)
                                | s -> s
                                
        Array.set nextInput nextChange nextInstruction
        
        match runStart nextInput with
            | (Finish, acc) -> (Finish, acc)
            | (Loop, _) -> solveNext input (nextChange + 1)
        
    let solve input =
        let instructions = parse input
        solveNext instructions 0
        