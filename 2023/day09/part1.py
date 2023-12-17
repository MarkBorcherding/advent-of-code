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
    while not all(map(lambda x: x == 0, current_level)):
        next_level = []

        for index in range(0, len(current_level)-1):
            next_level.append(current_level[index+1] - current_level[index])

        last_values.append(next_level[-1])
        # levels.append(next_level)
        current_level = next_level  # Update the current_level

    # print("\n".join(map(str, levels)))
    # print(last_values)
    sum = 0
    for v in last_values[::-1]:
        sum += v
    # print(sum)
    # print("----------")
    return sum


next_values = list(map(calculate_map, lines))

print(f"sum {sum(next_values)}")
