
[TestClass]
public class StringCalculatorTests
{
    [TestMethod]
    public void TestAdd_EmptyString_ReturnsZero()
    {
        // Arrange
        string numbers = "";
        StringCalculator calculator = new StringCalculator();

        // Act
        int result = calculator.Add(numbers);

        // Assert
        Assert.AreEqual(0, result);
    }

    [TestMethod]
    public void TestAdd_SingleNumber_ReturnsNumber()
    {
        // Arrange
        string numbers = "5";
        StringCalculator calculator = new StringCalculator();

        // Act
        int result = calculator.Add(numbers);

        // Assert
        Assert.AreEqual(5, result);
    }

    [TestMethod]
    public void TestAdd_TwoNumbers_ReturnsSum()
    {
        // Arrange
        string numbers = "3,7";
        StringCalculator calculator = new StringCalculator();

        // Act
        int result = calculator.Add(numbers);

        // Assert
        Assert.AreEqual(10, result);
    }

    [TestMethod]
    public void TestAdd_StringWithMoreThanTwoNumbers_ReturnsSum()
    {
        // Arrange
        string numbers = "1,2,3,4,5";
        StringCalculator calculator = new StringCalculator();

        // Act
        int result = calculator.Add(numbers);

        // Assert
        Assert.AreEqual(15, result);
    }

    [TestMethod]
    public void TestAdd_StringWithNewLine_ReturnsSum()
    {
        // Arrange
        string numbers = "1\n2,3";
        StringCalculator calculator = new StringCalculator();

        // Act
        int result = calculator.Add(numbers);

        // Assert
        Assert.AreEqual(6, result);
    }

    [TestMethod]
    public void TestAdd_CustomDelimiterSemicolon_ReturnsSum()
    {
        // Arrange
        string numbers = "//;\n1;2";
        StringCalculator calculator = new StringCalculator();

        // Act
        int result = calculator.Add(numbers);

        // Assert
        Assert.AreEqual(3, result);
    }

    [TestMethod]
    public void TestAdd_CustomDelimiterHash_ReturnsSum()
    {
        // Arrange
        string numbers = "//#\n1#2";
        StringCalculator calculator = new StringCalculator();

        // Act
        int result = calculator.Add(numbers);

        // Assert
        Assert.AreEqual(3, result);
    }

    [TestMethod]
    public void TestAdd_CustomDelimiterLetterK_ReturnsSum()
    {
        // Arrange
        string numbers = "//K\n1K2";
        StringCalculator calculator = new StringCalculator();

        // Act
        int result = calculator.Add(numbers);

        // Assert
        Assert.AreEqual(3, result);
    }

    [TestMethod]
    public void TestAdd_NegativeNumber_ThrowsException()
    {
        // Arrange
        string numbers = "1,2,-3,4";
        StringCalculator calculator = new StringCalculator();

        // Act & Assert
        Assert.ThrowsException<Exception>(() => calculator.Add(numbers), "Negatives not allowed: -3");
    }

    [TestMethod]
    public void TestAdd_MultipleNegativeNumbers_ThrowsException()
    {
        // Arrange
        string numbers = "1,-8,-2,5";
        StringCalculator calculator = new StringCalculator();

        // Act & Assert
        Assert.ThrowsException<Exception>(() => calculator.Add(numbers), "Negatives not allowed: -8 -2");
    }

    [TestMethod]
    public void TestAdd_NumberGreaterThan1000_IgnoresNumber()
    {
        // Arrange
        string numbers = "2,1001";
        StringCalculator calculator = new StringCalculator();

        // Act
        int result = calculator.Add(numbers);

        // Assert
        Assert.AreEqual(2, result);
    }

    [TestMethod]
    public void TestAdd_NumberEqualTo1000_IncludesNumber()
    {
        // Arrange
        string numbers = "500,1000";
        StringCalculator calculator = new StringCalculator();

        // Act
        int result = calculator.Add(numbers);

        // Assert
        Assert.AreEqual(1500, result);
    }

    [TestMethod]
    public void TestAdd_CustomDelimiterSquareBrackets_ReturnsSum()
    {
        // Arrange
        string numbers = "//[##]\n1##2";
        StringCalculator calculator = new StringCalculator();

        // Act
        int result = calculator.Add(numbers);

        // Assert
        Assert.AreEqual(3, result);
    }

    [TestMethod]
    public void TestAdd_CustomDelimiterAsterisks_ReturnsSum()
    {
        // Arrange
        string numbers = "//[***]\n1***2***3";
        StringCalculator calculator = new StringCalculator();

        // Act
        int result = calculator.Add(numbers);

        // Assert
        Assert.AreEqual(6, result);
    }

    [TestMethod]
    public void TestAdd_MultipleDelimiters_ReturnsSum()
    {
        // Arrange
        string numbers = "//[*][%]\n1*2%3";
        StringCalculator calculator = new StringCalculator();

        // Act
        int result = calculator.Add(numbers);

        // Assert
        Assert.AreEqual(6, result);
    }

    [TestMethod]
    public void TestAdd_MultipleDelimitersWithDifferentCharacters_ReturnsSum()
    {
        // Arrange
        string numbers = "//[@][#]\n1@2#3@4";
        StringCalculator calculator = new StringCalculator();

        // Act
        int result = calculator.Add(numbers);

        // Assert
        Assert.AreEqual(10, result);
    }

    [TestMethod]
    public void TestAdd_MultipleDelimitersWithLongerLength_ReturnsSum()
    {
        // Arrange
        string numbers = "//[***][%%%]\n1***2%%%3";
        StringCalculator calculator = new StringCalculator();

        // Act
        int result = calculator.Add(numbers);

        // Assert
        Assert.AreEqual(6, result);
    }

    [TestMethod]
    public void TestAdd_MultipleDelimitersWithDifferentCharactersAndLongerLength_ReturnsSum()
    {
        // Arrange
        string numbers = "//[##][WW]\n1##2WW3##4";
        StringCalculator calculator = new StringCalculator();

        // Act
        int result = calculator.Add(numbers);

        // Assert
        Assert.AreEqual(10, result);
    }

}