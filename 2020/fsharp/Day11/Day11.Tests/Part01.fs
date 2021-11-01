namespace Day11.Tests

open Day11.Tests.Lib

module Part1 =

    open NUnit.Framework
    
    [<SetUp>]
    let Setup () =
        ()

    [<Test>]
    let NextRound () =
        let examples = Day11.Tests.Data.Example1 |> Array.map Day11.Tests.Lib.parse
        
        let expected = examples.[1]
        let actual = Day11.Tests.Lib.nextRound examples.[0]

        Assert.AreEqual(expected, actual)
        
    [<Test>]
    let FindStable () =
        let examples = Day11.Tests.Data.Example1 |> Array.map Day11.Tests.Lib.parse
        
        let expected = examples |> Array.last
        let actual = Day11.Tests.Lib.findStable examples.[0]

        Assert.AreEqual(expected, actual)
        Assert.AreEqual(37, actual.cells |> Array.filter ((=) FilledSeat)  |> Array.length )
        
    [<Test>]
    let Part2 () =
        let part2 = Day11.Tests.Data.part2 |> Array.map Day11.Tests.Lib.parse
        
        Assert.AreEqual( part2.[1], part2.[0] |> Day11.Tests.Lib.nextRound)
        Assert.AreEqual( part2.[2], part2.[1] |> Day11.Tests.Lib.nextRound)
        
       // Assert.AreEqual(part2 |> Array.last, Day11.Tests.Lib.findStable (part2 |> Array.head))
        
    [<Test>]
    let MyInput () =
        let myInput = Day11.Tests.Data.myInput |> Day11.Tests.Lib.parse
        
        let actual = Day11.Tests.Lib.findStable myInput

        Assert.AreEqual(1978, actual.cells |> Array.filter ((=) FilledSeat)  |> Array.length )
        
