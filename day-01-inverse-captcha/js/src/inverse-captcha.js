import R from 'ramda'

const first = R.map(R.head)

const sum = R.sum

const matching = R.filter(([a, b]) => a === b)

const neighbors = ([head, ...tail]) => R.zip([head, ...tail], [...tail, head])

const inverseCaptcha = R.compose(
  sum,
  first,
  matching,
  neighbors,
)

export default inverseCaptcha
