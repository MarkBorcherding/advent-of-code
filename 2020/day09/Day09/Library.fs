namespace Day09

open System

module Part1 =
    
    let rec anySum (list: int64 list) (i: int64) =
        match list  with
            | [] -> false
            | head :: tail ->
                    match List.tryFind (fun this -> this + head = i) tail with
                        | Some f -> true
                        | None -> anySum tail i
                    
                    
    let last n list = list |> List.rev |> List.take n |> List.rev
                    
    let rec validate (prev: int64 list) (rest: int64 list) =
        match rest with
            | [] -> []
            | head :: tail ->
                let next = prev @ [head] |> last (List.length prev)
                if anySum prev head then
                    validate next tail 
                else
                    head :: (validate next tail)
                    
                
                
                
                
module Part2=
    let rec takeWhileAcc pred (acc:int64) list : int64 list =
        if pred acc then
            match list with
                | [] -> []
                | head :: tail -> head :: takeWhileAcc pred (acc + head) tail 
        else
            []
    
    let encryptionWeakness (list: int64 list) (targetSum:int64) =
            let pred acc = acc < targetSum
            let takeThem = takeWhileAcc pred 0L 
            let rec recurse l =
                let found = takeThem l
                let exact = found |> List.sum |> (=) targetSum
                if exact then
                    let min = found |> List.min
                    let max = found |> List.max
                    Some (min + max)
                else
                    match l with
                        | [] -> None
                        | _ :: tail -> recurse tail
            recurse list