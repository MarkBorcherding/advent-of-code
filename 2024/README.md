# Advent of Code 2024 - AI-Solved Solutions

**This entire Advent of Code 2024 was solved by AI (Claude/Cascade).**

All 25 days, all 50 stars were obtained through AI-assisted programming. The human's role was limited to:

- Initiating the session
- Saying "Continue" to proceed to the next puzzle
- Approving command executions

## Prompts Used

The following prompts were used to solve all 25 days:

### Initial Prompt

```
do as many more as you can
```

### Continuation Prompts

```
Continue
```

That's it. The AI:

1. Fetched each day's puzzle description from adventofcode.com
2. Downloaded the puzzle input
3. Created sample test files
4. Implemented the solution in C#
5. Tested against sample and real input
6. Submitted answers via browser automation
7. Proceeded to the next puzzle

## Technical Stack

- **Language**: C# (.NET)
- **Project Structure**: `Days/DayXX/DayXX.cs` with `IPuzzle` interface
- **Testing**: `dotnet run -- --day X --part Y --example|--input`
- **Submission**: Browser automation via MCP (Model Context Protocol)

## Solutions Overview

| Day | Puzzle                 | Algorithm/Approach                            |
| --- | ---------------------- | --------------------------------------------- |
| 1   | Historian Hysteria     | Sorting, frequency counting                   |
| 2   | Red-Nosed Reports      | Sequence validation                           |
| 3   | Mull It Over           | Regex parsing                                 |
| 4   | Ceres Search           | 2D grid word search                           |
| 5   | Print Queue            | Topological sort                              |
| 6   | Guard Gallivant        | Grid simulation, cycle detection              |
| 7   | Bridge Repair          | Recursive expression evaluation               |
| 8   | Resonant Collinearity  | Coordinate geometry                           |
| 9   | Disk Fragmenter        | Array manipulation                            |
| 10  | Hoof It                | BFS/DFS pathfinding                           |
| 11  | Plutonian Pebbles      | Memoized recursion                            |
| 12  | Garden Groups          | Flood fill, perimeter calculation             |
| 13  | Claw Contraption       | Linear algebra (Cramer's rule)                |
| 14  | Restroom Redoubt       | Modular arithmetic, pattern detection         |
| 15  | Warehouse Woes         | Grid simulation with pushing                  |
| 16  | Reindeer Maze          | Dijkstra's algorithm with state               |
| 17  | Chronospatial Computer | VM simulation, reverse engineering            |
| 18  | RAM Run                | BFS shortest path, binary search              |
| 19  | Linen Layout           | Dynamic programming with memoization          |
| 20  | Race Condition         | BFS with "cheating" (Manhattan distance)      |
| 21  | Keypad Conundrum       | Recursive keypad robot control                |
| 22  | Monkey Market          | Pseudorandom sequences, sliding window        |
| 23  | LAN Party              | Graph triangles, Bron-Kerbosch max clique     |
| 24  | Crossed Wires          | Logic gate simulation, adder circuit analysis |
| 25  | Code Chronicle         | Lock/key fitting                              |

## Easter Eggs

Each puzzle contains a hidden easter egg (hover text). Here are all 25:

1. "We were THIS close to summoning the Alot of Location IDs!"
2. "I need to get one of these!"
3. "There's a spot reserved for Chief Historians between the green toboggans and the red toboggans."
4. "This part originally involved searching for something else, but this joke was too dumb to pass up."
5. "Specifically, the surely-stationary stationery stacks."
6. "This vulnerability was later fixed by having the guard always turn left instead."
7. "I think you mean '.'."
8. "They could have imitated delicious chocolate, but the mediocre chocolate is WAY easier to imitate."
9. "Bonus points if you make a cool animation of this process."
10. "i knew you would come back"
11. "No, they're not statues. Why do you ask?"
12. "I originally wanted to title this puzzle 'Fencepost Problem', but I was afraid someone would experience a fencepost problem."
13. "Half A presses are not allowed."
14. "This puzzle was originally going to be about Meteoroids, but we just had an arcade puzzle."
15. "Wesnoth players might solve their Warehouse Woes with a Warehouse Wose!"
16. "I would say it's like Reindeer Golf, but knowing Reindeer, it's almost certainly nothing like Reindeer Golf."
17. "The instruction does this using a little trampoline."
18. "Pun intended."
19. "It really seems like they've gathered a lot of magic into the towel colors."
20. "If we give away enough mutexes, maybe someone will use one of them to fix the race condition!"
21. "bum bum BUUUUUM"
22. "Some might say it would be... bananas."
23. "You caught me. I'm a giant nerd."
24. "ENHANCE"
25. `function knock() { yield no_response; }`

## Disclaimer

This repository demonstrates AI capabilities in competitive programming. The solutions were generated without human algorithmic input - the AI read the problem descriptions, designed the algorithms, wrote the code, debugged issues, and submitted answers autonomously.

**50/50 stars achieved** 🌟
