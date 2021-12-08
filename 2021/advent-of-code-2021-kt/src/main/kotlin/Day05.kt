class Day05 {

    data class Point(val x: Int, val y: Int) {}

    data class Line(val from: Point, val to: Point) {
        val isVerticalOrHorizontal = (from.x == to.x) || (from.y == to.y)

        fun points(): Collection<Point> {
            val (xMin, xMax) = listOf(from.x, to.x).sorted()
            val (yMin, yMax) = listOf(from.y, to.y).sorted()

            return if(xMin == xMax || yMin == yMax) {
                (xMin..xMax).flatMap { x ->
                    (yMin..yMax).map { y ->
                        Point(x, y)
                    }
                }
            } else {
                val xR = if(from.x < to.x) from.x.rangeTo(to.x) else to.x.rangeTo(from.x).reversed()
                val yR = if(from.y < to.y) from.y.rangeTo(to.y) else to.y.rangeTo(from.y).reversed()
                xR.zip(yR).map {
                        (x,y) -> Point(x,y)
                }
            }

        }
    }

    data class Graph(val default: Int = 0, val cells: Map<Point, Int> = emptyMap()) {

        private fun plot(point: Point): Graph {
            val current = this.cells[point] ?: 0
            val next = this.cells + (point to (current + 1))
            return this.copy(cells = next)
        }

        fun plotLine(line: Line): Graph {
            return line.points().fold(this) { graph, point ->
                graph.plot(point)
            }
        }

        private fun bounds(): Pair<Point, Point> {
            val x = cells.keys.map { it.x }.sorted()
            val y = cells.keys.map { it.y }.sorted()
            return Point(x.minOrNull() ?: 0, y.minOrNull() ?: 0) to Point(
                x.maxOrNull() ?: 0,
                y.maxOrNull() ?: 0
            )
        }

        fun draw() {
            val (upperLeft, lowerRight) = bounds()
            (upperLeft.y..lowerRight.y).map { y ->
                (upperLeft.x..lowerRight.x).map { x ->
                    val c = cells[Point(x, y)]?.toString() ?: "."
                    print(c.padStart(2) + " ")
                }
                println()
            }
        }

    }
    companion object {

        private fun parse(s: String): Collection<Line> {
            return s
                .split("\n")
                .map { line ->
                    val (from, to) = line.split(" -> ")
                    val (fromX, fromY) = from.split(",").map { it.toInt() }
                    val (toX, toY) = to.split(",").map { it.toInt() }
                    Line(Point(fromX, fromY), Point(toX, toY))
                }
        }

        fun part1(rawInput: String): Int {
            val input: Collection<Line> = parse(rawInput)
            val points =
                input
                    .filter { it.isVerticalOrHorizontal }
                    .flatMap { it.points() }

            val plotted = points
                    .fold(Graph().cells) { cells, point ->
                        val current = cells[point] ?: 0
                        cells + (point to (current + 1))
                }
            val answer = plotted.values.filter { it > 1 }.size
            return answer
        }

        fun part2(rawInput: String): Int {
            val input: Collection<Line> = parse(rawInput)
            val points =
                input
                    .flatMap { it.points() }

            val h = HashMap<Point, Int>()
            val plotted = points
                .fold(h) { cells, point ->
                    val current = cells[point] ?: 0
                    h[point] = current + 1
                    h
                }
            val answer = plotted.values.filter { it > 1 }.size
            return answer
        }

    }

}


