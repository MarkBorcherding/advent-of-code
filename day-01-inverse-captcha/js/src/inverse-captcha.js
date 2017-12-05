import R from 'ramda'

const log = R.tap(console.log)

const first = R.map(R.head)

const sum = R.sum

const matching = R.filter(([a, b]) => a === b)

const pairWith = f => list => R.zip(f(list), list)

const neighbors = ([head, ...tail]) => ([...tail, head])

const antipodals = (x) => {
  const [head, tail] = R.splitAt(R.length(x) / 2)(x)
  return [...tail, ...head]
}

const inverseCaptcha = R.compose(
  sum,
  first,
  matching,
  pairWith(neighbors),
)

export const version2 = R.compose(
  sum,
  first,
  matching,
  pairWith(antipodals),
)

export default inverseCaptcha
