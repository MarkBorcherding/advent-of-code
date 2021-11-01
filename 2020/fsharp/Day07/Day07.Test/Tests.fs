module Day07.Test

open NUnit.Framework

[<SetUp>]
let Setup () =
    ()

[<Test>]
let Example () =
    let expected = 4
    let actual =  Day07.Luggage.count Day07.Data.example "shiny gold"
    Assert.AreEqual(expected, actual)
    
[<Test>]
let MyInput () =
    let actual =  Day07.Luggage.count Day07.Data.myInput "shiny gold"
    Assert.Less(actual, 1247) // guess 1
    Assert.AreEqual(370, actual) // correct guess
