namespace Day09.Tests

open NUnit.Framework


module Part01=
    
    [<SetUp>]
    let Setup () =
        ()
            
    let invalid = [| 127 |]

    [<Test>]
    let Test1 () =
        let valid = (List.take 5 Data.example)
        let rest = (List.skip 5 Data.example)
        let actualInvalid = Day09.Part1.validate  valid rest
        CollectionAssert.AreEquivalent(invalid, actualInvalid)

    [<Test>]
    let MyInput () =
        let valid = (List.take 25 Data.myInput)
        let rest = (List.skip 25 Data.myInput)
        let actualInvalid = Day09.Part1.validate  valid rest
        CollectionAssert.AreEquivalent([| 104054607 |], actualInvalid)
