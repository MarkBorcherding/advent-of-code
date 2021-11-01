import arrow.core.None
import arrow.core.Option
import arrow.core.Predicate
import arrow.core.Some

class Day01 {
    private val targetValue = 2020

    private fun <T> List<T>.findOpt(predicate: Predicate<T>):Option<T> {
        val found = this.find(predicate)
        return if (found == null) None else Some(found)
    }

    fun part1(input: List<Int>): Option<Int> {
        return input.fold<Int, Option<Int>>(None) { acc, first ->
            when (acc) {
                None -> {
                    val remaining = targetValue - first
                    input
                        .findOpt { second -> remaining == second }
                        .map { second -> second * first }
                }
                else -> acc
            }
        }
    }

    fun part2(): Int {
        val targetValue = 2020
        return 0
    }


}