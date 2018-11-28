
import R from 'ramda'

const max = R.apply(Math.max)
const min = R.apply(Math.min)
const identical = R.apply(R.equals)
const difference = R.converge(R.subtract, [max, min])
const divide = R.converge(R.divide, [R.head, R.tail])

export default R.compose(
  R.sum,
  R.map(difference),
)

const combinationsOf2 = R.compose(
  R.reject(identical),
  R.unnest,
  (list => (R.map(x => (R.map(y => ([x, y]), list)), list))))

const evenlyDivisible = R.compose(
  R.equals(0),
  R.converge(R.modulo, [R.head, R.tail]))

const evenDividend = R.compose(
  divide,
  R.find(evenlyDivisible),
  combinationsOf2)

export const part2 = R.compose(
  R.sum,
  R.map(evenDividend))
