using Checkout.Src.Entities;
using Checkout.Src.Exceptions;
using Xunit;

namespace Checkout.Tests.Entities
{
    public class SkuTests
    {
        [Fact]
        public void Constructor_ValidValue_SetsValue()
        {
            // Arrange
            string value = "A";

            // Act
            var sku = new Sku(value);

            // Assert
            Assert.Equal(value, sku.Value);
        }

        [Fact]
        public void Constructor_NullValue_ThrowsEmptySkuException()
        {
            // Arrange
            string value = null;

            // Act & Assert
            Assert.Throws<EmptySkuException>(() => new Sku(value));
        }

        [Fact]
        public void Constructor_EmptyValue_ThrowsEmptySkuException()
        {
            // Arrange
            string value = "";

            // Act & Assert
            Assert.Throws<EmptySkuException>(() => new Sku(value));
        }

        [Fact]
        public void Constructor_WhitespaceValue_ThrowsEmptySkuException()
        {
            // Arrange
            string value = "   ";

            // Act & Assert
            Assert.Throws<EmptySkuException>(() => new Sku(value));
        }

        [Fact]
        public void Constructor_NonAlphabeticValue_ThrowsInvalidSkuException()
        {
            // Arrange
            string value = "123";

            // Act & Assert
            Assert.Throws<InvalidSkuException>(() => new Sku(value));
        }

        [Fact]
        public void Constructor_MultipleCharactersValue_ThrowsInvalidSkuException()
        {
            // Arrange
            string value = "AB";

            // Act & Assert
            Assert.Throws<InvalidSkuException>(() => new Sku(value));
        }

        [Fact]
        public void Equals_SameValue_ReturnsTrue()
        {
            // Arrange
            var sku1 = new Sku("A");
            var sku2 = new Sku("A");

            // Act
            bool areEqual = sku1.Equals(sku2);

            // Assert
            Assert.True(areEqual);
        }

        [Fact]
        public void Equals_DifferentValue_ReturnsFalse()
        {
            // Arrange
            var sku1 = new Sku("A");
            var sku2 = new Sku("B");

            // Act
            bool areEqual = sku1.Equals(sku2);

            // Assert
            Assert.False(areEqual);
        }

        [Fact]
        public void GetHashCode_SameValue_ReturnsSameHashCode()
        {
            // Arrange
            var sku1 = new Sku("A");
            var sku2 = new Sku("A");

            // Act
            int hashCode1 = sku1.GetHashCode();
            int hashCode2 = sku2.GetHashCode();

            // Assert
            Assert.Equal(hashCode1, hashCode2);
        }

        [Fact]
        public void GetHashCode_DifferentValue_ReturnsDifferentHashCode()
        {
            // Arrange
            var sku1 = new Sku("A");
            var sku2 = new Sku("B");

            // Act
            int hashCode1 = sku1.GetHashCode();
            int hashCode2 = sku2.GetHashCode();

            // Assert
            Assert.NotEqual(hashCode1, hashCode2);
        }
    }
}
