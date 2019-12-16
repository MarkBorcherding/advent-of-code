import { Map } from "immutable";
import { pipe, map, split, tap, range, min, max } from "@lib/f";

/** All possible directions */
const Direction = {
  Up: "U",
  Down: "D",
  Left: "L",
  Right: "R"
} as const;

/** A list of the possible values that we could parse */
const Directions = Object.values(Direction);

/** The direction of the wire placement */
type Direction = typeof Direction[keyof typeof Direction];

type Length = number;

/** A single instruction on the list of instructions for a single wire */
type WireCommandInstruction = [Direction, Length];

/** All the instructions for a single wire */
type WireSchematic = WireCommandInstruction[];

/** How wire segments appear on the circuit board */
type WireSegment = "|" | "-" | "+" | "O";

/** A list of all placed wires */
type CircuitBoard = Map<number, Map<number, WireSegment>>;

/** A position in x,y coordinates */
type Position = Readonly<[number, number]>;

/** Split a single string into un-parsed command instructions */
const splitCommands = split(",");

/** Split a single instruction into direction and length */
const splitIntoParts = ([direction, ...length]: string): [string, string] => [
  direction,
  length.join("")
];

/** Type guard against any possible string when we want only a Direction */
const validDirection = (d: string): d is Direction =>
  Directions.indexOf(d as any) > -1;

/** Change the [string, string] potentiation command into a properly typed command */
const validateParts = ([direction, length]: [string, string]): [
  Direction,
  number
] => {
  if (!validDirection(direction)) {
    throw new Error("Unknown direction: " + direction);
  }
  return [direction, parseInt(length)];
};

/** Change a single string into a WireSchematic */
const parseIntoWire = pipe(
  splitCommands,
  map(pipe(splitIntoParts, validateParts))
);

/** Return the new position when moving a specific direction from a starting point */
const move = ([x, y]: Position, direction: Direction): Position => {
  switch (direction) {
    case "D":
      return [x, y - 1];
    case "U":
      return [x, y + 1];
    case "R":
      return [x + 1, y];
    case "L":
      return [x - 1, y];
  }
};

/** Change the value of a single position in a 2d map  */
const set = (
  [x, y]: Position,
  s: WireSegment,
  board: CircuitBoard
): CircuitBoard => {
  try {
    const rowX = board.get(x);
    return rowX ? board.set(x, rowX.set(y, s)) : board.set(x, Map([[y, s]]));
  } catch (e) {
    console.error(e);
    throw e;
  }
};

/** Get the wire segment at a position */
const get = ([x, y]: Position) => (board: CircuitBoard) => {
  try {
    const rowX = board.get(x);
    return rowX ? rowX.get(y) : undefined;
  } catch (e) {
    console.error(e);
    throw e;
  }
};

/** Determine if direction is up or down to help layout the wire */
const isVertical = (d: Direction) => d === "U" || d === "D";

/** The display of a wire for the given direction */
const wireForDirection = (d: Direction) => (isVertical(d) ? "-" : "|");

/** Add a single wire segment to the board, starting at a specific position  */
const placeSegment = (
  [board, startingPos]: [CircuitBoard, Position],
  [direction, length]: WireCommandInstruction
): [CircuitBoard, Position] => {
  const rest = range(length);
  const positions = rest.reduce(([head, ...rest]) => {
    return head === undefined
      ? [move(startingPos, direction)]
      : [move(head, direction), head, ...rest];
  }, [] as Position[]);

  const newBoard = positions.reduce((board, [x, y]) => {
    if (x === 0 && y === 0) return set([0, 0], "O", board);
    switch (get([x, y])(board)) {
      case undefined:
        return set([x, y], wireForDirection(direction), board);
      case "O":
        return board;
      default:
        return set([x, y], "+", board);
    }
  }, board);

  const [newPos] = positions;
  return [newBoard, newPos];
};

/** Add all the segments for a wire starting at the origin */
const layoutWire = (board: CircuitBoard, wire: WireSchematic): CircuitBoard => {
  const [b] = wire.reduce(placeSegment, [board, origin]);
  return b;
};

/** Determine the bounds of the circuit board */
const bounds = (board: CircuitBoard) => {
  const allX = Array.from(board.keys());
  const allY = allX.reduce((acc: number[], currX: number) => {
    const col = board.get(currX);
    if (col === undefined) return acc;
    const colY = Array.from(col.keys());
    return [...acc, ...colY];
  }, []);

  const minX = min(allX);
  const maxX = max(allX);
  const minY = min(allY);
  const maxY = max(allY);
  const b = [minX, maxX, minY, maxY];
  return b;
};

/** The starting point for all circuit board */
const EmptyCircuitBoard: CircuitBoard = Map([[0, Map([[0, "O"]])]]);

/** The origin coordinates */
const origin: Position = [0, 0] as const;

/** since we are storing the x axis first we need to rotate the drawing */
const swap = (s: WireSegment) => {
  switch (s) {
    case "|":
      return "-";
    case "-":
      return "|";
    default:
      return s;
  }
};

/** Create a visual representation of the circuit board */
export const display = (board: CircuitBoard) => {
  const [minX, maxX, minY, maxY] = bounds(board);
  const yRange = range(maxY - minY + 1, minY);
  const xRange = range(maxX - minX + 1, minX);
  const columns = yRange.map(y =>
    xRange
      .map(x => {
        const currY = get([x, y])(board);
        return currY === undefined ? "." : swap(currY);
      })
      .join("")
  );
  return columns.join("\n");
};

const filter = (f: (segment: WireSegment) => boolean) => (
  board: CircuitBoard
): Position[] =>
  board.reduce(
    (xAcc, curr, x) =>
      curr.reduce(
        (yAcc, seg, y) => (f(seg) ? [...yAcc, [x, y] as Position] : yAcc),
        xAcc
      ),
    [] as Position[]
  );

const allIntersections = filter(s => s === "+");

const manhattanDistance = ([x, y]: Position) => Math.abs(x) + Math.abs(y);

const closestIntersection = (board: CircuitBoard) => {
  return allIntersections(board).reduce((acc, cur) => {
    if (acc === undefined) return cur;
    if (manhattanDistance(cur) < manhattanDistance(acc)) return cur;
    return acc;
  });
};

/** Calculate the closest intersect */
const calculate = (input: string[]): [number, CircuitBoard] => {
  const wires = map(parseIntoWire)(input);
  const circuitBoard = wires.reduce(layoutWire, EmptyCircuitBoard);
  const distance = manhattanDistance(closestIntersection(circuitBoard));
  return [distance, circuitBoard];
};

export default calculate;
