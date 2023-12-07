import io
import math
import re

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
f = io.open('./input.txt')
input = f.read()

rows = input.splitlines()

number_regex = re.compile(r"([0-9]+)")

symbols = set()
symbol_regex = re.compile(r"[^0-9.]")

for idx, row in enumerate(rows):
    s = set(list(map(lambda x: (idx, x.start()), symbol_regex.finditer(row))))
    symbols = symbols | s

def neighbors(row: int, start: int, end: int) -> set:
    width = (range(start - 1, end + 1 ))

    n = set()
    for x in width:
        n.add((row - 1, x))
        n.add((row + 1, x))

    n.add((row, min(width)))
    n.add((row, max(width)))
    return n


hits = []
for idx, row in enumerate(rows):
    for match in number_regex.finditer(row):
        (start, end) = match.span()
        n = neighbors(idx, start, end)
        hit = len(symbols.intersection(n))
        s = int(match.group(0))
        if hit > 0:
            print(f'part: {s}')
            hits.append(s)
        else:
            print(f"not part {s}")




print(sum(hits))
