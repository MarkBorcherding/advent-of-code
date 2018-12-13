
export function pipe<A,B,C>(f:(a:A)=>B, g:(b:B)=>C):(a:A)=>C
export function pipe<A,B,C,D>(f:(a:A)=>B, g:(b:B)=>C, h:(c:C)=>D):(a:A)=>D 
export function pipe<A,B,C,D,E> (a:(a:A)=>B, b:(b:B)=>C, c:(c:C)=>D, d:(d:D)=>E):(a:A)=>E
export function pipe<A,B,C,D,E,F> (a:(a:A)=>B, b:(b:B)=>C, c:(c:C)=>D, d:(d:D)=>E, e:(e:E)=>F):(a:A)=>F
export function pipe<A,B,C,D,E,F,G> (a:(a:A)=>B, b:(b:B)=>C, c:(c:C)=>D, d:(d:D)=>E, e:(e:E)=>F, f:(f:G)=>G):(a:A)=>G

export function pipe(...f:any) {
        const apply = (v: any, f:any) => f(v)
        return (a:any) => f.reduce(apply, a)
    }

export const all = <A>(...preds:((a:A) => boolean)[]) => (a:A) =>
    preds.reduce(
        (acc, curr) => acc && curr(a), 
        true);


export const map = <A,B>(f:((a:A) =>B)) => (a:A[]) => a.map(f);

export const reduce = <A,B>(f: ((acc:B, a:A)=>B)) => (initial:B) => (a:A[]) =>
    a.reduce(f,initial)

export const groupBy = <A>(keyFunction:(a:A) => string) => (list:A[]):{[id: string]:A[]} =>
    list.reduce(
    (acc: {[id: string]: A[]}, curr:A) => {
        const key = keyFunction(curr);
        const group = acc[key];
        acc[key] = group ? [curr, ...group] : [curr];
        return acc
    },
    {})

export const identity = <A>(a:A) => a;

export const tap = <A>(f:(a:A)=>void) => (a:A) => { f(a); return a}

export const mapValues = <A,B>(f:(a:A) => B) => (o: {[id:string]:A}) =>{
    const keys = Object.keys(o);
    return keys.reduce(
        (acc: {[id:string]: B}, curr: string) => {
            acc[curr] = f(o[curr]);
            return acc
        },
        {})}

export const filterValues =
    <A, B extends {[id: string]:A}>(pred:(a:A) => boolean) =>
    (o:B) =>
    {
        return Object.keys(o).reduce((acc:{[id:string]:A}, curr) => {
            if(pred(o[curr])) {
                acc[curr] = o[curr]
            }
            return acc;
        }, {})
    }

export const gte = (x:number) => (y:number) => x >= y
export const lte = (x:number) => (y:number) => x <= y
export const between = (min: number, max:number) =>
    all(
        lte(min),
        gte(max))

export const arrayify = (s:string) => s.split('')

export const zip = <A>(a:A[]) => <B>(b:B[]) => a.map((item, index) => [item, b[index]] )

export const count = <A>(pred:(a:A)=>boolean) => (a:A[]) => a.filter(pred).length

export const contains = <T>(f:(t:T)=>boolean) => (t:T[]) => !!t.filter(f)

export const equal = <A>(...a:A[]) => a.reduce((acc, curr, i, arr) => acc && curr === arr[0], true)

export const take = (n:number) => <A>(l:A[]) => l.slice(0,n)

export const not = <A extends any[]>(f:(...a:A)=>boolean) => (...a:A) => !f(...a)

export const arrEqual = <A>(l:A[]) => l.reduce((acc, cur)=> acc && (cur === l[0]), true)

export const reduceUntil =
    <A>(predicate:(acc:A)=>boolean) =>
    <T>(func:(acc:A, curr:T)=>A) =>
    (initial: A) =>
    (list:T[]) => {
        let items = list[Symbol.iterator]();
        let curr = items.next();
        let acc = initial;
        let found = false;

        while(!curr.done && !found){
            acc = func(acc, curr.value);
            found = predicate(acc)
            curr = items.next();
        }

        return acc
    }
