namespace Day13.Tests

open NUnit.Framework

module Part1=
    
    [<SetUp>]
    let Setup () =
        ()

    [<Test>]
    let Example () =
        let input = Day13.Data.example |> Day13.Lib.parse
        let quickest = Day13.Lib.quickest input
        Assert.AreEqual(295, quickest)
        
    [<Test>]
    let MyInput () =
        let input = Day13.Data.myInput |> Day13.Lib.parse
        let quickest = Day13.Lib.quickest input
        Assert.AreNotEqual(295, quickest)
        Assert.AreEqual(102, quickest)


module Part2=
    
    
    
    let actual = Day13.Lib.starsAlign
    
    [<Test>]
    let Example () =
        Assert.AreEqual(3417, actual "17,x,13,19")
        
    [<Test>]
    let Example2 () =
        Assert.AreEqual(754018, actual "67,7,59,61")
        
    [<Test>]
    let Example3 () =
        Assert.AreEqual(779210, actual "67,x,7,59,61")
        
    [<Test>]
    let Example4 () =
        Assert.AreEqual(1202161486, actual "1789,37,47,1889")
        
    [<Test>]
    let MyInput () =
        let input = Day13.Data.myInput.Split("\n").[1]
        Assert.AreEqual(1202161486, actual input)

