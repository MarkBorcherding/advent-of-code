
export const it = (name: string) => (f:() => void) => {
  console.group(name)
  try {
  f()
  } catch (e) {
    console.log(' [ fail ]', e.message)
  }
  console.groupEnd()
}

export const describe = (name: string) => (f: () => void) => {
  console.group(name)
  f()
  console.groupEnd()
}