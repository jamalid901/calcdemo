using CalculatorDemo;

namespace TestCalculatorXUnit;

public class MathParserTest
{
    [Theory]
    [InlineData("2+1", new string[] { "2", "+", "1" })]
    public void TestCases(string input, string[] expected)
    {
        IMathParser parser = new MathParser();
        var result = parser.Normalise(input);
        Assert.Equal(expected, result);
    }
}