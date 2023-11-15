namespace Tests;

public class AllTests
{
    // Tests for IsAmstrong() in MyMath.cs
    [Theory]
    [InlineData(0, true)]
    [InlineData(1, true)]
    [InlineData(10, false)]
    [InlineData(100, false)]
    [InlineData(12345, false)]
    [InlineData(153, true)]
    [InlineData(154, false)]
    [InlineData(1634, true)]
    [InlineData(222, false)]
    [InlineData(345633, false)]
    [InlineData(370, true)]
    [InlineData(371, true)]
    [InlineData(42, false)]
    [InlineData(420, false)]
    [InlineData(4210818, true)]
    [InlineData(5, true)]
    [InlineData(54748, true)]
    [InlineData(666, false)]
    [InlineData(9, true)]
    [InlineData(92727, true)]
    [InlineData(930564, false)]
    [InlineData(99999, false)]
    
    public void TestIsArmstrong(int number, bool expected)
    {
        Assert.Equal(expected, Smurfing.MyMaths.IsArmstrong(number));
    }
    
    // Argument Exception Tests for IsAmstrong() in MyMath.cs
    [Theory]
    [InlineData(-1)]
    [InlineData(-10)]
    
    public void TestIsArmstrongArgumentException(int number)
    {
        Assert.Throws<ArgumentException>(() => Smurfing.MyMaths.IsArmstrong(number));
    }
    
    public static double RoundToPrecision(double value, double precision)
    {
        int sign = (value < 0) ? -1 : 1;

        value /= precision;
        double mod = value % 1;
        value -= mod;
        value *= precision;
        
        return value * sign;
    }

    
    // Tests for Sqrt() in MyMath.cs
    [Theory]
    [InlineData(100, 0.0001, 10.0)]
    [InlineData(100, 0.01, 10.0)]
    [InlineData(142, 0.00001, 11.91637)]
    [InlineData(16, 0.1, 4.0)]
    [InlineData(16, 1, 4.0)]
    [InlineData(3, 0.00001, 1.73205)]
    [InlineData(3, 0.01, 1.73)]
    [InlineData(42, 0.001, 6.48)]
    [InlineData(42, 1, 6.0)]
    [InlineData(64, 0.01, 8.0)]
    [InlineData(64, 0.1, 8.0)]
    [InlineData(99, 0.001, 9.949)]
    [InlineData(99, 1, 9)]
    
    public void TestSqrt(int n, double precision, double expected)
    {
        // Arrange & Act
        double result = Smurfing.MyMaths.Sqrt(n, precision);

        // Assert
        Assert.Equal(expected, RoundToPrecision(result, precision)); // Round to the specified precision for comparison
    }
    
    // Argument Exception Tests for Sqrt() in MyMath.cs
    [Theory]
    [InlineData(-1, 0.0001)]
    [InlineData(0, 0.0001)]
    [InlineData(0, 1)]
    [InlineData(1, -1)]
    [InlineData(1, 0)]
    [InlineData(1, 10)]
    
    public void TestSqrtArgumentException(int n, double precision)
    {
        Assert.Throws<ArgumentException>(() => Smurfing.MyMaths.Sqrt(n, precision));
    }

    // Tests for RotChar() in Caesar.cs
    [Theory]
    [InlineData('!', -1, '!')]
    [InlineData('0', -16, '4')]
    [InlineData('0', -26000, '0')]
    [InlineData('0', 0, '0')]
    [InlineData('0', 100, '0')]
    [InlineData('0', 26000, '0')]
    [InlineData('9', 5, '4')]
    [InlineData('A', -24, 'C')]
    [InlineData('A', -26000, 'A')]
    [InlineData('A', 0, 'A')]
    [InlineData('A', 26000, 'A')]
    [InlineData('C', 53, 'D')]
    [InlineData('a', -26000, 'a')]
    [InlineData('a', 0, 'a')]
    [InlineData('a', 26000, 'a')]
    [InlineData('c', 26, 'c')]
    [InlineData('z', 1, 'a')]
    [InlineData('é', 52, 'é')]
    
    public void TestRotChar(char c, int key, char expected)
    {
        // Arrange & Act
        char result = Smurfing.Caesar.RotChar(c, key);

        // Assert
        Assert.Equal(expected, result);
    }
    
    // Tests for RotString() in Caesar.cs
    [Theory]
    [InlineData("20 sc kvgkic dro bsqrd kxcgob!", 42, "42 is always the right answer!")]
    [InlineData("42 42 42 42 42", 420, "42 42 42 42 42")]
    [InlineData("Ickhvydw yi tekrjydw.", -42, "Smurfing is doubting.")]
    [InlineData("Should not rotate!", 0, "Should not rotate!")]
    [InlineData("SuS >.<", 2, "UwU >.<")]
    [InlineData("XZAZ > XPJ", -23, "ACDC > ASM")]
    
    public void TestRotString(string text, int key, string expected)
    {
        // Arrange & Act
        string result = Smurfing.Caesar.RotString(text, key);

        // Assert
        Assert.Equal(expected, result);
    }
    
    // Function for creating all files
    private void CreatingAllFiles()
    {
        // Creting a empty file
        File.Create("empty.txt").Close();
        // Creating a file with a single line
        File.WriteAllText("singleLine.txt", "Baby Smurf;2");
        // Creating a file with multiple lines
        File.WriteAllText("multipleLines.txt", "Baby Smurf;2\nPapa Smurf;72\nSmurfette;42");
        // Creating a file with multiple lines
        File.WriteAllText("multipleLines2.txt", "Baby Smurf;2\nPapa Smurf;72\nSmurfette;42\nSmurfette;42\nPapa Smurf;72\nBaby Smurf;2");
        // Creating a file with multiple lines
        File.WriteAllText("multipleLines3.txt", "Smurf ACDC;22\nSmurf Student;18");
        // Creating a file with negative numbers
        File.WriteAllText("negativeNumbers.txt", "Baby Smurf;-2\nPapa Smurf;-72\nSmurfette;-42");
        // Creating a file with numbers 0
        File.WriteAllText("zeroNumbers.txt", "Baby Smurf;0\nPapa Smurf;0\nSmurfette;0");
    }
    
    // Function for deleting all files
    private void DeletingAllFiles()
    {
        // Deleting all files
        File.Delete("empty.txt");
        File.Delete("singleLine.txt");
        File.Delete("multipleLines.txt");
        File.Delete("multipleLines2.txt");
        File.Delete("multipleLines3.txt");
        File.Delete("negativeNumbers.txt");
        File.Delete("zeroNumbers.txt");
    }
    
    // Tests for SmurfParse() in Reading.cs
    [Theory]
    [InlineData("empty.txt", "")]
    [InlineData("singleLine.txt", "Baby Smurf is 2 years old.\n")]
    [InlineData("multipleLines.txt", "Baby Smurf is 2 years old.\nPapa Smurf is 72 years old.\nSmurfette is 42 years old.\n")]
    [InlineData("multipleLines2.txt", "Baby Smurf is 2 years old.\nPapa Smurf is 72 years old.\nSmurfette is 42 years old.\nSmurfette is 42 years old.\nPapa Smurf is 72 years old.\nBaby Smurf is 2 years old.\n")]
    [InlineData("multipleLines3.txt", "Smurf ACDC is 22 years old.\nSmurf Student is 18 years old.\n")]
    [InlineData("negativeNumbers.txt", "Baby Smurf is -2 years old.\nPapa Smurf is -72 years old.\nSmurfette is -42 years old.\n")]
    [InlineData("zeroNumbers.txt", "Baby Smurf is 0 years old.\nPapa Smurf is 0 years old.\nSmurfette is 0 years old.\n")]
    
    public void TestSmurfParse(string fileName, string expected)
    {
        // Arrange
        CreatingAllFiles();
        string result;
        
        // Act
        result = Smurfing.Reading.SmurfParse(fileName);
        
        // Assert
        Assert.Equal(expected, result);
        DeletingAllFiles();
    }
    
    // FileNotFound Exception Tests for SmurfParse() in Reading.cs
    [Theory]
    [InlineData("notFound.txt")]
    [InlineData("isADirectory/")]
    
    public void TestSmurfParseFileNotFoundException(string fileName)
    {
        Assert.Throws<FileNotFoundException>(() => Smurfing.Reading.SmurfParse(fileName));
    }
}