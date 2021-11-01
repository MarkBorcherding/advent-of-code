namespace Day09.Tests

open NUnit.Framework


module Part2=
    
    [<SetUp>]
    let Setup () =
        ()
            
    let invalid = [| 127 |]

    [<Test>]
    let Example () =
        let  actual = Day09.Part2.encryptionWeakness Data.example 127L
        Assert.AreEqual(Some(62L), actual)

    [<Test>]
    let MyInput () =
        let  actual = Day09.Part2.encryptionWeakness Data.myInput 104054607L
        Assert.AreEqual(Some(13935797L), actual)
