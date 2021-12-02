package day01

import Day01
import kotlin.test.Test
import kotlin.test.assertEquals

internal class Day01Test
{

    @Test
    fun `part 1 example input`() {
        val actual = Day01.Part1.calc(Input.example)
        assertEquals(7, actual)
    }


    @Test
    fun `part 1 my input`() {
        val actual = Day01.Part1.calc(Input.mine)
        assertEquals(1548, actual)
    }

    @Test
    fun `part 2 example input`() {
        val actual = Day01.Part2.calc(Input.example)
        assertEquals(5, actual)
    }

    @Test
    fun `part 2 my input`() {
        val actual = Day01.Part2.calc(Input.mine)
        assertEquals(1589, actual)
    }

}