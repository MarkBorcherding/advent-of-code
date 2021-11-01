namespace Day14

module Util =
    // being super lazy with this method
    let  onlyNumbers = String.filter((fun c -> Array.contains c [|'0';  '1'; '2'; '3'; '4'; '5'; '6'; '7'; '8'; '9' |] ))


type Tuple36<'t> = ( 't * 't * 't * 't * 't * 't * 't * 't * 't * 't * 't * 't * 't * 't * 't * 't * 't * 't * 't * 't * 't * 't * 't * 't * 't * 't * 't * 't * 't * 't * 't * 't * 't * 't * 't * 't )

module Tuple36 =
    
    let ofArray arr =
        if Array.length arr <> 36 then failwith "What are you doing?"
        ( arr.[0], arr.[1], arr.[2], arr.[3], arr.[4], arr.[5], arr.[6], arr.[7], arr.[8],
          arr.[9], arr.[10], arr.[11], arr.[12], arr.[13], arr.[14], arr.[15], arr.[16], arr.[17],
          arr.[18], arr.[19], arr.[20], arr.[21], arr.[22], arr.[23], arr.[24], arr.[25], arr.[26],
          arr.[27], arr.[28], arr.[29], arr.[30], arr.[31], arr.[32], arr.[33], arr.[34], arr.[35] )
    
    let toArray (tuple: Tuple36<'a>): array<'a>  =
        let arr0, arr1, arr2, arr3, arr4, arr5, arr6, arr7, arr8,
            arr9, arr10, arr11, arr12, arr13, arr14, arr15, arr16, arr17,
            arr18, arr19, arr20, arr21, arr22, arr23, arr24, arr25, arr26, 
            arr27, arr28, arr29, arr30, arr31, arr32, arr33, arr34, arr35 = tuple
            
        [| arr0; arr1; arr2; arr3; arr4; arr5; arr6; arr7; arr8;
              arr9; arr10; arr11; arr12; arr13; arr14; arr15; arr16; arr17;
              arr18; arr19; arr20; arr21; arr22; arr23; arr24; arr25; arr26; 
              arr27; arr28; arr29; arr30; arr31; arr32; arr33; arr34; arr35 |]
        
    let zip (a: Tuple36<'a>) (b: Tuple36<'b>): Tuple36<'b * 'a> =
        a |> toArray |> Array.zip (b |> toArray) |> ofArray
        
    let map (f:'a -> 'b) (tuple: Tuple36<'a>) : Tuple36<'b> =
        tuple |> toArray |> Array.map f |> ofArray

        
