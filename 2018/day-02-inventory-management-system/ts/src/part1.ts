import { expect } from 'chai'; 


function pipe<A,B,C>(f:(a:A)=>B, g:(b:B)=>C):(a:A)=>C
function pipe<A,B,C,D>(f:(a:A)=>B, g:(b:B)=>C, h:(c:C)=>D):(a:A)=>D 
function pipe<A,B,C,D,E>
    (a:(a:A)=>B, b:(b:B)=>C, c:(c:C)=>D, d:(d:D)=>E):(a:A)=>E
function pipe<A,B,C,D,E,F>
    (a:(a:A)=>B, b:(b:B)=>C, c:(c:C)=>D, d:(d:D)=>E, e:(e:E)=>F):(a:A)=>F
function pipe<A,B,C,D,E,F,G>
    (a:(a:A)=>B, b:(b:B)=>C, c:(c:C)=>D, d:(d:D)=>E, e:(e:E)=>F,
     f:(f:G)=>G):(a:A)=>G

function pipe(...f:any) {
    const apply = (v: any, f:any) => f(v)
    return (a:any) => f.reduce(apply, a)
}

const all = <A>(...preds:((a:A) => boolean)[]) => (a:A) =>
    preds.reduce(
        (acc, curr) => acc && curr(a), 
        true);

const map = <A,B>(f:((a:A) =>B)) => (a:A[]) => a.map(f)

const reduce = <A,B>(f: ((acc:B, a:A)=>B)) => (initial:B) => (a:A[]) =>
    a.reduce(f,initial)


const groupBy = <A>(keyFunction:(a:A) => string) => (list:A[]):{[id: string]:A[]} =>
    list.reduce(
    (acc: {[id: string]: A[]}, curr:A) => {
        const key = keyFunction(curr);
        const group = acc[key];
        acc[key] = group ? [curr, ...group] : [curr];
        return acc
    },
    {})


const identity = <A>(a:A) => a;

const tap = <A>(f:(a:A)=>void) => (a:A) => { f(a); return a}

const mapValues = <A,B>(f:(a:A) => B) => (o: {[id:string]:A}) =>{
    const keys = Object.keys(o);
    return keys.reduce(
        (acc: {[id:string]: B}, curr: string) => {
            acc[curr] = f(o[curr]);
            return acc
        },
        {})}

const filterValues =
    <A, B extends {[id: string]:A}>(pred:(a:A) => boolean) =>
    (o:B) =>
    {
        return Object.keys(o).reduce((acc:{[id:string]:A}, curr) => {
            if(pred(o[curr])) {
                acc[curr] = o[curr]
            }
            return acc;
        }, {})
    }

const gte = (x:number) => (y:number) => x >= y
const lte = (x:number) => (y:number) => x <= y
const between = (min: number, max:number) =>
    all(
        lte(min),
        gte(max))

// end of library code

const convertStringToArray = (x:string) => x.split("")
const splitIntoLines = (s: string) => s.split("\n")

const countTwoThree = (o:{[id:string]:number}) =>
    Object.keys(o).reduce<[number, number]>(
        (acc: [number, number], curr: string) =>
            [ o[curr] === 2 ? 1 : acc[0],
              o[curr] === 3 ? 1 : acc[1]],
        [0,0])

const addThing = (acc: number[], curr: number[]) =>
    [acc[0] + curr[0], acc[1]+ curr[1]]


const solve = pipe(
    splitIntoLines,
    map(pipe(
        convertStringToArray,
        groupBy(identity),
        mapValues(x => x.length),
        filterValues(between(2,3)),
        countTwoThree,
    )),
    reduce (addThing) ([0,0]),
    tap(console.log),
    ((a:number[]) => a[0]*a[1])
)

//const solve = groupBy<string>(identity)(['a', 'b'])



describe('Part 1', () => {
    it('solves the provided test case', () => {
        const input = `abcdef
 bababc
 abbcde
 abcccd
 aabcdd
 abcdee
 ababab`

        expect(solve(input)).to.eq(12);
    })

    it('solves the puzzle example', () => {
        const input = `efmyhuxcqqldtwjzvisepargvo
efuyhuxckqldtwjrvrsbpargno
efmyhuxckqlxtwjxvisbpargoo
efmyhuxczqbdtwjzvisbpargjo
efmyhugckqldtwjzvisfpargnq
tfmyhuxckqljtwjzvisbpargko
efmyhuxckqldtvuzvisbpavgno
efmyhufcrqldtwjzvishpargno
tfmyhuxbkqlduwjzvisbpargno
efayhtxckqldbwjzvisbpargno
efgyhuxckuldtwjzvisbpardno
efmyhuxckuldtwizvisbpargqo
efmyhuxcknldtjjzvihbpargno
efmyhuxcnqddtwjzvisbpafgno
efmyhubokqldtwjzvisbpargdo
efmhhuxckqldtwdzvisbpjrgno
efmyhuxckqldtwjrcisbpargny
efmyhuxckqsdtwjzlisbpargng
effyhuxckqlqtwjzjisbpargno
nfmyhjxckqldtwjzcisbpargno
efmyhvxckqldtwszvwsbpargno
efmyhuxckqldtwutvisbpprgno
kfmyhuxckqldtwzuvisbpargno
efhyhtxckqldtwjmvisbpargno
efmyhuhckqldtwjzvisbpxwgno
efmyhuxcfqldtrjzvitbpargno
efmyhudckqldtwjfvisbparvno
ekmyhuxckqlstwjzvisbdargno
efmyhuxckqlxtwjftisbpargno
etsyhuxckqldtwjzvisbpargnf
exmyhusckqldtwjzvisbpakgno
efmyhubckqlrtljzvisbpargno
efmyhuxckwldtwjovizbpargno
efmyhulckqzdtwjzvisbpargpo
efmyhuxckbcdlwjzvisbpargno
zfmyhulckqbdtwjzvisbpargno
efmyquxckfldtwazvisbpargno
efxyhuxakqldtwjzvisupargno
efmlhuxckkedtwjzvisbpargno
efhyhuxwkqldtwjzvisbparjno
efmyhuxfkqldtwjzvisvparyno
efmyhuxckqfdtijzvisblargno
efmyhuxckqldtfjzvisbwhrgno
efmymuxcknldtwzzvisbpargno
eomybuxckqldtwkzvisbpargno
pfmyhuxckqldtwgzvasbpargno
vfmyhuxcoqldtwjzvisbparvno
eflyhuxckqldtwjzvirypargno
efmyvuxckqldtwizvisbpaqgno
epmyhuxckqldtwjzvesbparpno
efoyhuxckoldtwjmvisbpargno
efmyhuxckqydtwpzvisbpaqgno
efmyhuxckqldezbzvisbpargno
efmyhuxckqldtwjzvisboalxno
efmyhuxckqldtwuzvipbjargno
efmymuxcuqldtwjzvasbpargno
jfmyhuxckqldtwjzvzsbpargdo
nfmyhuxckqlntsjzvisbpargno
efmxhuxckqgdtwjzvisbparjno
efmyhuxckpldtpjzvpsbpargno
efmyhuxcyqldtwjhvisbpargqo
efmyhexgkqydtwjzvisbpargno
ffmyhuxckqldtwjzvisbpafgnk
efmyfuxckqldtwjpvisbpartno
efmyhoxckcmdtwjzvisbpargno
efmyhuxxkqldtwjzviabparyno
jfmyhuxakqldtwgzvisbpargno
efmjhuxckqcdtwjzvisbjargno
efmyhuxccqldtwjzxisbxargno
efmyhurckqldiwjzvrsbpargno
efmyhuxckasdtwjzvisboargno
efmyhvxckmldtwjgvisbpargno
efmyhuxckoldtwjuvisbpardno
efmyduxckqldtwjgvzsbpargno
ejmyhuxckqldtwbzvisbpargnb
efmymuxchqldtwjzvibbpargno
efmyhjxckqldtwjgvinbpargno
efmyhuxhyqldtwbzvisbpargno
efmyhuxckqldtwjzvisbpzignq
efmyuueckqldxwjzvisbpargno
qfmyhyxckqldtwizvisbpargno
efmyhupckqldtwjzvpgbpargno
efmycuxckqldtwjzvfdbpargno
efmyhugcrqldtwjfvisbpargno
efmyhexckqldtwjzvischargno
efmyhuxckqldtljzvasbpamgno
efmyzdxckqldtwjovisbpargno
efmyhuxccqldtwjzvdsbpaigno
ufmyhuxekqldtwjzvisbpargne
efmyhuxckqldfwozvisgpargno
afmyhuackqldtwjzvisbdargno
efmyauxckqldtwjzvisiparmno
efmysuxckqldtwjzvisbeaggno
efmyhuxckqldtwjzvisbgzigno
efryhuxlkqldtwozvisbpargno
lfmyhuxckqldtwjzvhsbparuno
efmyhzxckqldswjzvisqpargno
efmyhuxrkqldtwjzvisgpargco
efmyhudckqldtwjzyisbkargno
efmyhuacqqldtwjzviabpargno
jfmyhuxckqldtwvzvicbpargno
efmkhuxckqlftejzvisbpargno
nfmyhuxckqldnwjzvisbxargno
efmyhuxckqldtwjvvisjpyrgno
efmyhuxcmxldtwjzvisbpargto
efmyhuxckqldtwqbvpsbpargno
efmyhuxckzldjwjzvisbplrgno
efmywgxckqldtwxzvisbpargno
efmsguxckqldhwjzvisbpargno
nfmyhuxlkqldtwjzvisbgargno
etmyhuxckqldtwjzvqsbptrgno
efmyxuxckqldtfjzvisbyargno
cfmihuxckqldtwjzvisbpargnf
jfzyhuxckqldtwjzviscpargno
efmyhuxckqldtmjzvisbpbzgno
bfmyhuzckqldcwjzvisbpargno
efmyhuxckqldtmjzvmslpargno
efqyvuxckqldtwazvisbpargno
efmecrxckqldtwjzvisbpargno
efmyhuuckqldtwjzvisrpargnt
efmphuxckqldtwjzvisbparmho
ifmyhuxckqldtwjzvismpsrgno
efmyhuookqldywjzvisbpargno
efmyhfxckyldtwjnvisbpargno
efmyhxhckqldtwjzvisqpargno
efryhuxcfqldtwjzvisbparkno
efmyhutckqldpwjzvixbpargno
efmyoukckqldtwjzvisbpargko
efmyhuxckqldtwjzviseparynv
efmyhuxcksldvwjzvisbnargno
efmyhuxckqrdtwlzmisbpargno
efmyhuxcwqldtwjzviqapargno
eymyhuxckqrdtwkzvisbpargno
efmyhuxckqldtwjzpisopargnj
efmyhuxikqldtwjzvirupargno
efmyhuxcuzldtnjzvisbpargno
efmyhxxikqldtwjzvisbpalgno
efmyhuxceqldtwjzvdsbparguo
efmyhuxwkqldtwjmvisbparxno
efmyhuxpkqldtwjzvisfpargfo
efmyfuxckaldtwjzvirbpargno
efmyhuxckqrdtwjzvismprrgno
efmyhuxckqldzwjzvisbpnrgfo
efmyhfuckqldtwjyvisipargno
efmyhuxcpqlqfwjzvisbpargno
efmyyuxckqldtwjzvrsepargno
efmphuxckqlptqjzvisbpargno
efmyhuxnfqldtwjzvisbpmrgno
efmyhuxckqldtwjzkisnpnrgno
mfmyhuxckqldtwjzvisbzarcno
efmyhuxckqldtwlzviszpargwo
efmytuxckqndtwjqvisbpargno
efmyzuxckqldtwjzvisbaargjo
efmihuxckqlutwjzvimbpargno
efmyhuxckqldgwjzvixbparono
tfmyduxckqldtyjzvisbpargno
ejmyhuockqldtwjzvidbpargno
efmyheyckqkdtwjzvisbpargno
efmyhuxckqldtwjzoisbpargfj
efqyhuxcxqldtwxzvisbpargno
jfmyhaxckqldtwjzvisbvargno
hfmyhqxckqldtwjzvisbparvno
efmyhukckqlrtwjzvqsbpargno
efmyhuxckqldvwmzvisbparrno
efoyhuxckqldtwjzvilwpargno
ejmyhuxckqldtwjzxisbprrgno
efmyhuxckqldtsjzvisupdrgno
efzyhjxckqldtwjzvisbpasgno
ebmyhulckqldtwjzvisbpargnr
efmyhuxcjqlntwjzqisbpargno
efmlocxckqldtwjzvisbpargno
efmyhuxckqldtwjzvizkpargnm
ebmyhuxckqldtwjzvlfbpargno
efmyhuxckqldtwjyvisbpjrgnq
afmyhuxckqldtwjzvpsbpargnv
efmyxuxckqwdzwjzvisbpargno
efmyhuxskqlqthjzvisbpargno
efmyhuxckqldtwdzvisbearglo
mfmyhuxckqldtzjzvisbparggo
efmyhuqckqodtwjzvisbpadgno
efmyhuxctqldywjzvisspargno
efmyhuxckqqdtwjnvisbporgno
efmyhixckqldowjzvisbpaagno
efmyhuxckqldtsszvisbpargns
edmyhuxckqpdtwjzrisbpargno
efsyhuxckqldtijzvisbparano
efmyhuxckqxdzwjzviqbpargno
efmyhuxckqldtwjzviqqpsrgno
efmyhuockqlatwjzvisbpargho
efmyhuxckqldtwjzvishkavgno
vfmyhuxckqldtwjzvksbaargno
efmahuxckqudtwbzvisbpargno
ewmyhixckqudtwjzvisbpargno
efmywuxczqldtwjzvisbpargao
efmyhuqjkqldtwyzvisbpargno
efmyhuxekqldtwjzmksbpargno
efmyhuxcoqtdtwjzvinbpargno
ebmyhuxkkqldtwjzvisbdargno
ecmyhnxckqldtwnzvisbpargno
efmyhuxbkqldtwjzvksbpaigno
efayhuxckqidtwjzvisbpavgno
efmrhuxckqldswjzvisbpaugno
efmyhuuckqldtwjyvisipargno
xfmyhuxckqldawjzvosbpargno
efmyhuxckklhtwjzvisbpargnq
efmyhmxcaqldzwjzvisbpargno
efiyhuxcksldtwjzvisbpamgno
zfmyhuzckqldtwjzvisbparhno
efmyhuxckqlvtwjdvisbparsno
efmyhmxckaldtwjzmisbpargno
efmysuxcqoldtwjzvisbpargno
efmyhuxckqldtwjzvisbsargrb
effyhuxckqldtwjzvisbpwfgno
efmyhuxclqmdtwjzxisbpargno
edmohuxckqldtwjziisbpargno
efmyhuxckpldtwjzviubpaegno
efmyhuxcpqldtwjzjimbpargno
ehmyhuxckqldtwjzsisbpargnq
efmyhcxcdqldtwjzvisbqargno
efmjhuxckqldmwjzviybpargno
efeyhzxckqlxtwjzvisbpargno
efmyhuxczqadtwazvisbpargno
efmahuxckqldtwjzvisbpafgnl
efmyouxckqldtwjzvizbpacgno
emmrhuxckqldtwjzvisqpargno
exmyhuxckqlftwjnvisbpargno
efuyhuxckqldrwjzvisbpargnw
efmywuxfkqldtwjztisbpargno
efmyhuxdkqldtwjzvisbpqrzno
eemyhuxckqldrwjzvisbpajgno
efmyiuxckqldtbjzvrsbpargno
eqmyhuxckqldlwjzfisbpargno
efmyhuxckqlitwuzvisbpvrgno
ecoyhuxckqldtwjzvishpargno
efmyhuxckcldtwjzlisbparlno
efmyhsxcknldtwjfvisbpargno
efmyhuxckqldtwjrvosbpargbo
enmehuxckzldtwjzvisbpargno
hfmyhuxckqqdtwjzvisbpawgno
efmyhufckcjdtwjzvisbpargno
efmxhuxckqldthjzvisfpargno
efmyaukckqldtwjsvisbpargno
efmyhukckqldtwpzvisbpmrgno
dfmyhuxckqldtwjzvisbvarmno
afmbhuxckqldtwjzvssbpargno
efmyhuxchqldtwezvisbpargzo
efmphuxckqlxjwjzvisbpargno
efhyxuxckqldtwjzvisbpargko
sfmyhexckqldtwjzvisbqargno
efmghuxckqldtwjzvitbparnno`;

        expect(solve(input)).to.equal(0);
    })
});
