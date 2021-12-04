class Day03 {
    companion object {

        fun part1(input: List<String>): Int {
            val size = input.first().length
            val initial = listOf(0,0,0,0,0,0,0,0,0,0,0,0).take(size)

            val inputDigits = input.map { splitIntoDigits(it) }

            val counts =
                inputDigits
                    .fold(initial) { acc, cur ->
                        val next =
                            acc
                                .zip(cur)
                                .map {
                                    when (it.second) {
                                        0 -> it.first - 1
                                        1 -> it.first + 1
                                        else -> 0
                                    }
                                }
                        next
                    }

            val bits =
                counts .map { if(it > 0) 1 else 0 }

            val a = bits.binaryToDecimal()
            val b = bits.invertBits().binaryToDecimal()

            return a*b
        }

        fun part2(input: List<String>): Int {
            val inputDigits = input.map { splitIntoDigits(it) }

            val matchA = filter(0, inputDigits, Take.Min, 0 ).binaryToDecimal()
            val matchB = filter(0, inputDigits, Take.Max, 1 ).binaryToDecimal()


            return matchA * matchB
        }


        private enum class Take {
            Min,
            Max
        }

        private fun filter(index: Int, input: List<List<Int>>, take: Take, default: Int ): List<Int> {
            if (input.size == 1) return input.first()

            val grouped = input.groupBy { it[index] }

            val tied = grouped[0]!!.size == grouped[1]!!.size

            val remaining:List<List<Int>> =  when(Pair(tied, take)) {
                Pair(true, Take.Max) -> input.filter { it[index] == 1 }
                Pair(true, Take.Min) -> input.filter { it[index] == 0 }
                Pair(false,Take.Max) -> {
                    val size = grouped.maxOf { (_,v) -> v.size }
                    grouped.values.first { it.size == size }
                }
                Pair(false,Take.Min) -> {
                    val size = grouped.minOf { (_,v) -> v.size }
                    grouped.values.first { it.size == size }
                }
                else -> throw NotImplementedError("Really kotlin? This is already exhaustive")
            }
            return filter(index +1, remaining, take, default)
        }

        private fun splitIntoDigits(it: String): List<Int> {
            return it.map {
                when (it) {
                    '0' -> 0
                    '1' -> 1
                    else -> 0
                }
            }
        }
    }
}

private fun List<Int>.invertBits(): List<Int> {
    return this.map { if (it == 1) 0 else 1 }
}

private fun <E> List<E>.binaryToDecimal(): Int {
    return this.reversed().foldIndexed(0) { idx, acc, cur ->
        acc + if(cur == 1) (1 shl idx) else 0
    }
}
