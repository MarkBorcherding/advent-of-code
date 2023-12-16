import math
from functools import reduce
import itertools
import re

from rich import print


input = """
RL

AAA = (BBB, CCC)
BBB = (DDD, EEE)
CCC = (ZZZ, GGG)
DDD = (DDD, DDD)
EEE = (EEE, EEE)
GGG = (GGG, GGG)
ZZZ = (ZZZ, ZZZ)""".strip()


input = """
LLR

AAA = (BBB, BBB)
BBB = (AAA, ZZZ)
ZZZ = (ZZZ, ZZZ)
""".strip()

input = """
LR

11A = (11B, XXX)
11B = (XXX, 11Z)
11Z = (11B, XXX)
22A = (22B, XXX)
22B = (22C, 22C)
22C = (22Z, 22Z)
22Z = (22B, 22B)
XXX = (XXX, XXX)""".strip()

file = open("input.txt", "r")
input = file.read().strip()

[directions, raw_map] = input.split("\n\n")

number_regex = re.compile(r"([A-Z0-9]+)")


def parse_line(acc, line):
    [name, children] = line.split(" = ")
    [left, right] = number_regex.findall(children)
    acc[name] = (left, right)
    return acc


parsed_map = reduce(parse_line, raw_map.split("\n"), {})

starting_locations = list(filter(lambda x: x.endswith('A'), parsed_map.keys()))

all_steps = []
print(starting_locations)
for starting_location in starting_locations:
    steps = 0
    directions_iterator = itertools.cycle(directions)
    location = starting_location
    print(location)
    while not location.endswith('Z'):
        steps += 1
        location = parsed_map[location][next(directions_iterator) == "R"]

    all_steps.append(steps)

print(f"steps {all_steps}")


def least_common_multiple(numbers):
    if len(numbers) < 2:
        return None
    lcm = numbers[0]
    for num in numbers[1:]:
        lcm = lcm * num // math.gcd(lcm, num)
    return lcm


lcm = least_common_multiple(all_steps)
print(f"Least common multiple: {lcm}")
