#!/usr/bin/env npx ts-node

import fs from 'fs'
import calculate from './calculate'


const input = 
    fs
    .readFileSync("../data.txt", 'utf8')
    .split("\n")
    .map(s => parseInt(s, 10))

const out = input
    .map(calculate)
    .reduce((acc, curr) => acc + curr, 0)

console.log(out)
