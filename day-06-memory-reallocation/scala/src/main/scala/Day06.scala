package adventofcode

import scala.annotation.tailrec

object Day06 {
  type Allocation = List[Int]

  def reallocate(allocation: Allocation): (Int, Int) =
    reallocate(allocation :: Nil, 0)

  @tailrec
  def reallocate(allocations:List[Allocation], iteration: Int = 0):(Int, Int) = {

    val allocation = allocations.head
    val rest = allocations.tail

    val foundAt = rest.indexOf(allocation)
    if (foundAt > 0) return (iteration -> foundAt)

    val max = allocation.max
    val maxIndex = allocation.indexOf(max)

    val next = Stream
      .continually(Range(0, allocation.length).toStream)
      .flatten
      .drop(maxIndex + 1)
      .take(max)
      .toList
      .foldRight(emptyIndex(allocation, maxIndex))(incrementIndex)

    return reallocate(next +: allocations, iteration + 1)
  }

  def incrementIndex(i: Int, a: Allocation) = a.patch(i, a(i) + 1 :: Nil, 1)

  def emptyIndex(a: Allocation, i:Int) = a.patch(i, 0 :: Nil, 1)
}

