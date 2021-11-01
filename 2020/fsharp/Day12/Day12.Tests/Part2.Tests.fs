namespace Day12

open NUnit.Framework

module Part2 =


    [<SetUp>]
    let Setup () =
        ()

    [<Test>]
    let Test1 () =
        let directions = Day12.Lib.parse Day12.Data.example
        let destination = Day12.Lib.part2.go directions
        Assert.AreEqual( true, destination)
        
    [<Test>]
    let MyInput () =
        let directions = Day12.Lib.parse Day12.Data.myInput
        let destination = Day12.Lib.part2.go directions
        Assert.AreEqual( true, destination)
        
        

