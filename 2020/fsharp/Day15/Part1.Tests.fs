namespace Day15

open NUnit.Framework

module Tests =
    
    [<SetUp>]
    let Setup () =
        ()

    let actual = Lib.find 2020

    [<Test>]
    let SmallExample () = Assert.AreEqual(0, Lib.find 10 "0,3,6" )
    
    [<Test>]
    let Example7 () = Assert.AreEqual(436, actual "0,3,6" )

    [<Test>]
    let Example1 () = Assert.AreEqual(1, actual "1,3,2" )

    [<Test>]
    let Example2 () = Assert.AreEqual(10, actual "2,1,3" )

    [<Test>]
    let Example3 () = Assert.AreEqual(27, actual "1,2,3" )

    [<Test>]
    let Example4 () = Assert.AreEqual(78, actual "2,3,1" )

    [<Test>]
    let Example5 () = Assert.AreEqual(438, actual "3,2,1" )

    [<Test>]
    let Example6 () = Assert.AreEqual(1836, actual "3,1,2" )
    
    [<Test>]
    let Part1 () = Assert.AreEqual(929, Lib.find 2020  "16,1,0,18,12,14,19")
    
    [<Test>]
    let Part2 () = Assert.AreEqual(929, Lib.find 30_000_000  "16,1,0,18,12,14,19")
    
