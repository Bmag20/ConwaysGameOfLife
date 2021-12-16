using ConwaysGameOfLife.Source.Constants;
using ConwaysGameOfLife.Source.Exceptions;
using ConwaysGameOfLife.Source.Seed_Setup;
using Xunit;

namespace GameOfLifeTests.SetupTests
{
    public class ValidatorTests
    {
        [Fact]
        public void ValidateDimension_ShouldThrowInvalidDimensionException_WhenTheInputGreaterThanMaximumLimit()
        {
            // Arrange
            var maximumLimit = GameConstants.MaximumGridSize;
            var input = maximumLimit + 1;
            // Act
            var exception = Record.Exception(() => InputValidator.ValidateDimension(input));
            // Assert
            Assert.IsType<InvalidDimensionException>(exception);
        }

        [Theory]
        [InlineData("-1")]
        [InlineData("abc")]
        public void ValidateDimension_ShouldThrowInvalidDataException_WhenTheInputContainsNonNumericValues(string input)
        {
            // Act
            var exception = Record.Exception(() => InputValidator.ValidateDimension(input));
            // Assert
            Assert.IsType<InvalidDimensionException>(exception);
        }

        [Theory]
        [InlineData(null)]
        [InlineData("")]
        public void ValidateDimension_ShouldThrowEmptyInputException_WhenTheInputIsNull(string input)
        {
            // Act
            var exception = Record.Exception(() => InputValidator.ValidateDimension(input));
            // Assert
            Assert.IsType<EmptyInputException>(exception);
        }

        [Theory]
        [InlineData("1")]
        [InlineData("5")]
        public void ValidateDimension_ShouldNotThrowException_WhenTheInputIsANumberAndIsLessThanTheMaximumLimit(
            string input)
        {
            InputValidator.ValidateDimension(input);
        }

        [Theory]
        [InlineData(null)]
        [InlineData("")]
        public void ValidateWorld_ShouldThrowEmptyInputException_WhenTheInputIsNullOrEmpty(string input)
        {
            // Arrange
            var height = 5;
            var width = 5;
            // Act
            var exception = Record.Exception(() => InputValidator.ValidateSeed(input, height, width));
            // Assert
            Assert.IsType<EmptyInputException>(exception);
        }

        [Theory]
        [InlineData("oo-|...|o..")]
        [InlineData("jkh|lmn|jhw")]
        [InlineData("O..|.O.|..O")]
        public void
            ValidateWorld_ShouldThrowInvalidDataException_WhenTheInputContainsCharactersOtherThanAliveSymbolAndDeadSymbols(
                string input)
        {
            // Arrange
            var height = 3;
            var width = 3;
            // Act and Assert
            Assert.Throws<InvalidSeedException>(() => InputValidator.ValidateSeed(input, height, width));
        }

        [Theory]
        [InlineData("ooo|ooo")]
        [InlineData("ooo|ooo|ooo|ooo")]
        [InlineData("o.|..|..")]
        [InlineData("o.o.|ooo|o.o")]
        public void ValidateWorld_ShouldThrowInvalidDataException_WhenTheInputHasIncorrectDimensions(string input)
        {
            // Arrange
            var height = 3;
            var width = 3;
            // Act and Assert
            Assert.Throws<InvalidSeedException>(() => InputValidator.ValidateSeed(input, height, width));
        }

        [Theory]
        [InlineData("o..|...|...")]
        public void ValidateWorld_ShouldNotThrowException_WhenTheInputIsInValidForm(string input)
        {
            // Arrange
            var rows = 3;
            var columns = 3;
            // Act
            InputValidator.ValidateSeed(input, rows, columns);
        }
    }
}