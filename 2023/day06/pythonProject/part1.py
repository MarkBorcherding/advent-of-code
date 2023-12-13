import re


input = """
Time:      7  15   30
Distance:  9  40  200
""".strip()


numbers = re.compile(r'(\d+)')
[time, distance] = list(map(lambda x: numbers.findall(x), input.split("\n")))
games = zip(time, distance)

print(list(games))
