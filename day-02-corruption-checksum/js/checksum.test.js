
import { expect } from 'chai'

import checksum from './checksum'

describe('checksum', () => {
  it('example', () => {
    const input = [[5, 1, 9, 5],
                   [7, 5, 3],
                   [2, 4, 6, 8]]

    expect(checksum(input)).to.be.eql(8 + 4 + 6)
  })
})
