from functools import reduce, cmp_to_key


card_order = "A, K, Q, T, 9, 8, 7, 6, 5, 4, 3, 2, J".split(', ')


class Hand:

    def __init__(self, cards: str, bid: int):
        self.cards = cards
        self.bid = bid

        def tally_cards(acc, cur):
            acc[cur] = cards.count(cur)
            return acc

        cards_by_rank = reduce(tally_cards, cards, {})
        self.counts = list(cards_by_rank.values())
        self.jokers = cards.count('J')

        self.score_hand()

    @staticmethod
    def from_line(line: str):
        cards, bid = line.split(' ')
        return Hand(cards, int(bid))

    def is_five_of_a_kind(self) -> bool:
        return self.counts.count(5) == 1 or (self.counts.count(4) == 1 and self.jokers == 1) or (self.counts.count(3) == 1 and self.jokers == 2) or (self.counts.count(2) >= 1 and self.jokers == 3) or self.jokers == 4

    def is_four_of_a_kind(self) -> bool:
        return self.counts.count(4) == 1 or (self.counts.count(3) == 1 and self.jokers == 1) or (self.counts.count(2) == 2 and self.jokers == 2) or self.jokers == 3

    def is_full_house(self) -> bool:
        natural = self.counts.count(3) == 1 and self.counts.count(2) == 1
        wild = self.counts.count(2) == 2 and self.jokers == 1
        return natural or wild

    def is_three_of_a_kind(self) -> bool:
        return self.counts.count(3) == 1 or (self.counts.count(2) == 1 and self.jokers == 1) or self.jokers == 2

    def is_two_pair(self) -> bool:
        # no posisble way to have 2 pair with jokers. 1 joker would be three of a kind which is better than two pair
        return self.counts.count(2) == 2

    def is_one_pair(self) -> bool:
        return self.counts.count(2) == 1 or self.jokers == 1

    def is_high_card(self) -> bool:
        return self.counts.count(1) == 5 and self.jokers == 0

    def score_hand(self) -> int:
        if self.is_five_of_a_kind():
            self.score = 500
            self.score_name = "Five of a kind"
        elif self.is_four_of_a_kind():
            self.score = 400
            self.score_name = "Four of a kind"
        elif self.is_full_house():
            self.score = 350
            self.score_name = "Full house"
        elif self.is_three_of_a_kind():
            self.score = 300
            self.score_name = "Three of a kind"
        elif self.is_two_pair():
            self.score = 20
            self.score_name = "Two pair"
        elif self.is_one_pair():
            self.score = 10
            self.score_name = "One pair"
        elif self.is_high_card():
            self.score = 1
            self.score_name = "High card"
        else:
            raise Exception("Invalid hand")

        return f"{self.cards} {self.score}"


input = """
32T3K 765
T55J5 684
KK677 28
KTJJT 220
QQQJA 483
""".strip().splitlines()


def compare_rank(first: Hand, other: Hand) -> int:
    for (first, second) in zip(first.cards, other.cards):
        a = card_order.index(first)
        b = card_order.index(second)
        if a < b:
            return 1
        elif a > b:
            return -1
        else:
            continue
    return 0


def compare_hands(first: Hand, other: Hand) -> int:
    if first.score < other.score:
        return -1
    elif first.score > other.score:
        return 1
    else:
        return compare_rank(first, other)


f = open('./input.txt', 'r')
input = f.read().strip().splitlines()

hands = [Hand.from_line(line) for line in input]
key = cmp_to_key(compare_hands)

sorted_hands = sorted(hands, key=key)


score = 0
for (index, hand) in enumerate(sorted_hands, start=1):
    print(f"{index}: {hand.cards} {hand.score_name} {hand.bid}")
    score += index * hand.bid

print(score)
