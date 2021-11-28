using ConwaysGameOfLife.Exceptions;
using ConwaysGameOfLife.Logic;
using Xunit;

namespace GameOfLifeTests
{
    public class ValidatorTests
    {
        // private const char AliveSymbol = 'o';
        // private const char DeadSymbol = '.';
        //
        // [Theory]
        // [InlineData("1")]
        // [InlineData("5")]
        // public void IsValidNumber_ShouldReturnTrue_WhenTheInputIsANumberAndIsLessThanTheMaximumLimit(string input)
        // {
        //     // Arrange
        //     var maximumLimit = 5;
        //     // Act
        //     var result = InputValidator.ValidateDimension(input, maximumLimit);
        //     // Assert
        //     Assert.True(result);
        // }
        //
        //
        // [Theory]
        // [InlineData("6")]
        // [InlineData("0")]
        // public void IsValidNumber_ShouldReturnFalse_WhenTheInputIsNotGreaterThan0OrLessThanMaximumLimit(string input)
        // {
        //     // Arrange
        //     var maximumLimit = 5;
        //     // Act
        //     var result = InputValidator.IsValidNumber(input, maximumLimit);
        //     // Assert
        //     Assert.False(result);
        // }
        //
        // [Theory]
        // [InlineData("-1")]
        // [InlineData("abc")]
        // [InlineData(null)]
        // [InlineData("")]
        // public void IsValidNumber_ShouldThrowInvalidDataException_WhenTheInputIsNullOrContainsNonNumericValues(string input)
        // {
        //     // Arrange
        //     var maximumLimit = 5;
        //     // Act and Assert
        //     Assert.Throws<InvalidInputException>(() => InputValidator.IsValidNumber(input, maximumLimit));
        // }
        //
        // [Theory]
        // [InlineData(null)]
        // [InlineData("")]
        // public void IsValidRow_ShouldThrowInvalidDataException_WhenTheInputIsNullOrEmpty(string input)
        // {
        //     // Arrange
        //     var rowWidth = 3;
        //     // Act and Assert
        //     Assert.Throws<InvalidInputException>(() => InputValidator.IsValidWorldRow(input, rowWidth, AliveSymbol, DeadSymbol));
        // }
        //
        // [Theory]
        // [InlineData("oo-")]
        // [InlineData("jkh")]
        // [InlineData("O..")]
        // public void IsValidRow_ShouldThrowInvalidDataException_WhenTheInputContainsCharactersOtherThanAliveSymbolAndDeadSymbols(string input)
        // {
        //     // Arrange
        //     var rowWidth = 3;
        //     var aliveSymbol = 'o';
        //     var deadSymbol = '.';
        //     // Act and Assert
        //     Assert.Throws<InvalidInputException>(() => InputValidator.IsValidWorldRow(input, rowWidth, aliveSymbol, deadSymbol));
        // }
        //
        // [Theory]
        // [InlineData("o")]
        // [InlineData("o.")]
        // [InlineData("o.o.")]
        // public void IsValidRow_ShouldThrowInvalidDataException_WhenTheInputLengthIsNotSameAsRowWidth(string input)
        // {
        //     // Arrange
        //     var rowWidth = 3;
        //     var aliveSymbol = 'o';
        //     var deadSymbol = '.';
        //     // Act and Assert
        //     Assert.Throws<InvalidInputException>(() => InputValidator.IsValidWorldRow(input, rowWidth, aliveSymbol, deadSymbol));
        // }
        
        // [Theory]
        // [InlineData("o..|...|...")]
        // // [InlineData("...")]
        // // [InlineData("ooo")]
        // public void IsValidRow_ShouldReturnTrue_WhenTheInputIsAValidRowOfCorrectLengthAndContainsAliveAndDeadSymbolsOnly(string input)
        // {
        //     // Arrange
        //     var rows = 3;
        //     var columns = 3;
        //     var aliveSymbol = 'o';
        //     var deadSymbol = '.';
        //     // Act
        //     InputValidator.ValidateWorld(input, rows, columns, aliveSymbol, deadSymbol);
        //     // Assert
        //   //  Assert.True(result);
        // }
        
    }
}