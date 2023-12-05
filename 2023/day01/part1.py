

import functools
import re


f = open("./input.txt", "r")
input = f.read()

non_numbers = r'[^\d\n]'

input = re.sub(non_numbers, "", input)

input = input.split('\n')

print(input)


def form_number(s: str):
    return int(s[0]) * 10 + int(s[len(s)-1])


i = list(map(form_number, input))


print(sum(i))
