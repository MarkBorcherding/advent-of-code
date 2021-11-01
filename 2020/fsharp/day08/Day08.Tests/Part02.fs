
namespace Day08.Tests

module Part02=

    open NUnit.Framework

    [<SetUp>]
    let Setup () =
        ()

    [<Test>]
    let Example () =
        Assert.AreEqual((Day08.Part1.ResultType.Finish, 8), (Day08.Part1.solve Data.exampleTerminating) )

    [<Test>]
    let MyInput () =
        Assert.AreEqual((Day08.Part1.ResultType.Finish, 1563), (Day08.Part1.solve Data.myInput) )
