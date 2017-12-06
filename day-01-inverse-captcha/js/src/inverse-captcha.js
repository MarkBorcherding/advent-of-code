import R from 'ramda'

const log = R.tap(console.log)

const first = R.map(R.head)

const sum = R.sum

const matching = R.filter(([a, b]) => a === b)

const pairWith = f => R.converge(R.zip, [f, R.identity])

const middle = R.converge(R.divide, [R.length,  R.always(2)])

const cycle = R.curry((n , list) => {
  const [head, tail] = R.splitAt(n)(list)
  return [...tail, ...head]
})

const neighbors = cycle(1)
const antipodals = R.converge(cycle, [middle, R.identity])

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
