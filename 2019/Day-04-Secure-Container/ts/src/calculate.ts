import { pipe } from "@lib/f";

function* range(min: number, max: number): Iterator<number> {
  for (let i = min; i <= max; i++) {
    yield i;
  }
}

const reduce = <T, ACC>(f: (acc: ACC, cur: T) => ACC) => (starting: ACC) => (
  iter: Iterator<T>
) => {
  let acc = starting;
  let cur = iter.next();
  while (!cur.done) {
    acc = f(acc, cur.value);
    cur = iter.next();
  }
  return acc;
};

const all = <T>(...f: ((t: T) => boolean)[]) => (t: T) =>
  f.reduce((acc, cur) => acc && cur(t), true);

const digitsIncrease = (s: number[]) =>
  s.reduce((acc, cur, index, arr) => {
    const prevIndex = index - 1;
    if (prevIndex < 0) return acc;
    return acc && arr[prevIndex] <= cur;
  }, true);

const allButLast = <T>(t: T[]) => t.slice(0, -1);
const last = <T>(t: T[]) => t[t.length - 1];

const groupBy = <A>(f: (cur: A, index: number, arr: A[]) => boolean) => (
  a: A[]
) =>
  a.reduce((acc: Array<A[]>, cur, index, arr) => {
    if (index === 0) return [...acc, [cur]];
    if (f(cur, index, arr)) return [...allButLast(acc), [...last(acc), cur]];
    return [...acc, [cur]];
  }, []);

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

const filter = <T>(f: (t: T) => boolean) => (starting: T[] = []) => (
  iterator: Iterator<T>
) =>
  reduce<T, T[]>((acc, cur) => (f(cur) ? [...acc, cur] : acc))(starting)(
    iterator
  );

export const calculate = (s: string) => {
  const [min, max] = s.split("-").map(s => parseInt(s));

  const possibles = filter(isPossible)([])(range(min, max));
  return possibles.length;
};

export default calculate;
