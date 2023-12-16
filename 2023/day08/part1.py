from functools import reduce
import itertools
import re


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


file = open("input.txt", "r")
input = file.read().strip()

[directions, raw_map] = input.split("\n\n")

number_regex = re.compile(r"([A-Z]+)")


def parse_line(acc, line):
    [name, children] = line.split(" = ")
    [left, right] = number_regex.findall(children)
    acc[name] = (left, right)
    return acc


parsed_map = reduce(parse_line, raw_map.split("\n"), {})

directions_iterator = itertools.cycle(directions)
location = "AAA"
steps = 0
while location != "ZZZ":
    steps += 1
    next_location = parsed_map[location]
    location = next_location[next(directions_iterator) == "R"]

print(f"location {location}", f"steps {steps}")
