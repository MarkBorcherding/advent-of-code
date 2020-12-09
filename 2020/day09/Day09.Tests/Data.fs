module Day09.Tests.Data

    let split (delim: string) (s: string) = s.Split(delim)
    let trim (s: string) = s.Trim()
    
    let example = "35
            20
            15
            25
            47
            40
            62
            55
            65
            95
            102
            117
            150
            182
            127
            219
            299
            277
            309
            576" |> split "\n" |> Array.map (trim >> int64) |> List.ofArray
            
    let myInput ="26
36
37
9
8
22
41
5
17
44
40
31
10
33
30
50
24
4
12
46
39
45
42
7
27
13
58
11
14
53
9
15
23
18
16
21
17
49
19
20
32
31
22
30
24
35
28
33
25
47
57
26
27
29
83
34
37
36
59
46
39
51
44
54
56
48
49
100
62
50
52
72
53
55
60
96
61
91
65
70
85
87
88
114
83
113
92
93
97
104
142
99
102
103
153
105
108
115
116
148
144
152
177
135
167
171
201
256
182
176
252
185
190
196
203
202
348
240
208
292
213
300
323
301
315
367
302
502
393
357
353
358
390
760
361
375
492
710
398
405
448
509
421
594
505
566
810
690
603
924
655
1317
711
823
714
1171
719
736
759
1080
773
803
819
953
1528
869
1195
1522
1071
1509
1169
2270
1314
1514
1369
1366
1425
1430
2620
2125
1455
1830
1495
1532
4045
1576
1622
2397
1822
2501
3331
2240
2385
2664
2942
2483
2680
2683
6285
2791
2796
2855
2987
4522
2950
3108
3198
3317
4207
3398
3816
5031
4809
4062
4868
4625
5667
5049
5338
5163
5587
5363
7318
6506
5646
5651
7405
5937
7214
9874
6306
10612
7379
11586
9708
9179
15648
8871
8687
16263
9674
10212
10387
15046
15901
19548
11009
31549
40236
11297
18965
13151
17087
19920
16014
22320
17766
16558
17558
30262
17866
18361
19083
19984
19886
33617
39878
21396
26343
22306
24448
24160
27311
27855
63879
29165
35097
32572
47775
33572
34324
40072
57630
35919
53325
36227
37444
38969
44046
41282
45844
43702
45556
58020
46466
48608
51471
55166
94135
80653
70016
66144
70243
80251
83910
76413
72146
73363
77509
88915
73671
103576
99302
84984
188560
89258
181085
92022
95074
97937
136160
158162
128529
136387
143379
138290
168180
142389
157273
145509
149776
147034
169531
158655
162586
162929
191324
281669
174242
258003
187195
187096
189959
193011
226466
264689
264916
266819
274677
389395
301044
287898
320202
292543
308095
342787
309620
480909
321584
325515
438931
374291
361338
361437
532680
377055
419477
382970
607476
491155
684166
531735
541496
635135
602163
1216846
580441
600638
744992
617715
631204
1022890
647099
686952
686853
722775
735629
738393
738492
1271073
1903798
1067136
874125
1032651
1149450
1073231
1353344
1121937
1181079
1613092
1231842
1198156
1750088
1248919
1264814
1278303
1333952
2436941
2590651
1805529
1458404
2222681
2936449
1941261
1906776
1947356
2105882
2980007
2872025
2195168
2455889
2320093
2303016
2379235
2429998
2447075
2707323
2513733
2736707
2543117
3263933
5086558
3365180
4136429
3399665
3405760
4053238
4863210
3848037
3854132
4485117
4758905
4498184
4515261
4574403
4816749
4623109
4682251
4826310
5807050
4960808
5056850
5250440
8422030
5908297
6629113
6764845
7219312
9361394
7897849
7253797
8422440
8717342
9932691
8339249
9138370
12962358
10489301
13383248
9631253
9439858
9305360
16126239
9787118
10017658
10211248
16392167
14611834
13393958
17152003
15104094
16615191
14473109
15151646
15593046
19950349
17056591
18936613
25032904
17477619
18443730
19071111
27108872
19226976
18745218
31230333
19516608
19804776
36342516
20228906
23605206
27867067
31668425
31837688
36844097
35101995
43969517
29624755
36704595
32649637
35500321
34534210
36414232
35921349
38298087
37188948
68010941
38974124
62714735
38261826
39321384
39745514
64726750
43834112
48095973
60309801
130725676
61293180
67183847
66329350
62274392
87841487
110163462
99283925
72689269
70034531
70455559
75388356
73110297
75450774
76163072
77235950
149484846
77583210
78007340
79066898
132308923
127001142
114425323
131748739
133982449
123567572
134403477
128603742
132729951
137662748
140490090
104054607
145799566
148038769
232658349
143565856
148498653
200111439
179505381
153399022
154819160
155590550
202634470
157074238
213470375
218479930
248407772
238458084
310409710
272066225
227622179
252093376
289365422
286161401
258873767
396446541
247620463
439560423
291604625
430256649
406912536
382441339
308218182
395532322
402439623
311893398
466080263
359708708
370544613
446102109
648736579
479715555
499688404
475242642
530939992
575526823
545035168
506494230
577766026
539225088
986209785
555838645
599822807
603498023
620111580
671602106
667926890
990656193
861612585
730253321
682438011
805810817
834951350
925817664
921344751
954958197
1133604671
1006182634
1014467730
1062332875
1432311894
1045719318
1868143692
1223609603
1095063733
1609680657
1155661452
1203320830
1271424913
1545929244
1339528996
1488248828
1608255675
1731628481
1565204671
1744770886
1939415488
1756296101
1932000298
2179323989
2000677515
3476399367
2571387305
2250725185
2108052193
2317144231
2904733667
2298384563
4230384861
3695711589
4503387603
6248158489
2474745743
3003053394
2827777824
2947784671
3935620090
5936297605
3296833152
4040052491
3501066987
3688296399
5155458852
4406436756
5007101813
4549109748
4358777378
5078503009
4425196424
4582797936
4615528794
6163042142
6234004653
5302523567
5422530414
5477799137
5975812730
5771578895
5830831218
6124610976
11398343144
17522954120
6797900139
6985129551
8990819966
9971640162
8113492823
8765214134
8783973802
8907887126
8941575314
10591341524
9040725218
9007994360
10558610666
9918052361
10725053981
14889825110
14838825578
10900329551
16956769713
11602410113
13783029690
11955442194
20739415996
16769540301
15750343685
14911392962
15769103353
16878706957
16897466625
17805939352
17549187936
23897819470
18048719578
17949569674
18926046721
18958777579
19566605026
20476663027
25811722513
38736645048
22502739664
22855771745
27797796176
23557852307
25385439803
26866835156
27705785879
55615352005
42422376771
30661736647
30680496315
32647810310
33776173582
34847036299
35755509026
43360910449
45825612735
45747365850
63775182409
38492651747
38525382605
42069344690
64925116435
45358511409
46060591971
46413624052
80205547708
48943292110
64456669897
52252274959
54572621035
66198437626
61342232962
63309546957
63328306625
65527532614
81853562196
68623209881
104020184361
129148839818
80561996437
77018034352
84272748455
80594727295
83851163156
110870293949
131951516506
91419103380
91772135461
95003884081
131590655387
143871543394
103515913145
119029290932
106824895994
145991724415
124651779919
126869765576
126637853582
172139123026
134150742495
145641244233
149185206318
157580030789
157612761647
164445890451
168123911611
164867475750
172013830675
291083744033
256010102312
183191238841
186422987461
186776019542
295176930733
210340809139
222545204077
225854186926
231476675913
233462749576
251289633501
291505329332
275823059900
291730773284
325736673258
303221275022
344356050331
523207449197
329626592322
322058652098
329313366201
332991387361
336881306425
355205069516
774497082698
1000351269624
617242002590
373199007003
397116828681
448399391003
432886013216
454021879990
457330862839
509285809476
484752383077
613789425382
567328389232
567553833184
594952048306
625279927120
632534641223
1096555734796
1373550276627
994038192553
776080532088
662304753562
669872693786
1454373149614
770315835684
1110704144565
806085020219
821598398006
827220886993
830002841897
1199863030455
942083245916
911352742829
966616672315
1052080772309
1454133039229
1276094178944
1134882222416
1389152231190
1804754916202
1619318119673
1763681643922
2203553118524
1440188529470
1492307595459
1332177447348
1483903151568
2300504974019
2141946276371
2946440634688
2216373118183
1627683418225
2449320961570
2251943802764
1741355584726
1853435988745
1877969415144
2046234965245
2018697444624
3193907147392
2410976401360
2772365976818
2524034453606
2721329678538
2816080598916
4834778043540
3119991013684
2824485042807
2924091681038
2959860865573
3185613436093
3625849427939
3594791573471
4235070562807
4574124052913
4495555926815
3369039002951
3731405403889
3993299387490
3760053029350
4264412390105
6906532328175
4064932409869
4429673845984
4935010854966
6149883881545
5245364132144
5340115052522
5645421359576
6010098478900
5748576723845
5784345908380
5883952546611
7681169362908
6145474301666
11402088254990
6963830576422
7354844602821
7362338390441
8329344799974
7100444406840
7129092032301
7491458433239
7753352416840
7824985439219
10890785491720
13429746086753
8494606255853
10683587578811
10180374987110
10585479184666
11393998083421
11088691776367
11429767267956
18558859300257
11532922632225
13826643664574
12984396953451
13245918708506
15595050662693
14064274983262
14491430422742
21575263508480
14853796823680
35401907173054
53960766473311
33005030776436
15244810850079
15578337856059
18674981242963
19080085440519
54580294284916
19178193834664
20765854171776
21674170961033
26333502626446
22926920715646
22518459044323
27008105124015
28318074087316
27737349131248
32501624907537
26230315661957
37009889467065
28555705406004
28918071806942
70158632140975
45413588066965
30098607673759
30823148706138
62600232581296
41475126512036
33919792093042
34253319099022
61261424223037
38258279275183
57180239814668
39944048006440
44192630005356
44601091676679
45445379759969
52617066718082
48748774706280
64351926772781
53967664793205
56655420938190
73519163483621
109765514839746
57473777212946
85667756517392
59016679480701
60921756379897
97274958755884
126952159354077
64742940799180
72511598374205
92561114724522
68173111192064" |> split "\n" |> Array.map (trim >> int64) |> List.ofArray
