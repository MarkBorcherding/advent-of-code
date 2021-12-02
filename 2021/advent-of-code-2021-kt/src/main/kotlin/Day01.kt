class Day01 {
    object Part1{
        fun calc(input: List<Int>): Int {

            val head = input.first()
            val tail = input.drop(1)

            return calc(head, tail)
        }

        private fun calc(prev: Int, input:List<Int>): Int {
            if(input.isEmpty()) return 0

            val head = input.first()
            val tail = input.drop(1)

            val inc = if(prev < head) 1 else 0

            return inc + calc(head, tail)
        }
    }

    object Part2 {
        fun calc(input: List<Int>): Int {
            val head = input.take(3).sum()
            val tail = input.drop(1)

            return calc(head, tail)
        }

        private fun calc(prev: Int, input:List<Int>): Int {
            val group = input.take(3)

            if(group.size < 3) return 0

            val head = group.sum()
            val tail = input.drop(1)

            val inc = if(prev < head) 1 else 0

            return inc + calc(head, tail)
        }
    }
}