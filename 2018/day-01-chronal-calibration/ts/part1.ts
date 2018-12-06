const part1 = () => {
    const input = ``;


    const dropPlusSigns = (x: string) => x.replace(/\+/g, '')
    const splitOnLines = (x: string) => x.split("\n");

    const add = (total: number, next: number) => total + next;
    const answer = splitOnLines(dropPlusSigns(input)).map(parseFloat, 10).reduce(add, 0);
    console.log(answer)
}
part1();
