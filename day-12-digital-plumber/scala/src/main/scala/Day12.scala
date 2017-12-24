object Day12 {

  // answer 6...all but 1
  val sampleInput =
    """0 <-> 2
      |1 <-> 1
      |2 <-> 0, 3, 4
      |3 <-> 2, 4
      |4 <-> 2, 3, 6
      |5 <-> 6
      |6 <-> 4, 5""".stripMargin

  val node = raw"""(\d+) <-> (\d+(, \d+)*)""".r

  case class Node(index:Int, connected: Seq[Int])

  val splitLints = (_:String).split("\n").map(_.trim)



}

