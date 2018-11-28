import R from 'ramda'

const splitOnSpaces = R.split(' ')

const onlyOne = R.compose(
  R.equals(R.__, 1),
  R.length
)

const groupSimilar = R.groupBy(R.identity)

const orderCharacters = R.sort(R.compare)

const testPassphrase = R.compose(
  R.isEmpty,
  R.reject(onlyOne),
  groupSimilar,
  R.map(orderCharacters),
  splitOnSpaces
)

const testPassphrases = R.compose(
  R.length,
  R.filter(testPassphrase)
)
