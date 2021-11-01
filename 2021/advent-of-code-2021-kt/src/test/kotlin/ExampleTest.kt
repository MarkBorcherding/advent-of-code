import kotlin.test.Test
import kotlin.test.assertEquals

internal class ExampleTest {

    @Test
    fun testSum() {
        val expected = 42
        assertEquals(expected, Day01().Doit(41,1))
    }
}