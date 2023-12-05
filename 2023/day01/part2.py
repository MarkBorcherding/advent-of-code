import re


f = open("./input.txt", "r")

input = f.read()

test_input = """two1nine
eightwothree
abcone2threexyz
xtwone3four
4nineeightseven2
zkoneight234
7pqrstsixteen"""

input = input if True else test_input

english = ["one", "two", "three", "four",
           "five", "six", "seven", "eight", "nine"]
numbers = list(range(1, 10))
pairs = zip(english + list(map(lambda x: f"{x}", numbers)), numbers + numbers)
names = dict(pairs)

regex_pattern = "|".join(list(names.keys()))
regex = re.compile(f"(?=({regex_pattern}))")


def find_num(s: str):
    m = regex.findall(s)
    f = m[0]
    l = m[-1]
    f_num = names[f]
    l_num = names[l]
    num = f_num * 10 + l_num
    # print(s, f, l, f_num, l_num, num)
    return num


nums = list(map(find_num, input.split("\n")))

print(sum(nums))
