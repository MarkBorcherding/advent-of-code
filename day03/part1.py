import math
import re
from typing import Callable


input = """
467..114..
...*......
..35..633.
......#...
617*......
.....+.58.
..592.....
......755.
...$.*....
.664.598..
""".strip()


class Matrix():

    def __init__(self, width: int, height: int):
        self.data = []
        self.width = width
        self.height = height
        for row in range(0, height):
            self.data.append(['.'] * width)

    def rows(self):
        return iter(self.data)

    def columns(self):
            


    def to_s(self):
        return "\n".join(list(map(lambda c: ''.join(c), self.data)))

    def set(self, x: int, y: int, v: str):
        self.data[y][x] = v

    def get(self, x: int, y: int):
        return self.data[y][x]

    type Predicate = Callable[[str], bool]

    def find_coords(self, predicate: Predicate):
        found = []
        for y in range(0, self.height):
            for x in range(0, self.width):
                v = self.get(x, y)
                if predicate(v):
                    found.append((x, y))
        return found


class Schematic():

    def __init__(self, input: str):
        lines = input.splitlines()
        width = len(lines[0])
        height = len(lines)
        self.matrix = Matrix(width, height)

        for row in range(0, height):
            for col in range(0, width):
                self.matrix.set(col, row, lines[row][col])

    def symbols(self):
        regex = re.compile(r'[^0-9\.]')
        symbols = self.matrix.find_coords(lambda v: regex.match(v))
        return symbols

    def numbers(self):
        regex = re.compile(r'(\d+)')
        numbers = []

        return numbers

            




s = Schematic(input)

print(s.matrix.to_s())
print(s.symbols())
