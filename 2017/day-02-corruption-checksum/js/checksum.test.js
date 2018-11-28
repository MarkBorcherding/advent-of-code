
import { expect } from 'chai'

import checksum, { part2 } from './checksum'

describe('checksum', () => {
  it('example', () => {
    const input = [[5, 1, 9, 5],
                   [7, 5, 3],
                   [2, 4, 6, 8]]

    expect(checksum(input)).to.be.eql(8 + 4 + 6)
  })

  it('part2', () => {
    const input = [[5, 9, 2, 8],
                   [9, 4, 7, 3],
                   [3, 8, 6, 5]]

    expect(part2(input)).to.be.eql(4 + 3 + 2)
  })
})
