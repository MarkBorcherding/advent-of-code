import { pipe, map, split, tap, range, min, max } from "@lib/f";

/** All possible directions */
const Direction = {
  Up: "U",
  Down: "D",
  Left: "L",
  Right: "R"
} as const

/** A list of the possible values that we could parse */
const Directions = Object.values(Direction)

/** The direction of the wire placement */
type Direction = typeof Direction[keyof typeof Direction]

type Length = number

/** A single instruction on the list of instructions for a single wire */
type WireCommandInstruction = [Direction, Length]

/** All the instructions for a single wire */
type WireSchematic = WireCommandInstruction[]

/** A Readonly only hashmap */
type Map<T> = Readonly<{ [index: string]: T }>

/** How wire segments appear on the circuit board */
type WireSegment = "|" | "-" | "+" | undefined

/** A list of all placed wires */
type CircuitBoard = Map<Map<WireSegment>>

/** A position in x,y coordinates */
type Position = [number, number]

/** Split a single string into unparesed command instructions */
const splitCommands = split(",")

/** Split a single instruction into direction and length */
const splitIntoParts = ([direction, ...length]: string): [string, string] =>
  [direction, length.join('')]

/** Type guard against any possible string when we want only a Direction */
const validDirection = (d: string): d is Direction => Directions.indexOf(d as any) > -1

/** Change the [string, string] potentiation command into a properly typed command */
const validateParts = ([direction, length]: [string, string]): [Direction, number] => {
  if (!validDirection(direction)) { throw new Error("Unknown direction: " + direction) }
  return [direction, parseInt(length)]
}

/** Change a single string into a WireSchematic */
const parseIntoWire = pipe(
  splitCommands,
  map(
    pipe(
      splitIntoParts,
      validateParts)))

/** Return the new position when moving a specific direction from a starting point */
const move = ([x, y]: Position, direction: Direction): Position => {
  switch (direction) {
    case "D": return [x, y - 1];
    case "U": return [x, y + 1];
    case "R": return [x + 1, y];
    case "L": return [x - 1, y];
  }
}

/** Change the value of a single position in a 2d map  */
const set = ([x, y]: Position, s: string, board: CircuitBoard): CircuitBoard => {
  if (board[x] === undefined) return { ...board, [x]: { [y]: s } }
  return { ...board, [x]: { ...board[x], [y]: s } }
}

/** Determine if direction is up or down to help layout the wire */
const isVertical = (d: Direction) => d === "U" || d === "D"

/** Add a single wire segement to the board, starting at a specific position  */
const placeSegment = ([board, [x, y]]: [CircuitBoard, Position], [direction, length]: WireCommandInstruction): [CircuitBoard, Position] => {
  const positions = range(length).reduce(([head, ...rest]: Position[], curr) => {
    return [move(head, direction), head, ...rest]
  }, [[x, y]])

  const newBoard = positions.reduce((board, [x, y]) => {
    if(x === 0 && y === 0) return set([0,0], "O", board)
    switch (board[x] && board[x][y]) {
      case undefined: return set([x, y], isVertical(direction) ? "-" : "|", board)
      default: return set([x, y], "+", board)
    }
  }, board)

  const [newPos, ...rest] = positions
  return [newBoard, newPos]
}

/** Add all the segments for a wire starting at the origin */
const layoutWire = ((board: CircuitBoard, wire: WireSchematic): CircuitBoard => {
  const [b] = wire.reduce(placeSegment, [board, [0, 0]])
  return b
})

/** Determin the bounds of the circuit board */
const bounds = (board: CircuitBoard) => {
  const allX = Object.keys(board).map(parseInt)
  const allY = Object.values(board).map(column => Object.keys(column)).reduce((acc, curr) => [...curr, ...acc], []).map(parseInt)

  const minX = min(allX)
  const maxX = max(allX)
  const minY = min(allY)
  const maxY = max(allY)
  return [minX, maxX, minY, maxY]
}

/** Returns true if we are at the origin */
const isOrigin = ([x,y]: Position) => x === 0 && y === 0

/** Create a visual representation of the circuit board */
const display = (board: CircuitBoard) => {
  const [minX, maxX, minY, maxY] = bounds(board)
  const yRange = range(maxY - minY, minY)
  const xRange = range(maxX - minX, minX)
  return xRange.map(x =>
    yRange.map(y =>
      isOrigin([x,y]) ? 'O' : board[x] && board[x][y] || ' ' 
    ).join("")
  ).join("\n")
}

/** Calculate the closest intersect */
const calculate = (input: string[]) => {
  const wires = map(
    parseIntoWire,
  )(input)

  const circuitBoard = wires.reduce(layoutWire, {})

  console.log(display(circuitBoard))

  return 1;
}

export default calculate