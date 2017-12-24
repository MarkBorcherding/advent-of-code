object Day11 {

  val steps = (_:String).split(",").toSeq
  val calc = (_:(Int, Int, Int, Int)) match {
    case (x,y,z,m) => m.max((x.abs + y.abs + z.abs) / 2)
  }

  def max(x:Int, y:Int, z:Int, m:Int) =
    (x,y,z, m.max(calc(x,y,z,m)))

  val move =
    (_:Seq[String]).foldLeft(0, 0, 0, 0) {
      case ((x,y,z,m), "n")  => max(x,   y+1, z-1,m)
      case ((x,y,z,m), "ne") => max(x+1, y,   z-1,m)
      case ((x,y,z,m), "se") => max(x+1, y-1, z,  m)
      case ((x,y,z,m), "s")  => max(x,   y-1, z+1,m)
      case ((x,y,z,m), "sw") => max(x-1, y,   z+1,m)
      case ((x,y,z,m), "nw") => max(x-1, y+1, z,  m)
    }

  val go =
    steps andThen
    move andThen
    calc
}

