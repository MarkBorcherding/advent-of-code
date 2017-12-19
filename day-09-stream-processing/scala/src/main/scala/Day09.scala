package adventofcode

import scala.annotation.tailrec

object Day09 {

  // <>, empty garbage.
  //   <random characters>, garbage containing random characters.
  //   <<<<>, because the extra < are ignored.
  //   <{!>}>, because the first > is canceled.
  //   <!!>, because the second ! is canceled, allowing the > to terminate the garbage.
  //   <!!!>>, because the second ! and the first > are canceled.
  //   <{o"i!a,<{i<a>, which ends at the first >.


  val stripNegated = "!.".r.replaceAllIn(_:CharSequence, "")
  val stripGarbage = "<[^>]*>".r.replaceAllIn(_:CharSequence, "")
  val decomma = ",".r.replaceAllIn(_:CharSequence, "")

  def lines(input:String) = input.split("\n").map(_.trim)

  def tryIt =
    lines(sampleInput)
      .map(stripNegated)
      .map(stripGarbage)
      .map(decomma)
      .map(score(0,1))

  val emptryBraces = "{}".r
  val foundBraces = emptryBraces.findAllIn(_:CharSequence).length
  val stripBraces = emptryBraces.replaceAllIn(_:CharSequence, "")
  @tailrec
  def score(current: Int = 0, containingDepth: Int = 1)(s: String):Int = {
    if(s.length == 0) return current
    score(current + foundBraces(s) * containingDepth, containingDepth + 1)(stripBraces(s))
  }

  val sampleInput =
    """{}
      |{{{}}}
      |{{},{}}
      |{{{},{},{{}}}}
      |{<a>,<a>,<a>,<a>}
      |{{<ab>},{<ab>},{<ab>},{<ab>}}
      |{{<!!>},{<!!>},{<!!>},{<!!>}}
      |{{<a!>},{<a!>},{<a!>},{<ab>}}""".stripMargin
}
