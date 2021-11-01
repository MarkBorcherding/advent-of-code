namespace Day08.Tests

open Day08

module Tests=

    open NUnit.Framework

    [<SetUp>]
    let Setup () =
        ()

    [<Test>]
    let Example () =
        Assert.AreEqual((Part1.ResultType.Loop, 5), (Part1.run Data.example) )

    [<Test>]
    let MyInput () =
        Assert.AreEqual((Part1.ResultType.Loop, 1563), (Part1.run Data.myInput) )
