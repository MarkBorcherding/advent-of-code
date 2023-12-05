
input = """Game 1: 3 blue, 4 red; 1 red, 2 green, 6 blue; 2 green
Game 2: 1 blue, 2 green; 3 green, 4 blue, 1 red; 1 green, 1 blue
Game 3: 8 green, 6 blue, 20 red; 5 blue, 4 red, 13 green; 5 green, 1 red
Game 4: 1 green, 3 red, 6 blue; 3 green, 6 red; 3 green, 15 blue, 14 red
Game 5: 6 red, 1 blue, 3 green; 2 blue, 1 red, 2 green"""

f = open("input.txt", "r")
input = f.read()


MAX_RED = 12
MAX_GREEN = 13
MAX_BLUE = 14


class Game():

    def __init__(self, line: str):
        [game_number, dice] = line.split(":")
        self.game_number = game_number.split(' ')[1]
        self.possible = True

        for dice_pull in dice.split(';'):
            for dice_color in dice_pull.split(','):
                [amount, color] = dice_color.strip().split(' ')

                if color == 'red':
                    max = MAX_RED
                elif color == 'blue':
                    max = MAX_BLUE
                else:
                    max = MAX_GREEN

                if int(amount) > max:
                    self.possible = False


games = list(map(Game, input.splitlines()))

possible_games = filter(lambda x: x.possible, games)

print(sum(list(map(lambda x: int(x.game_number),  possible_games))))
