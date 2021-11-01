namespace Day16
open Day16.Lib
open NUnit.Framework


module Tests =
    
    module Part1 =
        let exampleInput =
                "class: 1-3 or 5-7
                 row: 6-11 or 33-44
                 seat: 13-40 or 45-50

                 your ticket:
                 7,1,14

                 nearby tickets:
                 7,3,47
                 40,4,50
                 55,2,20
                 38,6,12" 

        [<SetUp>]
        let Setup () =
            ()

        [<Test>]
        let Parse () =
            
            let actualInput = exampleInput |> Parser.parseInput
            
            let (expectedInput: Lib.Input) = {
                rules = [
                    { name = "class"; validRanges = [ seq {1..3}; seq { 5..7 } ] }
                    { name = "row"; validRanges = [ seq {6..11}; seq {33..44} ] }
                    { name = "seat"; validRanges = [ seq {13..40}; seq {45..50} ] }
                ]
                yourTicket = [ 7; 1; 14 ];
                nearbyTickets = [
                    [ 7; 3; 47]
                    [40; 4; 50]
                    [55; 2; 20]
                    [38; 6; 12]
                ];
            } 
            
            Assert.AreEqual(expectedInput.yourTicket, actualInput.yourTicket)
            Assert.AreEqual(expectedInput.nearbyTickets, actualInput.nearbyTickets)
            
        [<Test>]
        let InvalidValues_example () =
           let expected = [ 4;  55;  12; ]
           let input = exampleInput |> Parser.parseInput
           let actual = input.nearbyTickets |> TicketList.invalidTicketValues input.rules
           CollectionAssert.AreEquivalent(expected , actual)
           Assert.AreEqual(expected |> List.sum, actual |> List.sum)
        [<Test>]
        
        let InvalidValues_myInput () =
           let input = Data.myInput |> Parser.parseInput
           let actual = input.nearbyTickets |> TicketList.invalidTicketValues input.rules
           Assert.AreEqual(30869 , actual |> List.sum)
           
           
           
