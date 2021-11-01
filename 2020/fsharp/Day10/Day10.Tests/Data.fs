namespace Day10.Tests

module Data =
    let split delim (s:string) = s.Split [|delim|]
    let lines = split '\n'
    let trim (s:string) = s.Trim()

    let example1 = "16
                    10
                    15
                    5
                    1
                    11
                    7
                    19
                    6
                    12
                    4".Split('\n') |> Array.map (trim >> int) |> List.ofArray 

    let myInput = "47
                    99
                    115
                    65
                    10
                    55
                    19
                    73
                    80
                    100
                    71
                    110
                    64
                    135
                    49
                    3
                    1
                    98
                    132
                    2
                    38
                    118
                    66
                    116
                    104
                    87
                    79
                    114
                    40
                    37
                    44
                    97
                    4
                    140
                    60
                    86
                    56
                    133
                    7
                    146
                    85
                    111
                    134
                    53
                    121
                    77
                    117
                    21
                    12
                    81
                    145
                    129
                    107
                    93
                    22
                    48
                    11
                    54
                    92
                    78
                    67
                    20
                    138
                    125
                    57
                    96
                    26
                    147
                    124
                    34
                    74
                    143
                    13
                    28
                    126
                    50
                    29
                    70
                    39
                    63
                    41
                    91
                    32
                    84
                    144
                    27
                    139
                    33
                    88
                    72
                    23
                    103
                    16".Split('\n') |> Array.map (trim >> int) |> List.ofArray


    let example2 = "28
                    33
                    18
                    42
                    31
                    14
                    46
                    20
                    48
                    47
                    24
                    23
                    49
                    45
                    19
                    38
                    39
                    11
                    1
                    32
                    25
                    35
                    8
                    17
                    7
                    9
                    4
                    2
                    34
                    10
                    3".Split('\n') |> Array.map (trim >> int) |> List.ofArray 
