namespace Day14

open System


module Bitwise =
    
    type Bit = One | Zero
    type Unsigned36 = Tuple36<Bit>
    
    let (|Bit|_|) (c: char): Bit option =
            if c = '1' then Some(One)
            elif c = '0' then Some (Zero)
            else None
        
        
    module Unsigned36 =
        
        let private padToLength length v arr =
            let needed = length - (Array.length arr)
            Array.concat [| (Array.replicate needed v);  arr |]
        
        let ofString (s:string) =
                Convert.ToInt64(s)  |>
                (fun i -> Convert.ToString(i, 2)) |>
                (fun s -> s.ToCharArray()) |>
                Array.map(fun c ->
                    match c with
                        | Bit b -> b
                        | c -> failwithf "We don't have binary here %c" c) |>
                padToLength 36 Bit.Zero |>
                Tuple36.ofArray
            
        let ofInt (i:int) =
            Convert.ToString(i, 2) |> ofString
            
        let toInt64 = Tuple36.toArray >>
                        Array.map ( fun b -> match b with | One -> "1" | Zero -> "0") >>
                        Array.reduce ( fun acc cur -> acc + cur) >>
                        (fun s -> Convert.ToInt64(s, 2))
            
        let Zero = 0 |> ofInt
            
        let (|Unsigned36|) = ofString
        

