object Day11 {

  val steps = (_:String).split(",").toSeq
  val calc = (_:(Int, Int, Int)) match {
    case (x,y,z) => (x.abs + y.abs + z.abs) / 2
  }

  val distance =
    (_:Seq[String]).foldLeft(0, 0, 0) {
      case ((x,y,z), "n")  => (x,   y+1, z-1)
      case ((x,y,z), "ne") => (x+1, y,   z-1)
      case ((x,y,z), "se") => (x+1, y-1, z)
      case ((x,y,z), "s")  => (x,   y-1, z+1)
      case ((x,y,z), "sw") => (x-1, y,   z+1)
      case ((x,y,z), "nw") => (x-1, y+1, z)
    }

  val go =
    steps andThen
    distance andThen
    calc
}

