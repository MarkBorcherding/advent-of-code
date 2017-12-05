import { expect } from 'chai'

import inverseCaptcha, { version2 } from '../src/inverse-captcha'

describe('inverse captcha', () => {
  it('do the simple version', () => {
    expect(inverseCaptcha('1122')).to.eql(1 + 2)
    expect(inverseCaptcha('1111')).to.eql(1 + 1 + 1 + 1)
    expect(inverseCaptcha('1234')).to.eql(0)
    expect(inverseCaptcha('91212129')).to.eql(9)
  })

  it('do the version2', () => {
    expect(version2('1212')).to.eql(6)
    expect(version2('1221')).to.eql(0)
    expect(version2('123425')).to.eql(4)
    expect(version2('123123')).to.eql(12)
    expect(version2('12131415')).to.eql(4)
  })
})
