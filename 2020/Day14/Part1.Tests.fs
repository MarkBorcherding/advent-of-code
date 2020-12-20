namespace Day14

open Day14.Bitwise
open NUnit.Framework

module Tests =
    [<SetUp>]
    let Setup () =
        ()

    [<Test>]
    let Test1 () =
        let input =
            "mask = XXXXXXXXXXXXXXXXXXXXXXXXXXXXX1XXXX0X
mem[8] = 11
mem[7] = 101
mem[8] = 0" |> Day14.Parse.lines |> List.ofArray

        let actual = Day14.Engine.advance input State.empty
        
        Assert.AreEqual(64L, actual.registers.[8] |> Unsigned36.toInt64)
        
    [<Test>]
    let MyInput () =
        let input = Day14.Data.myInput |> Day14.Parse.lines |> List.ofArray

        let actual = Day14.Engine.advance input State.empty |>
                       (fun s -> s.registers) |>
                       Map.toList |>
                       List.map (fun (k, v) -> Unsigned36.toInt64 v) |>
                       List.sum
        
        Assert.AreEqual(12610010960049L, actual )
