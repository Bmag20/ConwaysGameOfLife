using System.IO;
using ConwaysGameOfLife.Exceptions;
using ConwaysGameOfLife.Logic;
using Xunit;

namespace GameOfLifeTests
{
    public class ValidatorTests
    {
        [Theory]
        [InlineData("1")]
        [InlineData("5")]
        public void IsValidNumber_ShouldReturnTrue_WhenTheInputIsANumberAndIsLessThanTheMaximumLimit(string input)
        {
            // Arrange
            var maximumLimit = 5;
            // Act
            var result = InputValidator.IsValidNumber(input, maximumLimit);
            // Assert
            Assert.True(result);
        }
        
        
        [Theory]
        [InlineData("6")]
        [InlineData("0")]
        public void IsValidNumber_ShouldReturnFalse_WhenTheInputIsNotGreaterThan0OrLessThanMaximumLimit(string input)
        {
            // Arrange
            var maximumLimit = 5;
            // Act
            var result = InputValidator.IsValidNumber(input, maximumLimit);
            // Assert
            Assert.False(result);
        }
        
        [Theory]
        [InlineData("-1")]
        [InlineData("abc")]
        [InlineData(null)]
        [InlineData("")]
        public void IsValidNumber_ShouldThrowInvalidDataException_WhenTheInputIsNullOrContainsNonNumericValues(string input)
        {
            // Arrange
            var maximumLimit = 5;
            // Act and Assert
            Assert.Throws<InvalidInputException>(() => InputValidator.IsValidNumber(input, maximumLimit));
        }
    }
}