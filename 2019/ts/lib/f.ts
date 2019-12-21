type F<A, B> = (a: A) => B;


export const set = (arr: number[], index: number, val: number) => {
    const f = [...arr];
    f[index] = val;
    return f
}

export const range = (count: number, startAt: number = 0) =>
  Array.from(new Array(count), (x, i) => i + startAt);

export function* rangeIterator(min: number, max: number): Iterator<number> {
  for (let i = min; i <= max; i++) {
    yield i;
  }
}


export function pipe<T1, T2, T3>(f1: F<T1, T2>, f2: F<T2, T3>): F<T1, T3>;
export function pipe<T1, T2, T3, T4>(
  f1: F<T1, T2>,
  f2: F<T2, T3>,
  f3: F<T3, T4>
): F<T1, T4>;
export function pipe(...f: F<any, any>[]): any {
  return (val: any) => f.reduce((acc, cur) => cur(acc), val);
}

export const tap = <T>(f: F<T, void>) => (val: T) => {
  f(val);
  return val;
};

export const map = <A, B>(f: F<A, B>) => (a: A[]): B[] => a.map(f);

export const filter = <T>(f: (t: T) => boolean) => (starting: T[] = []) => (
  iterator: Iterator<T>
) =>
  reduce<T, T[]>((acc, cur) => (f(cur) ? [...acc, cur] : acc))(starting)(
    iterator
  );

export const reduce = <T, ACC>(f: (acc: ACC, cur: T) => ACC) => (starting: ACC) => (
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

export const split = (delim: string) => (val: string) => val.split(delim);

export const all = <T>(...f: ((t: T) => boolean)[]) => (t: T) =>
  f.reduce((acc, cur) => acc && cur(t), true);

export const allButLast = <T>(t: T[]) => t.slice(0, -1);

export const last = <T>(t: T[]) => t[t.length - 1];

export const groupBy = <A>(f: (cur: A, index: number, arr: A[]) => boolean) => (
  a: A[]
) =>
  a.reduce((acc: Array<A[]>, cur, index, arr) => {
    if (index === 0) return [...acc, [cur]];
    if (f(cur, index, arr)) return [...allButLast(acc), [...last(acc), cur]];
    return [...acc, [cur]];
  }, []);

export const min = (arr: number[]) => arr.reduce((min, cur) => (cur < min ? cur : min), arr[0]);

export const max = (arr: number[]) => arr.reduce((max, cur) => (cur > max ? cur : max), arr[0]);

export const contains = <T>(f: F<T, boolean>) => (arrayLike: ArrayLike<T>) => {
  for (let i = 0; i < arrayLike.length; i++) {
    if (f(arrayLike[i])) return true;
  }
  return false;
};