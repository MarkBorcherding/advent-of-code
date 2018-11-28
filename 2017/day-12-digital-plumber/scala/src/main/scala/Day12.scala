import scala.collection.immutable.SortedSet

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

  val node = raw"""(\d+) <-> (.*)""".r

  type NodeList = SortedSet[Int]
  type Graph = Map[Int, NodeList]

  case class Node(index:Int, connected: NodeList)
  object Node {
    def apply(index: String, connected: String):Node =
      Node(
        index.toInt,
        connected
          .split(",")
          .map(_.trim)
          .map(_.toInt)
          .foldLeft(SortedSet[Int]()){ (acc,i) =>  acc + i })
  }

  val parse =
    (_:String)
      .split("\n")
      .map(_.trim)
      .collect { case node(index, connected) => Node(index, connected) }
      .foldLeft(Map[Int, NodeList]()) { (g, n) => g + (n.index -> n.connected) }


  def connected(g: Graph, visited: NodeList = SortedSet[Int](), visiting: Int = 0):NodeList = {
    g.get(visiting).get match {
      case children if visited.contains(visiting) => visited
      case children => children.foldLeft(visited) {
        (v, i) => v ++ connected(g, v + visiting, i)
      }
    }
  }

  def grouped(g: Graph):List[NodeList] = {
    println(g.size)

    if(g.isEmpty) return List()

    val headGroup = connected(g, SortedSet[Int](), g.head._1)

    val rest =
      headGroup
        .foldLeft(g) { (acc, n) => acc - n }

    headGroup +: grouped(rest)
  }

}
