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


class Card:
    line_regex = re.compile(r"Card\s+\d+: ([^|]*) \|(.*)")
    numbers_regex = re.compile(r'(\d+)')

    @staticmethod
    def from_line(line: str):
        [(winning, mine)] = Card.line_regex.findall(line)
        return Card(winning, mine)

    def __init__(self, winning_numbers, my_numbers):
        self.winning_numbers = set(Card.numbers_regex.findall(winning_numbers))
        self.my_numbers = set(Card.numbers_regex.findall(my_numbers))
        self.matches = self.winning_numbers.intersection(self.my_numbers)


cards = list(map(lambda x: Card.from_line(x), input.splitlines()))

totals: dict[int, int] = {}


def tally(index: int):
    totals[index] = totals.get(index, 0) + 1


def print_tallies():
    for k, v in totals.items():
        print(k + 1, v)


def score(index: int, depth=0):
    copies = len(cards[index].matches)

    if depth == 0:
        tally(index)

    next_cards = range(index + 1, index + 1 + copies)

    for c in next_cards:
        tally(c)
        score(c, depth + 1)


for idx, card in enumerate(cards):
    score(idx)

total = 0
for k, v in totals.items():
    total += v

print(total)
