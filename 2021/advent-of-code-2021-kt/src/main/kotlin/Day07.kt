import kotlin.math.abs
import kotlin.math.absoluteValue

class Day07(input: String) {

    val crabs = input.split(",").map { it.toInt() }.sorted()

    fun calc(list: List<Int>, center: Int) =
        list.sumOf {
            val n = abs(it - center)
            (n*(n+1))/2
        }
        // list.sumOf { abs(it - center) }


    fun optimalFuel(list: List<Int>, range: Pair<Int,Int>):Int {
        val mid = range.second.minus(range.first).absoluteValue.div(2).plus(range.first)
        val baseline = calc(list, mid)
        val left = calc(list, mid - 1)
        val right = calc(list, mid + 1)

        return when {
            baseline < left && baseline < right -> return baseline
            left < right -> optimalFuel(list, range.first to mid)
            left > right -> optimalFuel(list, mid to range.second)
            else -> TODO("Should never happen")
        }
    }

    fun part1(): Int {
        val min = crabs.first()
        val max = crabs.last()
        return optimalFuel(crabs, min to max)
    }

    fun part2(): Int {
        val min = crabs.first()
        val max = crabs.last()
        return optimalFuel(crabs, min to max)
    }
}

