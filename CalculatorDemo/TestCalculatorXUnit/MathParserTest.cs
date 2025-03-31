using CalculatorDemo;

namespace TestCalculatorXUnit;

public class MathParserTest
{
    [Fact]
    public void InvalidInput_TestCase() //null or empty case
    {
        IMathParser parser = new MathParser();
        Assert.Throws<ArgumentException>(() => parser.Normalise(null));
        Assert.Throws<ArgumentException>(() => parser.Normalise(""));
    }

    [Fact]
    public void InputDoesntMatch_TestCase() //input doesnt match regex
    {
        IMathParser parser = new MathParser();
        Assert.Throws<ArgumentException>(() => parser.Normalise("a@a"));
    }

    [Theory]
    [InlineData("2+1", new string[] { "2", "+", "1" })]
    [InlineData("60-(3*10)", new string[] { "60", "-", "(", "3", "*", "10", ")" })]
    public void TestCases(string input, string[] expected)
    {
        IMathParser parser = new MathParser();
        var result = parser.Normalise(input);
        Assert.Equal(expected, result);
    }
}