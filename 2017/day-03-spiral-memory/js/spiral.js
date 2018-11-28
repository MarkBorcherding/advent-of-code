import R from 'ramda'


const size = R.compose(Math.ceil, Math.sqrt)


// 1
// 1 + 1 + 3 + 3 = 8 
// 3 + 3 + 5 + 5 = 14
// 5 + 5 + 7 + 7 = 24

// 37  36  35  34  33  32  31
// 38  17  16  15  14  13  30
// 39  18   5   4   3  12  29
// 40  19   6   1   2  11  28
// 41  20   7   8   9  10  27
// 42  21  22  23  24  25  26
// 43  44  45  46  47  48  49



// number 1 2 3 4 5 6 7 8 9 10 11 12 13 14 15 16 17 18 19 20 21 22 23 24 25 26 27 28 29 30 31 32 33
// ring   1 2               3                                               4
// width  1 3               5                                              7
// itmes  1 |-- 8 or 2^3--| |------------------ 16 or 2 ^4 --------------|
// answer 0 1 2 1 2 1 2 1 2 3  2  3  4  3  2  3  4  3  2  3  4  3  2  3  4  5  4  3  4  5  6  5  4


const bottom = R.compose(
          R.subtract(R.__, 1),
          R.multiply(2))

const side = R.compose(R.subtract(R.__, 2), bottom)

const ringSize = R.converge(R.add,
                [R.compose(R.multiply(2), bottom),
                 R.compose(R.multiply(2), side)])

const ring = R.cond([
  [R.equals(1), R.always(1)],
  [R.T,         m => ringSize(m) + ring(m-1)]])

const answers = R.converge(
            R.range,
            [R.subtract(R.__, 1),
            R.compose(
              R.subtract(R.__, 1),
              R.multiply(2))])

const bottomAnswers = n =>
  [ ...R.reverse(answers(n)), ...R.tail(answers(n))]

const sideAnswers = R.compose(
                R.init,
                R.tail,
                bottomAnswers)

const ringAnswers = R.compose(
  R.flatten,
  R.repeat(R.__, 2),
  R.converge(
    R.concat,
    [bottomAnswers, sideAnswers]))

const ringIndexes = n => {
  const max = ring(n)
  return R.range(max - ringSize(n), max + 1)
}


export const spiral = x => {
  var i = 0;
  while(ringIndexes(i).indexOf(x) < 0){i += 1}
  return ringAnswers(i)[ringIndexes(i).indexOf(x)]
}

export default { part1: spiral }
