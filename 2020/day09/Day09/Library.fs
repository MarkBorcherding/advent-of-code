namespace Day09

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