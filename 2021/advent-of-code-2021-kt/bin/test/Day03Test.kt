import kotlin.test.Test
import kotlin.test.assertEquals

internal class Day03Test
{

    @Test
    fun `part 1 example input`() {
        val actual = Day03.part1(example)
        assertEquals(198, actual)
    }


    @Test
    fun `part 1 my input`() {
        val actual = Day03.part1(mine)
        assertEquals(2967914, actual)
    }

    @Test
    fun `part 2 example input`() {
        val actual = Day03.part2(example)
        assertEquals(230, actual)
    }

    @Test
    fun `part 2 my input`() {
        val actual = Day03.part2(mine)
        assertEquals(7041258, actual)
    }

    private val example =
        """00100
            11110
            10110
            10111
            10101
            01111
            00111
            11100
            10000
            11001
            00010
            01010""".split("\n").map { it.trimIndent() }

    private val mine =
        """110011110101
110011100010
010100011010
011001100000
010011011101
011110111000
111111000100
000100010001
101101010011
100101101100
001111011010
011111111101
010111000000
000011101000
100101010010
010011000010
000011000000
111100110010
100100101110
110000110100
011110010000
010101000000
001000110001
010111000100
110111010100
011001110110
110001001101
001101010010
110111110100
100111110111
001001110010
001100011111
001111110010
100111000111
101111100001
011100001100
000000000111
101111110001
110111001101
101111011010
100101001111
011101111111
101101010101
011011111000
011100101001
001101010100
000011101010
010100111000
000111011100
110000100101
110110011000
111001000110
110001000100
110111001100
010111011111
110110101001
101000001011
100001001010
001011000011
000100101111
000001111010
001010110110
000010110001
011011011001
110010001011
101111001100
101000101100
011010101100
000111000001
010001000010
011111101011
101101011000
100010100100
100010011001
100010010100
011010110000
111001111011
000000101000
011010110001
111110001110
010010001100
101000100100
000110111010
000100011000
011100110110
010000000100
010001000001
010011001010
111100101010
010110110110
010100111111
000010001010
111110001101
110000100010
110111010110
101011100001
111111010001
101111111000
100110111101
110000100110
010101100011
101111010101
101010101011
101010100011
000100111001
001001101001
110001000001
001011000110
111110101011
101100101111
111001111001
101100010101
011011100100
100110010110
101110011111
011001010011
111111111111
110111000000
011010101011
011111100001
100100001001
011111100010
111111001001
100011110111
110000101100
111001101001
011110111101
011010101111
101011000101
000010110011
100100011011
010000001001
001100110111
111011001111
101101011001
110111111000
100100100110
110011011010
011111010010
011000110001
001001110011
111110100111
100001010011
110011011101
100000011100
001001010010
111010110000
001111110000
110000000011
110111100010
100101010001
010110000110
100010001010
001110110101
011100000001
010100100011
110001011011
010000110100
001011010110
011000100010
001111100000
100101001100
110000000000
011001101110
111110010100
111001010111
011000100000
110000010010
000110001001
101000101101
010010101110
110001010010
110010001101
110111001110
100100100100
011010000100
101001000110
000000000000
001000000100
101011100110
100010010110
101110000101
011010110100
000000110010
100110101000
100011100011
110100010110
011111001011
011010111011
011001110100
110111001001
011110101000
100011101010
101001000100
001000101111
010111101000
001110101000
110100011000
000100111110
000111110000
011111110100
100000111010
001111011100
110100101101
000110000110
001010100011
011100100111
101101110111
010110000001
000001100111
110000101010
100001010101
001000111110
101011110101
011111100100
100000100101
000101011111
011010101010
011010110110
000001110000
110100101011
110010101110
111110110011
110110001110
010011000100
100101111101
101111100110
101111101110
001000001000
011111011010
111010101010
111111000101
010110001000
011110000100
110101001110
101110000011
110000100100
010010001001
100110001110
101000001000
010111011110
000011111110
010001101111
100010011110
111000100111
010101110010
001000000111
010010011010
010100011100
101001011100
000010110101
100010110110
110111011000
011101110001
110011000110
000010011111
000001011011
100111011011
111110111100
110100000010
010110001110
011110000110
100111011100
111111110111
000001000100
111101000101
101110100101
011010001101
001001100101
001011110101
100110011011
010111100101
010101011111
000000001001
100100110001
101111111110
101010110001
110010011010
010001111010
001001110101
000111110111
010101001000
011110101101
100001101100
111010000010
001110110000
101110111111
000110110000
000111000100
101010101101
111001111000
001011111101
101111010110
111110100011
111011111010
010101001111
101100110110
001100000001
110101110010
100010001011
110000110111
000101010000
010011111001
010001100000
111110011101
101101001001
001111101111
001101000101
001000010011
100001101101
111100110111
110101111011
100000001001
101011110001
001001010110
011000110010
011010100000
011011100001
000100110111
111101110010
000011001100
100000000000
111110110111
001100000101
000001100000
000011001110
111010011011
110111111010
100011101110
000110111001
111010110101
010001011001
011011111111
111101001011
001111110001
110100001110
101000100001
101011001111
100101101010
001110100000
011010110011
001011001101
111111100011
111110101100
010001001011
001110100011
010000111010
010110101111
000001101001
001011110000
011010011101
111000111010
110100011010
111100000010
110101100100
110100010101
001001101000
011101011101
000101101011
011011100110
001110010010
001011111100
110010001110
001110101010
111011111000
101001100111
001110101011
010100010101
000100101000
001110101001
010000000111
010100100111
000011111001
001111000111
010100101010
110110011101
011101001001
010110101000
101110100000
010000000000
101111111101
000110000000
100101000001
010100011001
110011001000
010010100011
101010001011
100001111101
010001111100
011110001100
101000111010
000110110010
101111100000
001110011000
010001110101
000110011011
000011001111
101000111110
010001100111
011010001000
011101010011
110101101001
010100000111
111111011110
010101101101
011111111011
000011111100
101110100010
101110110101
100010110101
010000100110
101111111010
001001001001
111111011101
000000011011
011101001111
000110000101
011101111100
100111001011
110011101000
010110101110
110100100010
010100110010
100001000110
111000001101
000111101101
011110011101
110100100111
101100101010
010001100101
010101111001
001111101011
110001011100
000011011001
000000110101
101101000110
001101110101
101110110000
100000110010
000111010100
001111110110
010000111111
011011101111
010011001100
111100011010
011010001011
100111101000
010100100100
010100100101
010100101001
000010010011
101101100000
101101101110
010111011101
000010110000
100111111001
001010100111
000110000001
100000111100
001101000001
000010110110
011000010101
100100110110
100100100101
101010110101
010010100001
111110001010
011100101111
101001001111
101101011100
010001010100
101110101111
000111001101
011000001001
101001100001
110111011101
111000010000
011100000110
110011011100
000111010001
010010011000
111100010110
100001111011
001100001011
000111000101
100111110000
011000101101
100110000011
110011100001
000110110100
011110011011
011011001100
100001101010
100001100011
101010110100
010000001011
110000111001
101101010100
010000110001
111001010110
010000011011
101001001110
011010001010
000111010110
001011100000
111000000101
010100111101
010110000111
111011100100
000110010101
001010111010
101010110010
100000001111
000011110111
100110001000
110000011011
101011100000
110110000011
011110110000
101001001100
010011000110
011000101111
101111010010
101101110011
111010010100
000100110011
011010011110
110011110000
010001001110
110010111001
100101111100
101111000011
010000011010
111101010010
011001110111
001111100010
100010010011
110101001000
011010010000
001001010101
000101010010
100110101110
101101010111
111010001011
000110111011
110011111000
101100011001
010110011101
010011000001
001001000110
111011010001
011110101010
110110011001
111110101010
010000100010
010000111011
111000100010
000010100001
111000000000
111101000111
111100101001
111011110101
101010010001
111101101100
000010100011
000011011000
111101011010
101100111000
101010000000
010100000000
001000000110
111101100001
010100001100
110001011111
111111100101
000110011010
011011110110
100111000101
001010111101
000001101111
001111101101
001101101111
011001111000
011110011111
011000111010
001010100101
011000001011
001011010010
010000101001
100001101000
100011101000
101001101100
010011011010
011100001111
001110000001
101000001110
000110011111
111011110000
000101100010
011110000010
111011111101
011010000011
000100110100
000010101001
100011000000
001111000011
111100001110
110101000101
011000100011
101100110000
000110010111
101100000101
001110100101
000011011101
001010111000
000100011111
100110000000
011010111010
000110000100
011100100010
101001011101
110101010101
011110001110
100101011100
110010011101
111000101001
100111101010
001100011101
110011111101
100001110101
011101000001
011110111100
110011000100
101000101010
001100110001
011111001000
101101111111
010101001100
100100101111
000100111010
110100101001
100000010010
001000010101
110111111110
101110111001
110011100101
101001111011
101000011101
000011100011
011101001000
001110111001
001000100111
101100010001
110001100001
111100110100
001011000001
110000110010
100011110110
100100111111
101001000001
010100110001
010000000001
000000111101
100011000101
001111010010
010000001100
010011011110
100111111100
110111000100
100010101110
100100000011
100001001001
001110110100
001111111100
111101000011
100100110000
010110001101
001010101101
001001111000
000111110100
011100010000
001101000011
001101100001
000001100110
110010100011
111111010111
001100010001
001111001010
101000111001
000010011101
000011111111
001000010001
101111010011
011100111101
101100001011
011100001001
010011101101
001010110100
011011000011
111110000110
111100100011
010010110010
000101111111
000001010111
001110111010
101010111110
100110000010
101011110111
101100110100
010001111011
110110001010
111001110100
111101011100
010011010011
000000111100
110110010100
110000000110
110101111010
100010100110
101100110101
100110110111
100110000111
011101110111
101100001000
001000100000
001010101010
010111111111
101110001100
100001001110
111011110111
110110111000
010010011011
001111100111
001110000010
101110000100
111100011111
001100101011
110111000001
110101000111
010101010110
000001001101
111000111011
101011100111
101100000011
000111100101
010000101111
110010100100
001011000111
010100110000
011111000001
010110001001
010111001100
000111101100
010111000110
101011111101
001011100001
110110001000
010101101011
101100001111
101110100001
000000111110
110010010101
101000001100
101001000011
101001110110
110000111101
101111111100
100100000111
010111010111
100111110010
101101101000
000100010000
000000100000
011011111011
100111101110
111101110101
100100110111
100011100001
100010101010
011001100110
110001001001
111111101000
010011010111
111110001100
110101011001
111101110001
111011001101
001001001101
001010010000
101001111000
100001010000
111010001110
011001100111
111000101100
101100100110
111001001011
010111010100
111001010100
001101111101
011100111011
110001010111
110111010111
000101001000
111100100010
011000111011
101001010000
011101000110
011101010110
111111111100
100101010111
001101111001
011100111100
100101110010
111101001101
111100110000
001000100100
001100111010
011101101010
110101101000
011111100000
011010111110
011010011011
001101010101
111110110100
110001111100
110000011100
111010110111
011111001101
011101010001
111100101100
000100001101
101001110010
000010100101
110110001001
001001111101
011110101001
100010111100
111010001010
111010010000
001000101001
101100000001
000100100101
100101101101
101010001111
110010110101
111010010010
000001011000
010000110010
001011001011
100110000101
001110100110
000100000000
000110001110
000111011010
100010101101
110011110111
010001010111
111100011101
001110100010
011101101011
110101101101
111010011101
111010100111
110010001010
011011100111
111111010010
011011000101
000111000110
100101110111
110111101010
110010101010
101000110101
110000001100
000110111100
100000101011
100110111001
101011111100
101000100110
011101101101
011110000111
100101010101
111111101001
010000101101
111000110001
000100110001
010011101001
011101100010
100111001110
000101101001
010011100111
111100111010
111010011111
101111001101
011101010010
000100011010
010011110001
001011011000
000100111100
110011110001
000011010111
011110011010
010100111100
000000000100
100100011100
000100010011
000001001111
110100001011
001100100111
100010111010
110111111001
010001101110
101100101110
101100001100
100100000100
101001110001
101110101100
010111001110
101111000101
100011001001
100000000101
111010110100
011111001010
101011001101
100110100110
101001000010
111111101101
100011101001
100101110110
110001100000
111011101000
000101110111
000110100001
010001000110
001000010110
000100001011
001100101111
011000110111
000111111000
100100111101
000010111111
000001111100
001011111011
001000000010
110100110000
000101100001
001111011001
001010100010
110001101110
111111010101
101000001111
011011101000
000110011110
001011001010
111111001101
001001001100
111000011110
101110101000
101010000110
011011010000
010001011000
010010000111
010010110011
111010101011
001101111010
101110111011
000101000010
001101111111
010111000111
101011011110
011000010100
010011010001
100011011001
100011000111
100001011111
000001011100
111011000000
100110111110
011001000001
110000110110
001110111100
011001101001
011000010111
110001111010
110010011001
111010010111
001110000011
110010010000
010110110011
000101000100
011111010101
010110011100
010100001111
000100000001
101010110111
100100001011
001101000010
011100000111
100110101010
100011101011
001000110100""".split("\n").map{ it.trimIndent()}

}