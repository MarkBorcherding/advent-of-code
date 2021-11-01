namespace Day16

open Aoc.Lib.String
open Day16.Lib

module Parser =

     let private notEmptyString s =
         s <> ""
    
     let parseInput s : Input =
        let lines = s |> split "\n" |> Array.map trim
        
        let ruleLines = lines |>
                            Array.takeWhile notEmptyString
                            
        let ticketLine = lines |>
                            Array.skipWhile notEmptyString |>
                            Array.skip 2 |>
                            Array.head
                            
                            
        let nearbyTicketLines = lines |> Array.skipWhile notEmptyString |> Array.skip 5
                                    
        {
            rules = ruleLines |> Array.map Rule.ofString |> List.ofArray
            yourTicket = ticketLine |> Ticket.ofString
            nearbyTickets = nearbyTicketLines |> Array.map Ticket.ofString |> List.ofArray
        }

