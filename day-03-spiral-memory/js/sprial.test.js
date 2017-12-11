import { expect } from 'chai'

import { spiral } from './spiral'

describe('spiral', () => {
  it('part1', () => {
    expect(spiral(1)).to.be.eql(0)
    expect(spiral(12)).to.be.eql(3)
    expect(spiral(23)).to.be.eql(2)
    expect(spiral(1024)).to.be.eql(31)
  })
})
