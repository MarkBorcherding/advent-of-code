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
  def parse(input:String) =
    input
      .split("\n")
      .map(_.trim)
      .collect {
        case program(name, weight, null) => Program(name, weight.toInt)
        case program(name, weight, others) => Program(name, weight.toInt, others.split(",").map(_.trim)) }
      .map {  p => p.name -> p }
      .toMap

  def root(programs: Seq[Program]): Program = {
    val children = programs.flatMap(_.children)
    programs.filterNot { p => children.contains(p.name) }.head
  }

  def weight(programs: Map[String, Program], program: Program):Int = {
    if(program.children.isEmpty) return program.weight

    val childrenWeights =
      program
        .children
        .map { c => c -> weight(programs, programs.get(c).get) }

    if(childrenWeights.map{ c => c._2 }.distinct.length != 1) {
      childrenWeights.map { c => println(List(c._2, programs.get(c._1).get.weight)) }
    }

    return program.weight + childrenWeights.map{ c => c._2 }.sum
  }
}
