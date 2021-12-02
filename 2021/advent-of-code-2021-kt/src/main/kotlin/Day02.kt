
class Day02 {
    object Part1{
       fun calc(rawCommand:List<String>): Int {

           val commands = rawCommand.map { Command.fromString(it) }

           val finalPosition =
               commands.fold(Position(0, 0))
               { acc, cur ->
                   when (cur.direction) {
                       Direction.down -> acc.down(cur.amount)
                       Direction.up -> acc.up(cur.amount)
                       Direction.forward -> acc.forward(cur.amount)
                   }
               }
           return finalPosition.horizontal * finalPosition.vertical
       }

    }
}

data class Position(val horizontal: Int, val vertical:Int, val aim: Int = 0) {
    fun up(by:Int) = this.copy( aim = aim -  by )
    fun down(by:Int) = this.copy( aim = aim + by )
    fun forward(by:Int) = this.copy( horizontal = horizontal + by, vertical = vertical + (aim * by))
}

enum class Direction {
    forward,
    down,
    up
}
data class Command(val direction: Direction, val amount: Int){
    companion object {
        fun fromString(s:String):Command {
            val (dir, amt) = s.split(" ")
            val amount = amt.toInt()
            val direction = when (dir) {
                "forward" -> Direction.forward
                "down" -> Direction.down
                else -> Direction.up
            }

            return Command(direction,amount)
        }
    }
}