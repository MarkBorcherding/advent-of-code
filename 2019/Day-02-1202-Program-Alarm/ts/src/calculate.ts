import { Z_FIXED } from "zlib";


const ADD = 1
const MULTIPLY = 2
const HALT = 99

const set = (arr: number[], index: number, val: number) => {
    const f = [...arr];
    f[index] = val;
    return f
}

type Program = [number[], number]

const add = ([mem, address]: Program):Program => {
    const a = mem[mem[address + 1]]
    const b = mem[mem[address + 2]]
    const location = mem[address + 3]
    return [set(mem, location, a + b), address + 4];
};

const multiply = ([mem, address]: Program): Program => {
    const a = mem[mem[address + 1]]
    const b = mem[mem[address + 2]]
    const location = mem[address + 3]
    return [set(mem, location, a * b), address + 4];
}

const compute = ([program, address]: Program): Program  => {
    const opscode = program[address]
    switch(opscode) {
        case ADD: return compute(add([program, address]))
        case MULTIPLY: return compute(multiply([program, address]))
        case HALT: return [program, address]
        default: throw new Error("Could not handle code " + program[address])
    }
}

export const fix = (mem: number[], noun = 12, verb = 2) => 
    set(set(mem, 1, noun), 2, verb)

export default (mem: number[]) => compute([mem, 0]);