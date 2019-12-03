#!/usr/bin/env npx ts-node -r tsconfig-paths/register

import fs from 'fs'
import calculate from './calculate'

const input = 
    fs
    .readFileSync("../data.txt", 'utf8')
    .split("\n")

const out = calculate(input) 

console.log(out)
