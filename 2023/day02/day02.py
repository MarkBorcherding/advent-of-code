
input = """Game 1: 3 blue, 4 red; 1 red, 2 green, 6 blue; 2 green
Game 2: 1 blue, 2 green; 3 green, 4 blue, 1 red; 1 green, 1 blue
Game 3: 8 green, 6 blue, 20 red; 5 blue, 4 red, 13 green; 5 green, 1 red
Game 4: 1 green, 3 red, 6 blue; 3 green, 6 red; 3 green, 15 blue, 14 red
Game 5: 6 red, 1 blue, 3 green; 2 blue, 1 red, 2 green"""

f = open("input.txt", "r")
input = f.read()


class Game():

    def __init__(self, line: str):
        [game_number, dice] = line.split(":")
        self.game_number = game_number.split(' ')[1]
        self.possible = True

        self.counts = {
            'red': 0,
            'blue': 0,
            'green': 0
        }

        for dice_pull in dice.split(';'):

            for dice_color in dice_pull.split(','):
                [amount, color] = dice_color.strip().split(' ')

                if self.counts[color] < int(amount):
                    self.counts[color] = int(amount)

    def power(self):
        return self.counts['green'] * self.counts['red'] * self.counts['blue']


games = list(map(Game, input.splitlines()))


print(sum(list(map(lambda x: x.power(), games))))
