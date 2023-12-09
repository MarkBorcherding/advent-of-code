import functools
import io
import re

input = """
Card 1: 41 48 83 86 17 | 83 86  6 31 17  9 48 53
Card 2: 13 32 20 16 61 | 61 30 68 82 17 32 24 19
Card 3:  1 21 53 59 44 | 69 82 63 72 16 21 14  1
Card 4: 41 92 73 84 69 | 59 84 76 51 58  5 54 83
Card 5: 87 83 26 28 32 | 88 30 70 12 93 22 82 36
Card 6: 31 18 13 56 72 | 74 77 10 23 35 67 36 11
""".strip()

f = open("./input.txt")
input = f.read().strip()


regex = re.compile(r"Card\s+\d+: ([^|]*) \|(.*)")
cards = list(map(lambda x: regex.findall(x), input.splitlines()))

numbers = re.compile(r'(\d+)')
scores = []
for [(winning_numbers, my_card)] in cards:
    a = set(numbers.findall(winning_numbers))
    b = set(numbers.findall(my_card))

    common = a.intersection(b)
    matches = len(common)

    scores.append(functools.reduce(lambda acc, cur: (1 if cur == 0 else acc * 2), range(0,matches), 0))






print(sum(scores))
