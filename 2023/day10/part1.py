from enum import Enum
from math import floor
from typing import Callable
from rich import print


input = """
.....
.S-7.
.|.|.
.L-J.
.....
""".strip()

map = []


class Direction(Enum):
    NORTH = 'N'
    SOUTH = 'S'
    EAST = 'E'
    WEST = 'W'


step_text = {
    Direction.EAST: "[blue dim]→[/blue dim]",
    Direction.WEST: "[green dim]←[/green dim]",
    Direction.NORTH: "[yellow dim]↑[/yellow dim]",
    Direction.SOUTH: "[red dim]↓[/red dim]"
}


class Matrix:
    def __init__(self, input: str):
        lines = input.split("\n")

        self.height = len(lines)
        self.width = len(lines[0])

        self.x_range = range(0, self.width)
        self.y_range = range(0, self.height)

        self.cells = []
        for index, line in enumerate(lines):

            self.cells.extend(line)
            if "S" in line:
                self.starting_coords = (line.index("S"),  index)
                self.starting_index = self.index(self.starting_coords)

        self.steps = [x for x in self.cells]

    def index(self, coord: tuple[int, int]):
        (x, y) = coord
        return x + y * self.width

    def coord(self, index: int):
        return (index % self.height, floor(index / self.height))

    def item(self, coord: tuple[int, int]):
        return self.cells[self.index(coord)]

    def neighors(self, coord: tuple[int, int]):
        (x, y) = coord
        possible = [
            (x, y - 1),
            (x - 1, y),
            (x + 1, y),
            (x, y + 1)
        ]

        return list(filter(lambda x: x[0] in self.x_range and x[1] in self.y_range, possible))

    def direction(from_coord: tuple[int, int], to_coord: tuple[int, int]):
        if from_coord[0] < to_coord[0]:
            return Direction.EAST
        if from_coord[0] > to_coord[0]:
            return Direction.WEST
        if from_coord[1] < to_coord[1]:
            return Direction.SOUTH
        if from_coord[1] > to_coord[1]:
            return Direction.NORTH

    def does_connect(self, from_coord: tuple[int, int], to_coord: tuple[int, int]) -> bool:
        from_cell = self.item(from_coord)
        to_cell = self.item(to_coord)
        direction = Matrix.direction(from_coord, to_coord)

        match direction:
            case Direction.EAST:
                return from_cell in "S-FL" and to_cell in "-J7"
            case Direction.WEST:
                return from_cell in "S-J7" and to_cell in "-LF"
            case Direction.NORTH:
                return from_cell in "S|JL" and to_cell in "|7F"
            case Direction.SOUTH:
                return from_cell in "S|7F" and to_cell in "|LJ"
            case _:
                return False

    def print(self, list):

        for row in range(0, self.height):
            start = row*self.width
            end = start + self.width
            t = "".join(list[start:end])
            print(f"[white]{t}[/white]")

    def longest_path(self):
        start_neighors = self.neighors(self.starting_coords)
        current_cells = list(filter(lambda x: self.does_connect(
            self.starting_coords, x), start_neighors))

        steps = 1

        previous_cells = [self.starting_coords, self.starting_coords]
        for cell in current_cells:
            dir = Matrix.direction(self.starting_coords, cell)
            self.steps[self.index(cell)] = step_text[dir]

        while current_cells[0] != current_cells[1]:
            next_cells = []
            steps += 1
            for prev, curr in zip(previous_cells, current_cells):
                possible_neighbors = self.neighors(curr)
                possible_neighbors.remove(prev)
                connected_neighbor = list(
                    filter(lambda x: self.does_connect(curr, x), possible_neighbors))
                next_step = connected_neighbor[0]
                next_cells.append(next_step)

                dir = Matrix.direction(curr, next_step)
                self.steps[self.index(curr)] = step_text[dir]
            previous_cells = current_cells
            current_cells = next_cells

        dir = Matrix.direction(previous_cells[0], current_cells[0])
        self.steps[self.index(current_cells[0])] = step_text[dir]

        return steps


input = """
...........
.S-------7.
.|F-----7|.
.||.....||.
.||.....||.
.|L-7.F-J|.
.|..|.|..|.
.L--J.L--J.
...........
""".strip()

f = open('input.txt', 'r')
# input = f.read().strip()
tube_map = Matrix(input)

print(tube_map.longest_path())


tube_walls = list(step_text.values()) + ["S"]
print("preclean")
print(tube_map.print(tube_map.steps))
for row in range(0, tube_map.height):
    collided_with_tube_yet = False
    for col in range(0, tube_map.width):
        cell = tube_map.steps[tube_map.index((col, row))]
        if cell in tube_walls:
            collided_with_tube_yet = True
        elif not collided_with_tube_yet:
            tube_map.steps[tube_map.index((col, row))] = " "

    collided_with_tube_yet = False
    for col in range(tube_map.width - 1, 0, -1):
        cell = tube_map.steps[tube_map.index((col, row))]
        if cell in tube_walls:
            collided_with_tube_yet = True
        elif not collided_with_tube_yet:
            tube_map.steps[tube_map.index((col, row))] = " "

for col in range(0, tube_map.width):
    collided_with_tube_yet = False
    for row in range(0, tube_map.height):
        cell = tube_map.steps[tube_map.index((col, row))]
        if cell in tube_walls:
            collided_with_tube_yet = True
        elif not collided_with_tube_yet:
            tube_map.steps[tube_map.index((col, row))] = " "

    collided_with_tube_yet = False
    for row in range(tube_map.height - 1, 0, -1):
        cell = tube_map.steps[tube_map.index((col, row))]
        if cell in tube_walls:
            collided_with_tube_yet = True
        elif not collided_with_tube_yet:
            tube_map.steps[tube_map.index((col, row))] = " "


print(tube_map.print(tube_map.steps))
print(len(list(filter(lambda x: x in "|-FJL7.", tube_map.steps))))
