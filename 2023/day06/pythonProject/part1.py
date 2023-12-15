import re
from functools import reduce

input = """
Time:      7  15   30
Distance:  9  40  200
""".strip()

my_input = """
Time:        35     93     73     66
Distance:   212   2060   1201   1044
""".strip()
input = my_input
numbers = re.compile(r'(\d+)')
[time, distance] = list(map(lambda x: map(lambda y: int(y), numbers.findall(x)), input.split("\n")))
games = zip(time, distance)

ways_to_win_each_game = []
for (time, distance) in games:
    print("\n\nNew Game")
    print(f"Time: {time} Distance: {distance}")
    ways_to_win = 0
    for hold_time in range(1, time):
        go_time = time - hold_time
        speed = go_time * hold_time
        if speed <= distance:
            print(f"DNF with {hold_time}")
        else:
            print(f"Win with {hold_time}")
            ways_to_win +=  1
    ways_to_win_each_game += [ways_to_win]


print(f"Ways to win {ways_to_win_each_game}")

answer = reduce(lambda x, y: x * y, ways_to_win_each_game)
print(f"Answer: {answer}")

