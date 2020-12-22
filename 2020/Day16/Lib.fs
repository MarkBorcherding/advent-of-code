namespace Day16

open Aoc.Lib.String;

module Lib =
    
    type Range = int seq
    module Range =
        let ofString s =
            match s |> split "-" |> Array.map int with
                | [| min; max |] -> seq {min .. max}
                | _ -> failwithf "Invalid range %s" s
            
    
    type Rule = {
        name: string
        validRanges: Range list
     }
    
     module Rule =
         ///  seat: 13-40 or 45-50
        let ofString s =
            
            let (name,rangePart) = match s |> split ": " with
                                            | [| name; rangePart |] -> (name, rangePart)
                                            | _ -> failwithf "Invalid rule format: %s" s
                                            
            let ranges = rangePart |> split " or " |> Array.map Range.ofString |> List.ofArray
            
            { name = name; validRanges = ranges }
        
        let validate (value: int) (rule: Rule) =
           rule.validRanges |> List.exists (fun r -> Seq.contains value r)
           
            
    type RuleList = Rule list
    module RuleList =
        let validate (rules: RuleList) (i: int) = 
            List.exists (Rule.validate i) rules
            
    
    type Ticket = int list
    module Ticket =
        let ofString  = split "," >> Array.map (int) >> List.ofArray
        
        let validate (rules: RuleList) (ticket:Ticket) =
           List.forall (RuleList.validate rules) ticket
                
        let invalidValues (rules: RuleList) (ticket: Ticket) =
           let (_, invalid) = List.partition (RuleList.validate rules) ticket
           invalid
           
                
    type TicketList = Ticket list
    module TicketList =
        let groupByValid rules tickets =
                List.partition (Ticket.validate rules) tickets
                
        let validTickets rules tickets =
            let (valid, _) = groupByValid rules tickets
            valid
            
        let invalidTicketValues rules tickets =
            let (_, invalid) =  groupByValid rules tickets
            invalid |> List.map (Ticket.invalidValues rules) |> List.concat
            
        
    
    type Input = {
        rules: RuleList
        yourTicket: Ticket
        nearbyTickets: TicketList
    }
    
     
