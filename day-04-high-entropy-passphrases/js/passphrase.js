import R from 'ramda'

const splitOnSpaces = R.split(' ')

const onlyOne = R.compose(
  R.equals(R.__, 1),
  R.length
)

const groupSimilar = R.groupBy(R.identity)

const testPassphrase = R.compose(
  R.isEmpty,
  R.reject(onlyOne),
  groupSimilar,
  splitOnSpaces
)

const testPassphrases = R.compose(
  R.length,
  R.reject(testPassphrase)
)
