from functools import reduce, cmp_to_key


card_order = "A, K, Q, J, T, 9, 8, 7, 6, 5, 4, 3, 2".split(', ')


class Hand:

    def __init__(self, cards: str, bid: int):
        self.cards = cards
        self.bid = bid

        def tally_cards(acc, cur):
            acc[cur] = cards.count(cur)
            return acc

        cards_by_rank = reduce(tally_cards, cards, {})
        self.counts = list(cards_by_rank.values())

        self.score = self.score_hand()

    @staticmethod
    def from_line(line: str):
        cards, bid = line.split(' ')
        return Hand(cards, int(bid))

    def is_five_of_a_kind(self) -> bool:
        return self.counts.count(5) == 1

    def is_four_of_a_kind(self) -> bool:
        return self.counts.count(4) == 1

    def is_full_house(self) -> bool:
        return self.counts.count(3) == 1 and self.counts.count(2) == 1

    def is_three_of_a_kind(self) -> bool:
        return self.counts.count(3) == 1

    def is_two_pair(self) -> bool:
        return self.counts.count(2) == 2

    def is_one_pair(self) -> bool:
        return self.counts.count(2) == 1

    def is_high_card(self) -> bool:
        return self.counts.count(1) == 5

    def score_hand(self) -> int:
        if self.is_five_of_a_kind():
            return 500
        elif self.is_four_of_a_kind():
            return 400
        elif self.is_full_house():
            return 350
        elif self.is_three_of_a_kind():
            return 300
        elif self.is_two_pair():
            return 20
        elif self.is_one_pair():
            return 10
        elif self.is_high_card():
            return 1
        else:
            raise Exception("Invalid hand")


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
    score += index * hand.bid

print(score)
