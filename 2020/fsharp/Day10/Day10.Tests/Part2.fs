namespace Day10.Tests

open NUnit.Framework

module Part1 =
    
    [<SetUp>]
    let Setup () =
        ()

    [<Test>]
    let SuperSimple () =
        Assert.AreEqual(3, Day10.Lib.solve [  4;  2; 1; ])

    [<Test>]
    let Example () =
        Assert.AreEqual(8, Day10.Lib.solve Day10.Tests.Data.example1)
            
    [<Test>]
    let Example2 () =
        Assert.AreEqual(19208, Day10.Lib.solve Day10.Tests.Data.example2)

    [<Test>]
    let MyInput () =
        Assert.AreEqual(8099130339328L, Day10.Lib.solve Day10.Tests.Data.myInput)
