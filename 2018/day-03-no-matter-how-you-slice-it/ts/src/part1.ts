import { expect } from 'chai'; 

interface Matrix<T> extends Array<Array<T>> {}

const always = <T>(t:T) => <A extends any[]>(...a:A) => t


const matrix = <T>(width: number, height: number, val: (x:number, y:number) => T):Matrix<T> =>
    [ ...Array(height).fill(0).map((_,y) =>
           [...Array(width).fill(0).map((_,x) => val(x,y))])]

const repeat = (n:number) => <T>(f:(i:number) => T) =>
    [...Array(n).keys()].map(f)

const matrix2 = <T>(width: number, height: number, val: (x:number, y:number) => T):Matrix<T> =>
    repeat (height) ((y) => repeat (width) ((x) => val(x,y)))

const solve = (s:string) => {
    return matrix(3,2,always(0))
}

describe('Part 1', () => {
    it('should work', () => {
        const s = 'hi';
        expect(s).to.eq('hi')
    })
});
