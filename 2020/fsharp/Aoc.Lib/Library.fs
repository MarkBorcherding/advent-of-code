namespace Aoc.Lib

module Utils =
    let tap (f: 'T -> unit) (o: 'T) =
        f o
        o
        
        
module String =
    let split (delim:string) (s: string) = s.Split delim
    
    let trim (s: string) = s.Trim()
