// Learn more about F# at http://docs.microsoft.com/dotnet/fsharp

open System
open System.Text.RegularExpressions

type PassportAttributeType = BirthYear | IssueYear | ExpirationYear | Height | HairColor | EyeColor | PassportID | CountryID

type PassportAttribute = PassportAttributeType * string

type PossiblePassport = PassportAttribute list

let decode abv = 
    match abv with 
        | "byr" -> Some BirthYear
        | "iyr" -> Some IssueYear
        | "eyr" -> Some ExpirationYear
        | "hgt" -> Some Height
        | "hcl" -> Some HairColor
        | "ecl" -> Some EyeColor
        | "pid" -> Some PassportID
        | "cid" -> Some CountryID
        | _ -> None

type Passport = {
    BirthYear: string;
    IssueYear: string;
    ExpirationYear: string; 
    Height: string;
    HairColor: string;
    EyeColor: string
    PassportID: string;
    CountryID: string;
}

let splitSingleKey (key: string) =
    let arr = key.Split(":")
    let k = decode(arr.[0]).Value
    let v = arr.[1]
    (k, v)


let splitByKey (line:string) : PossiblePassport =
    line.Split(" ") |>
    Array.map splitSingleKey |>
    Array.toList


let parse (input:string) : PossiblePassport list =
    let formSingleLine (s:string) =  
        let split = s.Split("\n")
        String.Join(" ", split)

    (Array.map (formSingleLine >> splitByKey) (input.Split "\n\n")) |> 
        Array.toList

let allAttributes = Set.ofList [
                        BirthYear;
                        IssueYear; 
                        ExpirationYear; 
                        Height; 
                        HairColor;
                        EyeColor; 
                        PassportID; 
                        CountryID
                    ]
let allSansCountry = allAttributes.Remove(CountryID)
    
let isValid (possiblePassport: PossiblePassport) =
    let includedAttributes = possiblePassport |>
                                List.map (fun (k,v) -> k) |>
                                Set.ofList
    match includedAttributes with 
        | _ when includedAttributes.Equals(allAttributes) -> true
        | _ when includedAttributes.Equals(allSansCountry) -> true
        | _ -> false

let between min max (s:string) =
    try
        s |> int |> (fun v -> v >= min && v <= max)
    with
        | :? FormatException -> false
        | :? OverflowException -> false


let (|Regex|_|) pattern input =
    let m = Regex.Match(input, pattern)
    if m.Success then Some(List.tail [ for g in m.Groups -> g.Value ])
    else None


//hgt (Height) - a number followed by either cm or in:
//
//    If cm, the number must be at least 150 and at most 193.
//    If in, the number must be at least 59 and at most 76.
//
let isHeight h = 
    match h with 
        | Regex @"(\d+)cm" [v] -> between 150 193 v
        | Regex @"(\d+)in" [v] -> between 59 76 v
        | _ -> false



//hcl (Hair Color) - a # followed by exactly six characters 0-9 or a-f.
let isHairColor c = 
    match c with 
        | Regex @"#[a-f0-9]{6}" [] -> true
        | _ -> false

let validEyeColors = 
    Set.ofList [
        "amb"; 
        "blu"; 
        "brn"; 
        "gry"; 
        "grn"; 
        "hzl"; 
        "oth"
    ]

let isEyeColor c = validEyeColors.Contains c

let validAttribute (attr: PassportAttribute) = 
    match attr with 
        | (BirthYear, year) -> between 1920 2002 year
        | (IssueYear, year) -> between 2010 2020 year
        | (ExpirationYear, year) -> between 2020 2030 year
        | (Height, height) -> isHeight height
        | (HairColor, color) -> isHairColor color
        | (EyeColor, color) ->  isEyeColor color
        | (PassportID, id) -> id.Length = 9 && between 0 999999999 id
        | (CountryID, _) -> true

let validAtttributes (attrs: PossiblePassport) =
    let m = List.map validAttribute attrs
    List.forall (id) m



[<EntryPoint>]
let main argv =
    let count input =
        input |>
        parse |>
        List.countBy isValid

    // part 1
    let sampleCount = count Day04.Data.sample
    let myCount = count Day04.Data.input


    // part 2
    let valider input =
        input |>
        parse |>
        List.filter isValid |>
        List.filter validAtttributes

    let s = valider Day04.Data.sample |> List.length
    let m = valider Day04.Data.input |> List.length


    0 // return an integer exit code