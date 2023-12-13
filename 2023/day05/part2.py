import functools
from typing import Set, Tuple, List

from rich.progress import Progress

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

seeds: List[int] = seed_zone.split(":")[1].strip().split(' ')


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


with Progress() as progress:

    map_zones_task = progress.add_task("Map Zones", total=len(tail))
    progress_block_tasks = progress.add_task("Progress Blocks", total=len(seeds)/2)

    def execute(s: str):
        progress.advance(map_zones_task)
        return ZoneMap(s)

    maps = list(map(ZoneMap, tail))

    seed_locations = []

    nearest = None

    for seed_block in map(lambda x: range(int(seeds[x]), int(seeds[x]) + int(seeds[x + 1])), range(0, len(seeds), 2)):
        progress.advance(progress_block_tasks)
        block_task = progress.add_task(f"Process block {seed_block.start:,} to {seed_block.stop:,} of {len(seed_block):,} items", total=len(seed_block))
        for seed in seed_block:
            loc = functools.reduce(lambda acc, cur: cur.map(acc), maps, int(seed))
            #seed_locations.append((seed, loc))
            if nearest is None:
                nearest = (seed, loc)
            elif nearest[1] > loc:
                nearest = (seed, loc)

            progress.advance(block_task)
        progress.remove_task(block_task)



print("part 2", nearest)
