import kotlin.test.Test
import kotlin.test.assertEquals

class Day06Test {

    val day = { input: String -> Day06(input)}

    @Test
    fun `part 1 with example data`() {
        val actual = day(example).part1(18)
        assertEquals(26, actual)

        val actual80 = day(example).part1(80)
        assertEquals(5934, actual80)
    }

    @Test
    fun `part 1 with my data`() {
        val actual = day(mine).part1(80)
        assertEquals(5, actual)
    }

    @Test
    fun `part 2 with example data`() {
        val actual = day(example).part2()
        assertEquals(12, actual)
    }

    @Test
    fun `part 2 with my data`() {
        val actual = day(mine).part1(256)
        assertEquals(21140, actual)
    }

    val example = "3,4,3,1,2"
    val mine = "2,5,2,3,5,3,5,5,4,2,1,5,5,5,5,1,2,5,1,1,1,1,1,5,5,1,5,4,3,3,1,2,4,2,4,5,4,5,5,5,4,4,1,3,5,1,2,2,4,2,1,1,2,1,1,4,2,1,2,1,2,1,3,3,3,5,1,1,1,3,4,4,1,3,1,5,5,1,5,3,1,5,2,2,2,2,1,1,1,1,3,3,3,1,4,3,5,3,5,5,1,4,4,2,5,1,5,5,4,5,5,1,5,4,4,1,3,4,1,2,3,2,5,1,3,1,5,5,2,2,2,1,3,3,1,1,1,4,2,5,1,2,4,4,2,5,1,1,3,5,4,2,1,2,5,4,1,5,5,2,4,3,5,2,4,1,4,3,5,5,3,1,5,1,3,5,1,1,1,4,2,4,4,1,1,1,1,1,3,4,5,2,3,4,5,1,4,1,2,3,4,2,1,4,4,2,1,5,3,4,1,1,2,2,1,5,5,2,5,1,4,4,2,1,3,1,5,5,1,4,2,2,1,1,1,5,1,3,4,1,3,3,5,3,5,5,3,1,4,4,1,1,1,3,3,2,3,1,1,1,5,4,2,5,3,5,4,4,5,2,3,2,5,2,1,1,1,2,1,5,3,5,1,4,1,2,1,5,3,5,2,1,3,1,2,4,5,3,4,3"

}