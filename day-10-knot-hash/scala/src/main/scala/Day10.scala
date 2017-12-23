import scala.annotation.tailrec

object Day10 {

  @tailrec
  def twist(string: Seq[Int], lengths: Seq[Int], startAt: Int = 0, skipSize: Int = 0):Seq[Int] = {

    if(lengths.isEmpty) return string

    val twistLength = lengths.head
    val rest = lengths.tail

    val straightLength = string.length - twistLength

    val loop =
      Stream
        .continually(string.toStream)
        .flatten

    val twistedSegment =
      loop
        .drop(startAt)
        .take(twistLength)
        .toList

    val straightSegment =
      loop
        .drop(startAt + twistLength)
        .take(straightLength)
        .toList

    val twisted = twistedSegment.reverse ++ straightSegment

    val nextString =
      Stream
        .continually(twisted)
        .flatten
        .drop(string.length - startAt)
        .take(string.length)
        .toSeq

    val nextStart = (startAt + twistLength + skipSize) % string.length

    twist(nextString, rest, nextStart, skipSize + 1)
  }


  def toAscii(s:String): Seq[Int] = s.map(_.toInt)

  val repeat = List.fill(64)(_:Seq[Int]).flatten

  val hexify = "%02x".format(_:Int)

  val xor = (_:Seq[Int]).reduce(_ ^ _)

  val suffix = List(17, 31, 73, 47, 23)

  def twist2(s: String) = twist(
      Range(0,256).toSeq,
      repeat(toAscii(s) ++ suffix))
      .toList
      .grouped(16)
      .map(xor andThen hexify)
      .mkString

  def go = twist(List(0, 1, 2, 3, 4), List(3, 4, 1, 5 )).toList

  def test1 = twist(
    Range(0,256).toSeq,
    List(130,126,1,11,140,2,255,207,18,254,246,164,29,104,0,224))
    .toList
    .take(2)
    .reduce(_ * _)

  def go2 = twist2("")


}
