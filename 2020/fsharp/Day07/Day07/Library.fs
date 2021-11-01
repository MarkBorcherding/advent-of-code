namespace Day07

module Luggage =
    
    let replace (find:string) (replaceWith:string) (s:string) = s.Replace(find, replaceWith)
    let split (delim:string) (s:string) = s.Split delim
    
    let matchesLuggage (luggage:string list) (rule:(string * string)) : bool =
       let (current, rulesAllow) = rule
       
       if rulesAllow.Contains "no other" then
           List.contains current luggage
       else
        luggage |>
            List.filter (fun s -> rulesAllow.Contains s) |>
            List.length |>
            (<) 0
        
    let rec recurse (rules:(string * string) list) (luggage: string list) =
        let matching = rules |> List.filter (matchesLuggage luggage)
      
        let matchCount = List.length matching 
        if matchCount > 0 then
            let matchedLuggage = matching |> List.map (fun (l, _) -> l) |> List.distinct |> List.sort
            List.append matchedLuggage  (recurse rules matchedLuggage)
        else
            List.empty
        
    let count (ruleLines:string) (matching: string) =
        let thing = (split " contain " >> (fun a -> (a.[0].Trim(), a.[1].Trim())))
        let rules =
               ruleLines |>
                   replace "bags" "" |>
                   replace "bag" "" |>
                   replace "." "" |>
                   split "\n" |>
                   Array.map thing |>
                   List.ofArray
        recurse rules [ matching ] |>
            List.distinct |>
            List.length
            
                       
        
