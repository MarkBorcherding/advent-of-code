namespace Day13

open Aoc.Lib.Utils
open FSharp.Collections.ParallelSeq

module Lib=

    type Arrival = Arrival of int
    type Bus = Bus of int

    type BusLine =
        | InService of Bus
        | OutOfService

    type Input = {
        arrival: Arrival;
        buses: BusLine list;
    }

    let parse (s: string):Input =
        let lines = s.Split("\n") |> Array.map (fun s -> s.Trim())
        let arrival = lines.[0] |> int
        let buses = lines.[1].Split(",") |>
                        Array.map (fun s -> s.Trim()) |>
                        Array.map (fun s -> match s with
                                                | "x" -> OutOfService
                                                | s -> ( s |> int |> Bus |> InService)) |>
                        List.ofArray
        
        { arrival = Arrival arrival; buses = buses }


    let onlyInService busLine = match busLine with 
                                        | OutOfService -> None
                                        | InService l -> Some l;

    let nextArrival (Arrival time) (Bus bus) =
         
        let lastArrival = ((time / bus) * bus)
        lastArrival + bus
        
    let quickest (input: Input) =
        let (Arrival arrival) = input.arrival
        let linesInService = input.buses |> List.choose onlyInService
        let nextPickups = linesInService |> List.map (nextArrival input.arrival)
        List.zip linesInService nextPickups  |>
            tap (printfn "%A") |>
            List.minBy (fun (_, r) -> r) |>
            (fun ((Bus b), r) -> b * (r - arrival))
            
            
    let doesArrive (Arrival time) (Bus bus) = (time) % bus = 0
            
    let starsAlign s =
        let input = sprintf "0\n%s" s |> parse
        let all = input.buses |>
                    List.mapi (fun index b -> match b with
                                                | OutOfService -> None                                
                                                | InService bus -> Some (index, bus)) |>
                    List.choose (id) |>
                    tap (printfn "%A") |>
                    List.map (fun (offset, Bus bus) time -> doesArrive (Arrival (time + offset)) (Bus bus))
                    
        let jump = match input.buses.Head with
                        | OutOfService -> failwith "Didn't expect this"
                        | InService (Bus b) -> b
        
        let rec f (time:int) jump matches =
            let max = matches |> List.length
            let arriving = matches |> List.takeWhile (fun f -> f time) |> List.length
            if arriving = max  then
                time
            else
                f (time + jump) jump matches
                
                
        let possibles =
            seq { for i in 1 .. System.Int32.MaxValue do i * jump } 
            
            
        possibles |>
            PSeq.map (fun t -> if PSeq.forall (fun f -> f t) all then failwithf "BOOOOOM %A" t else None) |>
            PSeq.choose (id)
        
        
                
        
                    
                                            