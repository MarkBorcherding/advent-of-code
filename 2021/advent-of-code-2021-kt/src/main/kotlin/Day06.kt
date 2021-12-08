import java.math.BigInteger

class Day06(input: String)  {

    val timers = input.split(",").map { it.toInt() }

    fun breed(fish: Map<Int,Long>, daysRemaining: Int): Map<Int,Long> {

        if(daysRemaining == 0)
            return fish

        val breeders = fish[0]  ?: 0
        val nextGen = mapOf(
            0 to (fish[1] ?: 0),
            1 to (fish[2] ?: 0),
            2 to (fish[3] ?: 0),
            3 to (fish[4] ?: 0),
            4 to (fish[5] ?: 0),
            5 to (fish[6] ?: 0),
            6 to (fish[7] ?: 0) + breeders,
            7 to (fish[8] ?: 0),
            8 to breeders
        )
        return breed(nextGen, daysRemaining - 1)
    }

    private fun display(fish: Map<BigInteger, Long>, daysRemaining: Int) {
        print(" Days left: $daysRemaining ")
        println(" ${ fish.keys.sorted().map { fish[it] }.joinToString(separator = ", ") }")
    }

    fun part1(daysRemaining: Int): Long {
        val fish = timers.groupBy { it }.map { (days, count) ->  days to count.size.toLong() }.toMap()
        val fishAfter = breed(fish, daysRemaining)
        return fishAfter.values.sum()
    }

    fun part2(): Int {
        TODO("Not yet implemented")
    }
}