const equal = <T>(expected: T, actual:T) => {
  if(expected === actual) {
    console.log("😊 ", expected, " equals ", actual)
  } else {
    console.error("👎 Test Failed:\n    Expected", expected ,"\n    Actual  ", actual, "\n")
  }
}

export default { equal }