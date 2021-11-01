namespace Day10


module Lib =
    
    type Node = int
    type Edge = (Node * Node)
    type Graph = Map<Node, Node Set>
    type Path = Node list
    type Count = Map<Node,int64>
    

    exception MissingNodeError of string

    let connecting head tail =
        tail |> 
        List.takeWhile ((<=) (head - 3)) |>
        Set.ofList

    let rec groupByConnecting (nodes:Node list): (Node * Node Set) list =
        match nodes with
            | [] -> []
            | head :: tail -> (head, connecting head tail) :: groupByConnecting tail
                
            
    let addChildPaths node childNode count =
            let childPaths = Map.find childNode count
            count.Change(node, (fun prev ->
                match prev with
                    | None -> Some(childPaths)
                    | Some (p) -> Some(childPaths + p )
                ))
            
    
    let rec countPaths (graph:Graph) (startingAt: Node) (count: Count):  Count=
        
        let countChildPaths (childNode:Node) (counts:Count) =
            match counts.TryFind childNode with
                | None -> countPaths graph childNode counts
                | Some _ -> counts
            
        match graph.TryFind startingAt with
            | None -> raise (MissingNodeError "Where did this node come from?")
            | Some s when s.IsEmpty -> count.Add (startingAt, 1L)
            | Some connectingNodes ->
                    connectingNodes |> 
                        Set.fold (
                            fun acc childNode ->
                                acc |>
                                    countChildPaths childNode |>
                                    addChildPaths startingAt childNode
                        ) count
                        
                    
    let solve numbers =
        let nodes = (0 :: (numbers |> List.max |> (+) 3) :: numbers) 
        let graph:Graph =
                nodes |>
                List.sortDescending |>
                groupByConnecting |>
                Map.ofList
                
        let max = List.max nodes
        let paths = countPaths graph max Map.empty
        paths |> Map.find max
                        
                        
                
                        
                        
                    
                    
            
            

