package day01

class Input {
    companion object {
        val example = listOf(
            199,
            200,
            208,
            210,
            200,
            207,
            240,
            269,
            260,
            263)

        val mine = listOf(
            157,
            148,
            149,
            146,
            144,
            145,
            162,
            163,
            164,
            166,
            173,
            186,
            183,
            164,
            168,
            175,
            176,
            172,
            170,
            183,
            196,
            204,
            216,
            224,
            225,
            228,
            231,
            215,
            218,
            225,
            229,
            230,
            232,
            238,
            237,
            240,
            261,
            263,
            262,
            257,
            270,
            278,
            279,
            280,
            284,
            299,
            300,
            311,
            312,
            311,
            312,
            326,
            327,
            326,
            336,
            338,
            344,
            350,
            351,
            352,
            354,
            373,
            376,
            382,
            383,
            381,
            390,
            396,
            400,
            408,
            421,
            422,
            423,
            428,
            431,
            432,
            444,
            437,
            438,
            458,
            427,
            413,
            423,
            425,
            426,
            424,
            428,
            443,
            446,
            459,
            465,
            478,
            482,
            485,
            498,
            522,
            528,
            535,
            536,
            528,
            507,
            525,
            526,
            528,
            523,
            527,
            524,
            525,
            532,
            534,
            552,
            551,
            561,
            563,
            562,
            568,
            575,
            577,
            587,
            588,
            593,
            594,
            597,
            600,
            605,
            607,
            615,
            611,
            617,
            618,
            622,
            644,
            646,
            634,
            631,
            635,
            633,
            636,
            641,
            643,
            644,
            645,
            641,
            659,
            661,
            659,
            660,
            683,
            695,
            696,
            704,
            705,
            719,
            720,
            707,
            722,
            723,
            727,
            728,
            730,
            731,
            740,
            744,
            733,
            718,
            711,
            712,
            720,
            719,
            729,
            739,
            748,
            754,
            759,
            781,
            797,
            796,
            802,
            811,
            812,
            819,
            815,
            826,
            828,
            841,
            844,
            849,
            888,
            893,
            895,
            900,
            901,
            904,
            905,
            922,
            921,
            922,
            938,
            963,
            971,
            973,
            983,
            991,
            994,
            1001,
            1023,
            1027,
            1035,
            1059,
            1060,
            1089,
            1098,
            1124,
            1125,
            1128,
            1122,
            1123,
            1113,
            1115,
            1113,
            1141,
            1146,
            1150,
            1151,
            1152,
            1153,
            1143,
            1144,
            1146,
            1162,
            1154,
            1153,
            1154,
            1165,
            1169,
            1168,
            1171,
            1178,
            1179,
            1180,
            1172,
            1176,
            1186,
            1188,
            1189,
            1188,
            1187,
            1192,
            1190,
            1189,
            1184,
            1194,
            1195,
            1200,
            1194,
            1206,
            1207,
            1216,
            1218,
            1186,
            1187,
            1184,
            1187,
            1190,
            1214,
            1239,
            1240,
            1250,
            1249,
            1277,
            1278,
            1279,
            1314,
            1316,
            1321,
            1345,
            1344,
            1351,
            1364,
            1367,
            1368,
            1370,
            1373,
            1365,
            1361,
            1355,
            1354,
            1365,
            1360,
            1358,
            1356,
            1357,
            1363,
            1364,
            1373,
            1377,
            1387,
            1381,
            1392,
            1396,
            1397,
            1399,
            1406,
            1410,
            1429,
            1430,
            1431,
            1437,
            1443,
            1448,
            1449,
            1465,
            1466,
            1461,
            1462,
            1464,
            1471,
            1488,
            1489,
            1490,
            1500,
            1502,
            1528,
            1549,
            1551,
            1552,
            1551,
            1543,
            1544,
            1543,
            1546,
            1547,
            1551,
            1555,
            1563,
            1539,
            1525,
            1524,
            1523,
            1548,
            1513,
            1522,
            1508,
            1507,
            1515,
            1498,
            1505,
            1504,
            1505,
            1506,
            1507,
            1510,
            1516,
            1520,
            1540,
            1547,
            1548,
            1547,
            1522,
            1523,
            1533,
            1561,
            1588,
            1589,
            1591,
            1592,
            1594,
            1596,
            1608,
            1624,
            1628,
            1638,
            1639,
            1641,
            1625,
            1627,
            1629,
            1648,
            1653,
            1678,
            1679,
            1699,
            1703,
            1697,
            1700,
            1698,
            1699,
            1715,
            1714,
            1716,
            1717,
            1720,
            1722,
            1721,
            1722,
            1716,
            1720,
            1742,
            1765,
            1767,
            1757,
            1756,
            1755,
            1761,
            1784,
            1785,
            1789,
            1798,
            1806,
            1809,
            1821,
            1822,
            1831,
            1826,
            1818,
            1817,
            1814,
            1815,
            1818,
            1819,
            1820,
            1827,
            1830,
            1831,
            1832,
            1840,
            1841,
            1842,
            1848,
            1849,
            1850,
            1851,
            1861,
            1863,
            1860,
            1861,
            1855,
            1863,
            1862,
            1864,
            1865,
            1887,
            1902,
            1925,
            1939,
            1945,
            1944,
            1943,
            1947,
            1964,
            1986,
            1987,
            1986,
            1989,
            1979,
            1984,
            1986,
            1994,
            1996,
            2001,
            2002,
            2005,
            2009,
            2022,
            2024,
            2025,
            2029,
            2013,
            2014,
            2017,
            2018,
            2017,
            2019,
            2020,
            2009,
            2007,
            2006,
            1982,
            1984,
            1986,
            1991,
            1994,
            1982,
            1991,
            1989,
            1995,
            1996,
            1997,
            1998,
            1997,
            2004,
            2005,
            2030,
            2062,
            2064,
            2076,
            2077,
            2079,
            2080,
            2084,
            2103,
            2104,
            2110,
            2104,
            2105,
            2106,
            2118,
            2124,
            2127,
            2125,
            2121,
            2127,
            2133,
            2135,
            2141,
            2139,
            2136,
            2138,
            2146,
            2140,
            2141,
            2156,
            2172,
            2181,
            2170,
            2173,
            2195,
            2194,
            2199,
            2203,
            2228,
            2230,
            2234,
            2204,
            2212,
            2214,
            2200,
            2201,
            2200,
            2197,
            2201,
            2204,
            2230,
            2240,
            2242,
            2255,
            2263,
            2271,
            2273,
            2274,
            2273,
            2277,
            2278,
            2285,
            2286,
            2297,
            2298,
            2297,
            2310,
            2313,
            2309,
            2311,
            2314,
            2322,
            2320,
            2316,
            2317,
            2339,
            2338,
            2350,
            2378,
            2379,
            2387,
            2391,
            2390,
            2391,
            2396,
            2398,
            2406,
            2425,
            2433,
            2430,
            2421,
            2422,
            2440,
            2449,
            2445,
            2466,
            2479,
            2477,
            2479,
            2485,
            2481,
            2490,
            2491,
            2492,
            2496,
            2508,
            2505,
            2487,
            2492,
            2493,
            2482,
            2499,
            2515,
            2516,
            2543,
            2574,
            2575,
            2577,
            2578,
            2569,
            2556,
            2554,
            2557,
            2559,
            2562,
            2571,
            2595,
            2596,
            2598,
            2599,
            2603,
            2602,
            2615,
            2614,
            2610,
            2623,
            2632,
            2626,
            2642,
            2643,
            2675,
            2681,
            2689,
            2706,
            2708,
            2713,
            2714,
            2703,
            2691,
            2692,
            2693,
            2700,
            2710,
            2711,
            2712,
            2711,
            2712,
            2716,
            2673,
            2674,
            2694,
            2715,
            2723,
            2736,
            2759,
            2768,
            2773,
            2767,
            2757,
            2752,
            2749,
            2752,
            2758,
            2753,
            2752,
            2754,
            2760,
            2791,
            2792,
            2803,
            2804,
            2797,
            2800,
            2797,
            2807,
            2811,
            2814,
            2816,
            2819,
            2837,
            2838,
            2843,
            2841,
            2848,
            2853,
            2859,
            2868,
            2854,
            2864,
            2845,
            2848,
            2831,
            2830,
            2829,
            2840,
            2838,
            2831,
            2836,
            2856,
            2854,
            2870,
            2863,
            2865,
            2866,
            2867,
            2895,
            2892,
            2893,
            2911,
            2909,
            2918,
            2923,
            2924,
            2893,
            2888,
            2892,
            2893,
            2898,
            2893,
            2920,
            2930,
            2931,
            2930,
            2926,
            2933,
            2939,
            2957,
            2964,
            2968,
            2969,
            2971,
            2985,
            2986,
            2990,
            2988,
            2977,
            2971,
            2970,
            2978,
            2964,
            2997,
            3007,
            3015,
            3013,
            3015,
            2998,
            3000,
            3024,
            3034,
            3045,
            3067,
            3073,
            3074,
            3075,
            3076,
            3084,
            3091,
            3089,
            3088,
            3095,
            3082,
            3085,
            3086,
            3082,
            3080,
            3096,
            3110,
            3113,
            3114,
            3117,
            3120,
            3125,
            3128,
            3129,
            3131,
            3130,
            3136,
            3130,
            3131,
            3138,
            3141,
            3147,
            3153,
            3152,
            3161,
            3162,
            3180,
            3183,
            3197,
            3203,
            3205,
            3195,
            3202,
            3209,
            3216,
            3217,
            3230,
            3235,
            3238,
            3245,
            3248,
            3269,
            3262,
            3266,
            3267,
            3268,
            3272,
            3265,
            3264,
            3268,
            3275,
            3276,
            3283,
            3277,
            3276,
            3277,
            3278,
            3298,
            3311,
            3314,
            3318,
            3327,
            3330,
            3333,
            3349,
            3353,
            3354,
            3347,
            3357,
            3359,
            3361,
            3390,
            3389,
            3398,
            3411,
            3418,
            3409,
            3422,
            3423,
            3425,
            3426,
            3442,
            3444,
            3457,
            3458,
            3459,
            3471,
            3454,
            3455,
            3457,
            3469,
            3470,
            3496,
            3495,
            3492,
            3509,
            3512,
            3511,
            3514,
            3513,
            3516,
            3519,
            3522,
            3533,
            3539,
            3541,
            3537,
            3547,
            3548,
            3552,
            3554,
            3556,
            3559,
            3560,
            3568,
            3571,
            3580,
            3582,
            3601,
            3602,
            3625,
            3623,
            3625,
            3633,
            3640,
            3655,
            3657,
            3659,
            3660,
            3659,
            3665,
            3666,
            3672,
            3698,
            3707,
            3706,
            3712,
            3713,
            3728,
            3727,
            3724,
            3747,
            3737,
            3733,
            3739,
            3736,
            3757,
            3758,
            3766,
            3768,
            3771,
            3776,
            3785,
            3782,
            3790,
            3792,
            3800,
            3779,
            3781,
            3782,
            3816,
            3824,
            3832,
            3831,
            3842,
            3848,
            3847,
            3848,
            3851,
            3840,
            3848,
            3849,
            3854,
            3871,
            3870,
            3872,
            3877,
            3885,
            3899,
            3908,
            3913,
            3914,
            3910,
            3909,
            3910,
            3926,
            3938,
            3951,
            3952,
            3949,
            3978,
            3980,
            3981,
            3984,
            3980,
            3981,
            4000,
            4001,
            4006,
            4007,
            4024,
            4039,
            4040,
            4048,
            4036,
            4041,
            4040,
            4052,
            4065,
            4068,
            4043,
            4048,
            4037,
            4043,
            4046,
            4048,
            4049,
            4056,
            4059,
            4063,
            4068,
            4080,
            4077,
            4075,
            4076,
            4069,
            4038,
            4037,
            4040,
            4027,
            4028,
            4034,
            4053,
            4057,
            4058,
            4061,
            4059,
            4064,
            4065,
            4069,
            4071,
            4073,
            4075,
            4077,
            4082,
            4096,
            4093,
            4104,
            4112,
            4105,
            4106,
            4109,
            4093,
            4100,
            4108,
            4109,
            4134,
            4135,
            4165,
            4146,
            4152,
            4162,
            4171,
            4173,
            4181,
            4184,
            4185,
            4189,
            4192,
            4196,
            4194,
            4209,
            4221,
            4222,
            4200,
            4217,
            4216,
            4217,
            4216,
            4221,
            4231,
            4227,
            4230,
            4227,
            4240,
            4241,
            4242,
            4222,
            4243,
            4248,
            4245,
            4236,
            4237,
            4256,
            4261,
            4248,
            4250,
            4254,
            4255,
            4258,
            4261,
            4262,
            4266,
            4274,
            4290,
            4291,
            4290,
            4312,
            4323,
            4336,
            4337,
            4333,
            4328,
            4330,
            4293,
            4297,
            4309,
            4327,
            4328,
            4356,
            4358,
            4332,
            4346,
            4347,
            4370,
            4379,
            4382,
            4391,
            4400,
            4398,
            4406,
            4417,
            4422,
            4420,
            4421,
            4426,
            4424,
            4420,
            4421,
            4422,
            4401,
            4402,
            4428,
            4437,
            4444,
            4448,
            4451,
            4452,
            4451,
            4454,
            4463,
            4468,
            4467,
            4476,
            4473,
            4477,
            4478,
            4482,
            4514,
            4515,
            4556,
            4559,
            4560,
            4559,
            4561,
            4563,
            4564,
            4562,
            4568,
            4577,
            4589,
            4590,
            4611,
            4599,
            4607,
            4595,
            4596,
            4583,
            4597,
            4595,
            4601,
            4602,
            4607,
            4608,
            4609,
            4633,
            4636,
            4647,
            4654,
            4655,
            4622,
            4623,
            4625,
            4651,
            4653,
            4654,
            4657,
            4661,
            4670,
            4677,
            4678,
            4679,
            4680,
            4678,
            4679,
            4682,
            4680,
            4678,
            4676,
            4678,
            4680,
            4678,
            4683,
            4689,
            4705,
            4716,
            4725,
            4723,
            4728,
            4729,
            4730,
            4746,
            4757,
            4755,
            4762,
            4791,
            4785,
            4787,
            4792,
            4793,
            4790,
            4793,
            4794,
            4807,
            4813,
            4804,
            4826,
            4827,
            4840,
            4878,
            4880,
            4883,
            4884,
            4875,
            4887,
            4889,
            4922,
            4929,
            4928,
            4933,
            4934,
            4945,
            4943,
            4944,
            4945,
            4947,
            4944,
            4957,
            4955,
            4956,
            4944,
            4946,
            4954,
            4961,
            4967,
            4981,
            4971,
            4980,
            4981,
            4989,
            4991,
            5000,
            5017,
            5016,
            5017,
            5016,
            5018,
            5032,
            5033,
            5038,
            5039,
            5041,
            5043,
            5059,
            5068,
            5070,
            5074,
            5075,
            5076,
            5088,
            5099,
            5100,
            5105,
            5122,
            5123,
            5124,
            5126,
            5118,
            5116,
            5121,
            5115,
            5125,
            5128,
            5133,
            5143,
            5142,
            5143,
            5150,
            5145,
            5146,
            5148,
            5154,
            5155,
            5166,
            5164,
            5180,
            5173,
            5168,
            5167,
            5169,
            5175,
            5176,
            5204,
            5203,
            5204,
            5206,
            5210,
            5204,
            5205,
            5206,
            5207,
            5205,
            5226,
            5233,
            5235,
            5239,
            5241,
            5242,
            5261,
            5266,
            5260,
            5268,
            5272,
            5278,
            5280,
            5281,
            5290,
            5295,
            5296,
            5306,
            5319,
            5344,
            5362,
            5364,
            5377,
            5381,
            5385,
            5368,
            5391,
            5392,
            5381,
            5397,
            5398,
            5405,
            5385,
            5395,
            5396,
            5401,
            5407,
            5408,
            5402,
            5400,
            5401,
            5404,
            5414,
            5415,
            5418,
            5427,
            5413,
            5408,
            5419,
            5440,
            5445,
            5444,
            5439,
            5443,
            5448,
            5449,
            5448,
            5475,
            5477,
            5481,
            5474,
            5476,
            5480,
            5497,
            5494,
            5496,
            5505,
            5506,
            5509,
            5517,
            5518,
            5521,
            5510,
            5511,
            5513,
            5514,
            5513,
            5528,
            5536,
            5523,
            5525,
            5526,
            5524,
            5525,
            5527,
            5528,
            5534,
            5538,
            5554,
            5560,
            5563,
            5564,
            5571,
            5586,
            5590,
            5596,
            5597,
            5603,
            5624,
            5599,
            5609,
            5599,
            5618,
            5620,
            5608,
            5623,
            5627,
            5629,
            5630,
            5632,
            5640,
            5637,
            5638,
            5643,
            5653,
            5650,
            5649,
            5658,
            5656,
            5654,
            5673,
            5672,
            5673,
            5675,
            5676,
            5677,
            5672,
            5682,
            5681,
            5680,
            5671,
            5674,
            5679,
            5685,
            5687,
            5691,
            5694,
            5718,
            5720,
            5721,
            5719,
            5716,
            5717,
            5719,
            5711,
            5712,
            5713,
            5712,
            5711,
            5712,
            5711,
            5704,
            5709,
            5710,
            5723,
            5720,
            5719,
            5720,
            5725,
            5724,
            5728,
            5729,
            5747,
            5745,
            5747,
            5748,
            5752,
            5749,
            5763,
            5766,
            5767,
            5775,
            5782,
            5784,
            5785,
            5787,
            5788,
            5787,
            5792,
            5787,
            5788,
            5787,
            5789,
            5792,
            5793,
            5820,
            5827,
            5843,
            5844,
            5864,
            5875,
            5877,
            5890,
            5895,
            5896,
            5909,
            5932,
            5944,
            5951,
            5960,
            5983,
            5996,
            6003,
            6028,
            6043,
            6046,
            6038,
            6053,
            6056,
            6069,
            6063,
            6059,
            6064,
            6065,
            6077,
            6075,
            6074,
            6075,
            6091,
            6108,
            6109,
            6103,
            6100,
            6108,
            6130,
            6131,
            6158,
            6162,
            6176,
            6166,
            6168,
            6170,
            6181,
            6180,
            6179,
            6180,
            6183,
            6184,
            6187,
            6186,
            6185,
            6182,
            6194,
            6190,
            6193,
            6222,
            6241,
            6243,
            6233,
            6222,
            6248,
            6250,
            6251,
            6265,
            6269,
            6270,
            6272,
            6285,
            6284,
            6280,
            6273,
            6286,
            6287,
            6292,
            6307,
            6311,
            6317,
            6316,
            6317,
            6316,
            6317,
            6314,
            6316,
            6291,
            6293,
            6323,
            6327,
            6328,
            6327,
            6322,
            6321,
            6330,
            6332,
            6335,
            6333,
            6351,
            6349,
            6346,
            6347,
            6346,
            6364,
            6374,
            6383,
            6395,
            6398,
            6406,
            6418,
            6419,
            6418,
            6413,
            6414,
            6415,
            6416,
            6399,
            6400,
            6401,
            6399,
            6382,
            6379,
            6380,
            6386,
            6387,
            6373,
            6372,
            6396,
            6397,
            6415,
            6423,
            6424,
            6433,
            6438,
            6445,
            6446,
            6447,
            6448,
            6450,
            6446,
            6464,
            6447,
            6452,
            6464,
            6466,
            6477,
            6491,
            6489,
            6490,
            6503,
            6528,
            6562,
            6564,
            6581,
            6579,
            6580,
            6594,
            6595,
            6609,
            6619,
            6621,
            6641,
            6648,
            6693,
            6686,
            6693,
            6677,
            6700,
            6706,
            6707,
            6710,
            6735,
            6745,
            6746,
            6747,
            6748,
            6750,
            6753,
            6755,
            6756,
            6759,
            6760,
            6771,
            6770,
            6775,
            6785,
            6788,
            6793,
            6796,
            6797,
            6806,
            6814,
            6821,
            6822,
            6823,
            6825,
            6827,
            6841,
            6846,
            6841,
            6834,
            6836,
            6837,
            6815,
            6824,
            6830,
            6837,
            6841,
            6834,
            6835,
            6836,
            6826,
            6841,
            6835,
            6795,
            6794,
            6795,
            6793,
            6794,
            6795,
            6804,
            6816,
            6817,
            6819,
            6830,
            6835,
            6840,
            6845,
            6853,
            6897,
            6896,
            6894,
            6896,
            6899,
            6897,
            6903,
            6886,
            6889,
            6890,
            6891,
            6890,
            6891,
            6894,
            6888,
            6905,
            6906,
            6916,
            6917,
            6921,
            6920,
            6924,
            6925,
            6939,
            6958,
            6968,
            6969,
            6974,
            6977,
            6975,
            6971,
            6963,
            6964,
            6974,
            6975,
            6976,
            6977,
            6971,
            6969,
            6977,
            7003,
            6985,
            6993,
            6997,
            6999,
            7000,
            7001,
            6999,
            7000,
            7004,
            7003,
            7017,
            7033,
            7053,
            7058,
            7066,
            7067,
            7064,
            7066,
            7062,
            7063,
            7088,
            7093,
            7096,
            7106,
            7110,
            7116,
            7124,
            7125,
            7128,
            7150,
            7152,
            7154,
            7159,
            7161,
            7162,
            7144,
            7176,
            7183,
            7185,
            7172,
            7208,
            7207,
            7222,
            7225,
            7226,
            7222,
            7210,
            7211,
            7212,
            7238,
            7231,
            7221,
            7236,
            7237,
            7234,
            7235,
            7253,
            7249,
            7253,
            7263,
            7260,
            7259,
            7260,
            7261,
            7263,
            7241,
            7243,
            7257,
            7260,
            7261,
            7275,
            7258,
            7263,
            7274,
            7279,
            7280,
            7289,
            7307,
            7289,
            7301,
            7307,
            7309,
            7317,
            7337,
            7360,
            7364,
            7375,
            7373,
            7377,
            7403,
            7415,
            7438,
            7439,
            7438,
            7442,
            7445,
            7446,
            7450,
            7452,
            7453,
            7460,
            7468,
            7472,
            7478,
            7474,
            7487,
            7486,
            7487,
            7488,
            7492,
            7510,
            7509,
            7506,
            7507,
            7512,
            7516,
            7519,
            7514,
            7525,
            7545,
            7553,
            7554,
            7560,
            7561,
            7560,
            7561,
            7564,
            7571,
            7601,
            7605,
            7628,
            7629,
            7642,
            7651,
            7682,
            7684,
            7685,
            7698,
            7699,
            7713,
            7734,
            7753,
            7755,
            7760,
            7767,
            7775,
            7776,
            7777,
            7760,
            7763,
            7770,
            7758,
            7769,
            7765,
            7772,
            7777,
            7774,
            7780,
            7781,
            7785,
            7783,
            7800,
            7801,
            7799,
            7804,
            7805,
            7814,
            7815,
            7801,
            7802,
            7803,
            7806,
            7808,
            7810,
            7816,
            7821,
            7796,
            7795,
            7793,
            7792,
            7769,
            7770,
            7777,
            7771,
            7772,
            7773,
            7775,
            7776,
            7778,
            7766,
            7767,
            7768,
            7774,
            7775,
            7780,
            7781,
            7782,
            7788,
            7791,
            7796,
            7798,
            7813,
            7814,
            7817,
            7824,
            7825,
            7826,
            7828,
            7843,
            7867,
            7870,
            7872,
            7875,
            7877,
            7878,
            7888,
            7893,
            7902,
            7904,
            7911,
            7914,
            7915,
            7919,
            7915,
            7945,
            7946,
            7952,
            7954,
            7931,
            7935,
            7936,
            7900,
            7915,
            7920,
            7911,
            7914,
            7925,
            7937,
            7942,
            7974,
            7976,
            7989,
            7993,
            8006,
            8007,
            8010,
            8016,
            8020,
            8026)
    }
}