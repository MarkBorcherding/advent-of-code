from typing import Tuple
from rich import print

input = []

input.append("""
...#......
.......#..
#.........
..........
......#...
.#........
.........#
..........
.......#..
#...#.....""".strip())

f = open("input.txt", "r")
input.append(f.read().strip())


class Matrix:
    def __init__(self, input: str):
        lines = input.split("\n")

        self.width = len(lines[0])
        self.height = len(lines)

        self.cells = "".join(lines)

    def rows(self) -> str:
        return "\n".join([self.cells[self.index(0, row):self.index(self.width, row)] for row in range(self.height)])

    def index(self, x: int, y: int) -> int:
        return y * self.width + x

    def coord(self, i: int) -> tuple[int, int]:
        return (i % self.width, i // self.width)

    def set(self, coord: tuple[int, int], char: str):
        index = self.index(coord[0], coord[1])
        self.cells = self.cells[:index] + char + self.cells[index+1:]

    def __str__(self) -> str:
        output = ""

        for y in range(self.height):
            for x in range(self.width):
                t = self.cells[self.index(x, y)]
                if t == "#":
                    output += f"[white]{t}[/white]"
                elif t == ".":
                    output += f"[dim white]{t}[/dim white]"
                else:
                    output += f"[dim blue]{t}[/dim blue]"

            output += "\n"

        return output

    def is_row_empty(self, row: int) -> bool:
        return all([self.cells[self.index(col, row)] == "." for col in range(m.width)])

    def is_col_empty(self, col: int) -> bool:
        return all([self.cells[self.index(col, row)] == "." for row in range(m.height)])

    def insert_row(self, row: int, char='.'):
        head_size = (row * self.width)
        tail_size = self.height * self.width - head_size
        head = self.cells[0:head_size]
        new = char * self.width
        tail = self.cells[-tail_size:]
        self.cells = head + new + tail
        self.height += 1

    def insert_col(self, col: int, char='.'):
        new_cells = ""
        for row in range(self.height):
            start = self.index(0, row)
            end = self.index(self.width, row)

            row_cells = self.cells[start:end]
            new_cells += row_cells[:col] + char + row_cells[col:]
        self.cells = "".join(new_cells)
        self.width += 1

    def find(self, char='#') -> Tuple[int, int]:
        indexes = [x for x in range(len(self.cells)) if self.cells[x] == char]
        coords = [self.coord(i) for i in indexes]
        return coords

    def distance_between(self, a: tuple[int, int], b: tuple[int, int]) -> int:
        return abs(a[0] - b[0]) + abs(a[1] - b[1])


def expand_universe(m: Matrix) -> Matrix:
    new_m = Matrix(m.rows())
    added_cols = 0
    for col in range(m.width):
        if m.is_col_empty(col):
            new_m.insert_col(col + 1 + added_cols, '|')
            added_cols += 1

    added_rows = 0
    for row in range(m.height):
        if m.is_row_empty(row):
            new_m.insert_row(row + 1 + added_rows, '-')
            added_rows += 1
    return new_m


def find_nearest_universe(a: tuple[int, int], universes: list[tuple[int, int]]) -> tuple[tuple[int, int], int]:
    nearest = None
    dist = None
    for b in universes:
        if b == a:
            continue
        distance = abs(b[0] - a[0]) + abs(b[1] - a[1])
        if dist is None or distance < dist:
            nearest = b
            dist = distance
    return (nearest, dist)


def find_nearest_universes(universes: list[tuple[int, int]]) -> list[tuple[tuple[int, int], int]]:
    nearest_universes = []
    for universe in universes:
        nearest_universe = find_nearest_universe(universe, universes)
        nearest_universes.append(nearest_universe)
    return nearest_universes


def distance_between_all(m: Matrix, universes: list[tuple[int, int]]) -> int:
    pairs = {}
    for a in universes:
        for b in universes:
            key = tuple(sorted([a, b]))

            if a == b:
                continue

            if pairs.get(key) is not None:
                continue

            pairs[key] = m.distance_between(a, b)

    return [pairs[k] for k in pairs.keys()]


m = Matrix(input[1])


print(f"Initial:\n{m}")
expanded = expand_universe(m)


print(f"\nExpanded:\n {expanded}")
universes = expanded.find("#")

print(f"Universes: {universes}")
all_distances = distance_between_all(expanded, universes)

sum = sum(all_distances)

print(f"\n{expanded}")

print(f"\nTotal: {sum}\nCount: {len(all_distances)}")
