import re
from functools import reduce

input = """
Time:      71530
Distance:  940200
""".strip()

my_input = """
Time:        35937366
Distance:   212206012011044
""".strip()

input = my_input

numbers = re.compile(r'(\d+)')
[time, distance] = list(map(lambda x: map(lambda y: int(y), numbers.findall(x)), input.split("\n")))
games = zip(time, distance)

for (time, distance) in games:
    print("\n\nNew Game")
    print(f"Time: {time} Distance: {distance}")
    lowest_hold_time = None
    highest_hold_time = None

    for hold_time in range(1, time):
        go_time = time - hold_time
        speed = go_time * hold_time
        if speed <= distance:
            pass
        else:
            lowest_hold_time = hold_time
            break

    for hold_time in range(time, 1, -1):
        go_time = time - hold_time
        speed = go_time * hold_time
        if speed <= distance:
            pass
        else:
            highest_hold_time = hold_time
            break

    ways_to_win = highest_hold_time - lowest_hold_time + 1
    print("Ways to win: ", ways_to_win)



