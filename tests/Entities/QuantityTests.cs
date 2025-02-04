using Checkout.Src.Entities;
using Checkout.Src.Exceptions;
using Xunit;

namespace Checkout.Tests.Entities
{
    public class QuantityTests
    {
        [Fact]
        public void Constructor_PositiveValue_SetsValue()
        {
            // Arrange
            int value = 10;

            // Act
            var quantity = new Quantity(value);

            // Assert
            Assert.Equal(value, quantity.Value);
        }

        [Fact]
        public void Constructor_ZeroValue_SetsValue()
        {
            // Arrange
            int value = 0;

            // Act
            var quantity = new Quantity(value);

            // Assert
            Assert.Equal(value, quantity.Value);
        }

        [Fact]
        public void Constructor_NegativeValue_ThrowsNegativeQuantityException()
        {
            // Arrange
            int value = -1;

            // Act & Assert
            Assert.Throws<NegativeQuantityException>(() => new Quantity(value));
        }

        [Fact]
        public void Equals_SameValue_ReturnsTrue()
        {
            // Arrange
            var quantity1 = new Quantity(10);
            var quantity2 = new Quantity(10);

            // Act
            bool areEqual = quantity1.Equals(quantity2);

            // Assert
            Assert.True(areEqual);
        }

        [Fact]
        public void Equals_DifferentValue_ReturnsFalse()
        {
            // Arrange
            var quantity1 = new Quantity(10);
            var quantity2 = new Quantity(20);

            // Act
            bool areEqual = quantity1.Equals(quantity2);

            // Assert
            Assert.False(areEqual);
        }

        [Fact]
        public void GetHashCode_SameValue_ReturnsSameHashCode()
        {
            // Arrange
            var quantity1 = new Quantity(10);
            var quantity2 = new Quantity(10);

            // Act
            int hashCode1 = quantity1.GetHashCode();
            int hashCode2 = quantity2.GetHashCode();

            // Assert
            Assert.Equal(hashCode1, hashCode2);
        }

        [Fact]
        public void GetHashCode_DifferentValue_ReturnsDifferentHashCode()
        {
            // Arrange
            var quantity1 = new Quantity(10);
            var quantity2 = new Quantity(20);

            // Act
            int hashCode1 = quantity1.GetHashCode();
            int hashCode2 = quantity2.GetHashCode();

            // Assert
            Assert.NotEqual(hashCode1, hashCode2);
        }
    }
}
