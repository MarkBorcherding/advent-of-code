import functools
import re
from typing import Set, Tuple

input = """
seeds: 79 14 55 13

seed-to-soil map:
50 98 2
52 50 48

soil-to-fertilizer map:
0 15 37
37 52 2
39 0 15

fertilizer-to-water map:
49 53 8
0 11 42
42 0 7
57 7 4

water-to-light map:
88 18 7
18 25 70

light-to-temperature map:
45 77 23
81 45 19
68 64 13

temperature-to-humidity map:
0 69 1
1 0 69

humidity-to-location map:
60 56 37
56 93 4
""".strip()

f = open("./input.txt", "r")
input = f.read().strip()

groups = input.split("\n\n")

[seed_zone, *tail] = groups

seeds = seed_zone.split(":")[1].strip().split(' ')


class ZoneMap:
    def __init__(self, zone: str):
        [heading, *map_lines] = zone.splitlines()
        self.heading = heading
        self.maps = {}
        self.ranges = set()
        for line in map_lines:
            [destination_start, source_start, range_length] = list(map(lambda x: int(x), line.split(' ')))
            self.ranges.add((range(source_start, source_start + range_length),
                             range(destination_start, destination_start + range_length)))

    def map(self, source_v: int):
        for (source, destination) in self.ranges:
            if source_v in source:
                return destination[source.index(source_v)]

        return source_v


maps = list(map(ZoneMap, tail))


seed_locations = []
for seed in seeds:
    loc = functools.reduce(lambda acc, cur: cur.map(acc), maps, int(seed))
    seed_locations.append((seed, loc))

min = seed_locations[0]

for (seed, loc) in seed_locations:
    if loc < min[1]:
        min = (seed, loc)

print("part 1", min)


