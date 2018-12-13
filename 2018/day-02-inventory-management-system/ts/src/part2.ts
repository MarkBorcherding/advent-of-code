import { reduceUntil } from '@aoc/aoc';
import { expect } from 'chai';

type NotFound = {previous: string[]}
type Found = {matching: string[]}
type Possible = Found | NotFound

const isFound = (x: (NotFound | Found)):x is Found => (<NotFound>x).previous === undefined

const offByOneLetter = (a: string) => (b:string) =>
    1 === a.split("").reduce((acc, curr, index) => curr !== b[index] ? acc + 1 : acc, 0)


const testForOffByOne = (acc:Possible, curr: string):Possible => {
    if(isFound(acc)) return acc;
    const found = acc.previous.find(offByOneLetter(curr))
    if(found) {
        return {matching: [found, curr]}
    } else {
        return {previous: [...acc.previous, curr] }
    }
}

const matching = ([a,b]: string[]) =>
    a.split("").reduce((acc, curr, index) => curr === b[index] ? acc + curr : acc, "" )



const solve = (a: string) => {
    const lines = a.split("\n")
    const result = reduceUntil (isFound) (testForOffByOne) ({previous:[]}) (lines)
    if(isFound(result)){
        return matching(result.matching)
    } else {
        return "I give up"
    }

}

describe('Part 2', () => {
    it('solves the provided test case', () => {
        const input = `abcde
fghij
klmno
pqrst
fguij
axcye
wvxyz`

        expect(solve(input)).to.eq('fgij');
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

         expect(solve(input)).to.equal(' efmyhuckqldtwjyvisipargno');
     })
});
