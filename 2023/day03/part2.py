import io
import math
import re
from typing import List

import numpy as np

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

# In this schematic, there are two gears. The first is in the top left; it has part numbers 467 and 35, so its gear
# ratio is 16345.
#
# The second gear is in the lower right; its gear ratio is 451490. (The * adjacent to 617 is not a
# gear because it is only adjacent to one part number.) Adding up all of the gear ratios produces 467835.In this
# schematic, there are two gears. The first is in the top left; it has part numbers 467 and 35, so its gear ratio is
# 16345. The second gear is in the lower right; its gear ratio is 451490. (The * adjacent to 617 is not a gear
# because it is only adjacent to one part number.) Adding up all of the gear ratios produces 467835.

f = io.open('./input.txt')
input = f.read()

rows = input.splitlines()

number_regex = re.compile(r"([0-9]+)")


class Number:
    def __init__(self, row: int, start: int, end: int, value: int):
        self.row = row
        self.start = start
        self.end = end
        self.value = value
        self.boundary = range(start, end)
        self.points = set(map(lambda x: (self.row, x), self.boundary))

    def __str__(self):
        return f"(row: {self.row}, start:{self.start}, end:{self.end}, value:{self.value})"


numbers = []
for idx, line in enumerate(rows):
    for m in number_regex.finditer(line):
        number = Number(idx, m.start(), m.end(), int(m.group(0)))
        numbers += [number]


class Gear:
    def __init__(self, row: int, x: int):
        self.row = row
        self.x = x

    def ratio(self, nums: List[Number]) -> Number:
        x_axis = range(self.x - 1, self.x + 2)

        top = list(map(lambda x: (self.row - 1, x), x_axis))
        middle = list(map(lambda x: (self.row, x), x_axis))
        bottom = list(map(lambda x: (self.row + 1, x), x_axis))


        all = set(top + middle + bottom)

        matching_nums = []
        for num in nums:
            if len(num.points.intersection(all)) > 0:
                matching_nums.append(num.value)

        if len(matching_nums) == 2:
            return matching_nums[0] * matching_nums[1]
        else:
            return 0


gear_regex = re.compile(r"[*]")
ratios = []
for idx, line in enumerate(rows):
    for m in gear_regex.finditer(line):
        gear = Gear(idx, m.start())
        ratio = gear.ratio(numbers)
        ratios.append(ratio)

print(sum(ratios))
