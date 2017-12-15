package adventofcode


case class Program(name: String, weight: Int, children: Seq[String] = Nil)

object Project

object Day07 {

  val i = """pbga (66)
            |xhth (57)
            |ebii (61)
            |havc (66)
            |ktlj (57)
            |fwft (72) -> ktlj, cntj, xhth
            |qoyq (66)
            |padx (45) -> pbga, havc, qoyq
            |tknk (41) -> ugml, padx, fwft
            |jptl (61)
            |ugml (68) -> gyxo, ebii, jptl
            |gyxo (61)
            |cntj (57)""".stripMargin

  val program = raw"(\w+) \((\d+)\)(?: -> (.*))?".r
  def parse(input:String): Seq[Program] =
    input
      .split("\n")
      .map(_.trim)
      .collect {
        case program(name, weight, null) => Program(name, weight.toInt)
        case program(name, weight, others) => Program(name, weight.toInt, others.split(",").map(_.trim))
      }

  def root(programs: Seq[Program]): Program = {
    val children = programs.flatMap(_.children)
    programs.filterNot { p => children.contains(p.name) }.head
  }

}
