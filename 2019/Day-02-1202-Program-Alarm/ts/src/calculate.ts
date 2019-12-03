import { Z_FIXED } from "zlib";


const ADD = 1
const MULTIPLY = 2
const HALT = 99

const set = (arr: number[], index: number, val: number) => {
    const f = [...arr];
    f[index] = val;
    return f
}

const add = (mem: number[], a: number, b: number, location: number) => 
    set(mem, location, mem[a] + mem[b]);

const multiply = (mem: number[], a: number, b: number, location: number) => 
    set(mem, location, mem[a] * mem[b])

const compute = (program: number[], pointer:number = 0): [number[], number] => {
    const opscode = program[pointer]
    switch(opscode) {
        case ADD: return compute(add(program, program[pointer + 1], program[pointer + 2], program[pointer + 3]), pointer + 4)
        case MULTIPLY: return compute(multiply(program, program[pointer + 1], program[pointer + 2], program[pointer + 3]), pointer + 4)
        case HALT: return [program, pointer]
        default: throw new Error("Could not handle code " + program[pointer])
    }
}

export const fix = (mem: number[], noun = 12, verb = 2) => 
    set(set(mem, 1, noun), 2, verb)

export default (mem: number[]) => compute(mem);