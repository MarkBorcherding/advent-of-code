
const input = () => (`+3
+3
+4
-2
-4`);


const splitOnLines = (x: string) => x.split("\n");
const toNumbers = (x: string[]) => x.map(parseFloat)


function* cycle<T>(list:T[]) {
    let i = 0;
    while(true) {
        yield list[i++ % list.length];
    }
}

const reduceWhile =
    <TItem,TAcc>
    (predicate:(l:TAcc, k:TItem)=>boolean) =>
    (f:(l:TAcc, k:TItem)=>TAcc) =>
    (initialValue: TAcc) =>
    (list:IterableIterator<TItem>) => {
    let curr = list.next();
    let acc = initialValue;
    while(!curr.done || !predicate(acc, curr.value)){
        acc = f(acc,curr.value)
        curr = list.next();

        console.log(!predicate(acc, curr.value), curr.value, acc)
    }
    return acc;
}



const not = <A extends any[]>(f:(...a:A) => boolean) => (...a:A) => !f(...a)

type Acc = [number, number[]]

const alreadyFound = ([offset, previousOffsets]: Acc, freq: number) => {
    const newOffset = offset + freq;
    return !!previousOffsets.find( x => x === newOffset);
}

const add:(acc:Acc, curr:number)=>Acc = ([offset , previousOffsets], current) =>
    [ offset + current, previousOffsets.concat(offset) ]


const f = reduceWhile (not(alreadyFound))  (add) ([0, []])

const i = f(cycle(toNumbers(splitOnLines(input()))))

console.log(i)
