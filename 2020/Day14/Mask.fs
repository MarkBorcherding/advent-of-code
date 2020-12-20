namespace Day14

type MaskValue = Set of Bitwise.Bit | Unset
type Mask = Tuple36<MaskValue> 

module Mask =
    let ofString (s:string): Mask =
        s.Trim().ToCharArray() |>
        Array.map (fun c ->match c with
                            | 'X' -> Unset
                            | Bitwise.Bit b-> Set b
                            | _ -> failwith "We should never get something we don't expect") |>
        Tuple36.ofArray
        
    let (|Mask|) = ofString
    
    let apply (mask:Mask) (value: Bitwise.Unsigned36) : Bitwise.Unsigned36 =
        Tuple36.zip mask value |>
        Tuple36.map (fun (prev, mask) ->
                match mask with
                    | Unset -> prev
                    | Set b -> b )
    
