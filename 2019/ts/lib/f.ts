type F<A,B> = (a:A) => B

export const contains = <T>(f:F<T,boolean>) => (arrayLike: ArrayLike<T>) => {
  for(let i=0; i< arrayLike.length; i++) {
    if(f(arrayLike[i])) return true
  }
  return false
}

export const range = (count: number, startAt: number = 0) => 
  Array.from(new Array(count), (x,i) => i + startAt)

export const min = (arr: number[]) => {
  return arr.reduce( (min, cur) => (cur < min) ? cur : min, arr[0])
}

export const max = (arr: number[]) => {
  return arr.reduce( (max, cur) => (cur > max) ? cur : max, arr[0])
}

export function pipe<T1, T2, T3>(f1:F<T1,T2>, f2:F<T2, T3>): F<T1,T3>
export function pipe<T1, T2, T3, T4>(f1:F<T1,T2>, f2:F<T2, T3>, f3: F<T3, T4>): F<T1, T4>
export function pipe(...f:F<any,any>[]): any
{
  return (val: any) => (f.reduce((acc, cur) => cur(acc), val))
}

export const tap = <T>(f:F<T, void>) => (val: T) => {
  f(val);
  return val;
}

export const map = <A,B>(f:F<A,B>) => (a:A[]):B[] => a.map(f)

export const split = (delim: string) => (val: string) => val.split(delim)