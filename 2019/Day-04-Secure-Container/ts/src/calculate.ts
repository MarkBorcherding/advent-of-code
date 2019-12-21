import { groupBy, all, filter, rangeIterator } from "@lib/f";

const digitsIncrease = (s: number[]) =>
  s.reduce((acc, cur, index, arr) => {
    const prevIndex = index - 1;
    if (prevIndex < 0) return acc;
    return acc && arr[prevIndex] <= cur;
  }, true);

const consecutive = (n: number) => <T>(t: T[]) => {
  const groups = groupBy((cur, index, arr: T[]) => cur === arr[index - 1])(t);
  return groups.filter(g => g.length === n).length > 0;
};

const isPossible = (n: number) => {
  const digits = n
    .toString()
    .split("")
    .map(s => parseInt(s));
  return all(digitsIncrease, consecutive(2))(digits);
};

export const calculate = (s: string) => {
  const [min, max] = s.split("-").map(s => parseInt(s));

  const possibles = filter(isPossible)([])(rangeIterator(min, max));
  return possibles.length;
};

export default calculate;
