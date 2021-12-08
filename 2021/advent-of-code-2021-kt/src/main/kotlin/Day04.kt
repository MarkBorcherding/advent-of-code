object Day04 {

    fun part1(input: String):Int {
        val state = parse(input)
        val winner = state.winningBoard()
        return winner.score
    }

    fun part2(input:String):Int {
        val state = parse(input)
        val winner = state.winningBoard()
        return winner.score
    }

    private fun parse(input: String):GameState {
        val chunks = input.split("\n\n")
        val numbers = chunks.first()
        val boards = chunks.drop(1)
        return GameState(
            numbers.split(",").map { it.toInt()},
            boards.map { Board.parse(it) }
        )
    }


    data class Win(val board: Board, val picks: List<Int>) {
        private val winningNumber = picks.last()
        private val unpickedNumbers = board.input.toSet().minus(picks.toSet())
        val score = winningNumber * unpickedNumbers.sum()
    }

    data class GameState(val remainingNumbers: List<Int>, val boards: List<Board> = emptyList(), val pickedNumbers: List<Int> = emptyList(), val win: Win? = null) {

        fun winningBoard(): Win {
            if(remainingNumbers.isEmpty() || boards.isEmpty()) return this.win!!

            val winners = boards.filter { it.isWinner(pickedNumbers) }
            val newWinner = boards.firstOrNull() { it.isWinner(pickedNumbers) }

            val nextBoard =
                if (newWinner != null) {
                    val remainingBoards = this.boards.minus(winners.toSet())
                    println("remaining: ${remainingBoards.size}   winners: ${winners.size}")
                    this.copy(boards = remainingBoards,  win = Win(newWinner, pickedNumbers.toList().toIntArray().toList()))
                } else {
                    this
                }

            return nextBoard.drawNumber().winningBoard()
        }

        private fun drawNumber(): GameState {
            val head = remainingNumbers.first()
            val tail = remainingNumbers.drop(1)
            val inPlayNumbers = pickedNumbers + head

            return this.copy(remainingNumbers = tail, pickedNumbers = inPlayNumbers)
        }

    }

    data class Board(val input:IntArray, val size: Int = 5) {

        private val range = (0 until size)

        private val rows =
            range.map { y ->
                range. map { x -> cellAt(x,y) }.toSet()
        }

        private val columns =
            range.map { x ->
                range. map { y -> cellAt(x,y) }.toSet()
            }

        private fun cellAt(x: Int, y:Int)  = input[x + (y * size)]

        private val winningNumbers = rows + columns

        fun isWinner(pickedNumbers: List<Int>): Boolean {
            return winningNumbers.any { pickedNumbers.containsAll(it) }
        }

        fun display(pickedNumbers: List<Int>):String {
            val isWinner = this.isWinner(pickedNumbers)
            val picked = pickedNumbers.toSet()
            return input.toList().chunked(size).joinToString(separator = "\n") { row ->
               row.joinToString(separator = " ") { cell ->
                  val c = cell.toString().padStart(2 , ' ')
                   val p = picked.contains(cell)
                   val color = when {
                       isWinner && p ->  ConsoleColors.GREEN_BRIGHT
                       p -> ConsoleColors.BLUE
                       else -> ConsoleColors.RESET
                   }
                   color + c
               }
            }
        }


        companion object {
            fun parse(input: String, size: Int = 5): Board {
                val lines =
                    input
                        .trim()
                        .replace("\n", " ")
                        .split(Regex(" +"))
                        .map { it.toInt()}
                        .toIntArray()
                return Board(lines, size)
            }
        }

        override fun equals(other: Any?): Boolean {
            if (this === other) return true
            if (javaClass != other?.javaClass) return false

            other as Board

            if (!input.contentEquals(other.input)) return false
            if (size != other.size) return false

            return true
        }

        override fun hashCode(): Int {
            var result = input.contentHashCode()
            result = 31 * result + size
            return result
        }
    }
}