#!/usr/bin/env npx ts-node
import fs from 'fs'
import calculate, { fix } from './calculate';


const input: number[] =
    fs
        .readFileSync("../data.txt", 'utf8')
        .split(",")
        .map((s: string) => parseInt(s, 10));

const range = (n: number) => Array.from({ length: n }, (v, k) => k)

const nouns = range(99)
const verbs = range(99)

nouns.forEach(noun => {
    verbs.forEach( verb => {
        const [mem] = calculate(fix(input, noun, verb))
        if( mem[0] === 19690720 ){
            console.log({noun, verb})
            process.exit(0)
        }
    })
})

