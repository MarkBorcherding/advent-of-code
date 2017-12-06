
import R from 'ramda'

const max = R.apply(Math.max)
const min = R.apply(Math.min)

const difference = R.converge(R.subtract, [max, min])

export default R.compose(
  R.sum,
  R.map(difference),
)
