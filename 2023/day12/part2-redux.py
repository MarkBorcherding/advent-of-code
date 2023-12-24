import re
from rich import print
from rich.table import Table
from rich.progress import Progress

input = []
input.append("""
???.### 1,1,3
""".strip())

input.append("""
???.### 1,1,3
.??..??...?##. 1,1,3
?#?#?#?#?#?#?#? 1,3,1,6
????.#...#... 4,1,1
????.######..#####. 1,6,5
?###???????? 3,2,1
""".strip())

input.append("""
???.### 1,1,3
""".strip())

f = open("input.txt", "r")
input.append(f.read().strip())

permuation_lookup = {}


def get_permutations(s: str) -> list[str]:
    if s in permuation_lookup:
        return permuation_lookup[s]

    def permute(s: str):
        if len(s) == 0:
            return ['']

        head, *tail = s
        if head == '?':
            permuted_tail = permute(tail)
            return ['.' + x for x in permuted_tail] + ['#' + x for x in permuted_tail]
        else:
            return [head + x for x in permute(tail)]

    permutations = permute(s)
    permuation_lookup[s] = permutations
    return permutations


def count(s: str, expected_contiguous_blocks: list[int]):
    print(f'Looking for {expected_contiguous_blocks} in {s}')
    group_regex = re.compile(r'(#)\1*')
    for group in re.compile(r'([#?])*').finditer(s):
        print(f"Checking {group.group(0)}")

        permutations = get_permutations(group.group(0))
        for permutation in permutations:
            for match in group_regex.finditer(permutation):
                print(match.group(0))

        length = group.end() - group.start()

        if length < expected_contiguous_blocks[0]:
            continue

        span = group.group(0)
        print(span)


rows = input[0].split("\n")

for row in rows:
    [partial_operational_status, blocks] = row.split(" ")
    expanded_row = '?'.join([partial_operational_status*5])
    expanded_blocks = [int(x) for x in blocks.split(",")]*5

    count(expanded_row, expanded_blocks)
