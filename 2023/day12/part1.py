import re
from rich import print
from rich.table import Table
from rich.progress import Progress

input = []
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

print("Part 1")

colors = ["red", "dark_orange", "gold1", "yellow1", "green",
          "blue", "blue3", "violet", "magenta3", "light_sky_blue1"]


def rainbow():
    while True:
        for color in colors:
            yield color


class ConditionRecord:

    damaged = "#"
    operational = "."

    known = [damaged, operational]

    block_pattern = re.compile(r'(.)\1*')

    def __init__(self, row: str):
        [operational_status, contiguous_blocks] = row.split(" ")

        self.contiguous_blocks = [int(x) for x in contiguous_blocks.split(",")]

        self.partial_operational_status = operational_status
        self.partial_formatted_status = self.format_status(operational_status)

        self.possible_statuses = self.find_possible(operational_status)

    def find_possible(self, status) -> list[str]:
        permutations = self.find_permuatations(status)
        possible = []
        for permutation in permutations:
            matches = re.compile(r'(#)\1*').finditer(permutation)
            group_lengths = []
            for match in matches:
                (s, e) = match.span()
                group_lengths.append(e - s)

            if len(group_lengths) != len(self.contiguous_blocks):
                continue

            compare = all(map(lambda x: x[0] == x[1], zip(
                group_lengths, self.contiguous_blocks)))

            if compare:
                possible.append(permutation)

        return possible

    def find_permuatations(self, status: str,  prefix: str = "") -> list[str]:
        if len(status) == 0:
            return [prefix]

        head, *tail = status
        if head in ConditionRecord.known:
            return self.find_permuatations(tail, prefix + head)

        return self.find_permuatations(tail, prefix + ConditionRecord.damaged) \
            + self.find_permuatations(tail, prefix +
                                      ConditionRecord.operational)

    def __str__(self):
        return f"ConditionRecord: {self.operational_status}, {self.contiguous_blocks}, {self.fomratted_status}"

    def __repr__(self):
        return self.__str__()

    def format_status(self, status):
        s = []
        color = rainbow()
        for group in ConditionRecord.block_pattern.finditer(status):
            c = next(color)
            s.append(f"[{c}]{group.group()}[/{c}]")
        color.close()
        return "".join(s)


def print_records(records: list[ConditionRecord]):
    table = Table(title="Condition Records")
    table.show_footer = True
    table.add_column("Partial Status")
    table.add_column("Contiguous Blocks")

    possible_count = sum(map(lambda x: len(x.possible_statuses), records))
    table.add_column("Possible Status", footer=f"{possible_count} total")

    for record in records:
        table.add_row(record.partial_formatted_status,
                      str(record.contiguous_blocks),
                      str(len(record.possible_statuses)))

    print(table)


rows = input[2].split("\n")
condition_records = []
with Progress() as progress:
    task = progress.add_task("[cyan]Processing...", total=len(rows))
    for row in rows:
        condition_records.append(ConditionRecord(row))
        progress.update(task, advance=1)
print_records(condition_records)
