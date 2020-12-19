namespace Aoc.Lib

module Utils =
    let tap (f: 'T -> unit) (o: 'T) =
        f o
        o
