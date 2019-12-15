#!/usr/bin/env npx ts-node -r tsconfig-paths/register

import calculate from './calculate'
import assert from 'assert'
import { describe, it } from '@lib/test'

describe("Example Data")(() => {
  it("example 1")(() => {
    assert.deepEqual(
      159,
      calculate([
        "R75,D30,R83,U83,L12,D49,R71,U7,L72",
        "U62,R66,U55,R34,D71,R55,D58,R83"
      ])
    )
  })

  it("example 2")(() => {
    assert.deepEqual(
      135,
      calculate([
        "R98,U47,R26,D63,R33,U87,L62,D20,R33,U53,R51",
        "U98,R91,D20,R16,D67,R40,U7,R15,U6,R7"
      ])
    )
  })
})

