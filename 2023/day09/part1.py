from functools import reduce


input = """
0 3 6 9 12 15
1 3 6 10 15 21
10 13 16 21 30 45
""".strip().split('\n')

file = open("input.txt", "r")
input = file.read().strip().split('\n')


lines = list(map(lambda x: list(map(int, x.split(' '))), input))


def calculate_map(line):
    # levels = [line]
    current_level = line
    last_values = [line[-1]]
    first_values = [line[0]]
    while not all(map(lambda x: x == 0, current_level)):
        next_level = []

        for index in range(0, len(current_level)-1):
            next_level.append(current_level[index+1] - current_level[index])

        last_values.append(next_level[-1])
        first_values.append(next_level[0])
        # levels.append(next_level)
        current_level = next_level  # Update the current_level

    # print("\n".join(map(str, levels)))
    # print(last_values)
    sum = 0
    diff = 0
    next_first_values = []
    for f, l in zip(first_values[::-1], last_values[::-1]):
        sum += l
        diff = f - diff
        next_first_values.append(diff)

    # print(line, last_values, sum, first_values, next_first_values, diff)
    # print("----------")
    return diff


next_values = list(map(calculate_map, lines))

print(f"sum {sum(next_values)}")
