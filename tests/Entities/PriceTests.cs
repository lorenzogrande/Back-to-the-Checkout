using Checkout.Src.Entities;
using Checkout.Src.Exceptions;
using FluentAssertions;
using System;
using Xunit;

namespace Checkout.Tests.Entities
{
    public class PriceTests
    {
        [Fact]
        public void Constructor_PositiveValue_SetsValue()
        {
            // Arrange
            decimal value = 100m;

            // Act
            var price = new Price(value);

            // Assert
            price.Value.Should().Be(value);
        }

        [Fact]
        public void Constructor_ZeroValue_SetsValue()
        {
            // Arrange
            decimal value = 0m;

            // Act
            var price = new Price(value);

            // Assert
            price.Value.Should().Be(value);
        }

        [Fact]
        public void Constructor_NegativeValue_ThrowsNegativePriceException()
        {
            // Arrange
            decimal value = -1m;

            // Act & Assert
            Action act = () => new Price(value);
            act.Should().Throw<NegativePriceException>();
        }

        [Fact]
        public void Equals_SameValue_ReturnsTrue()
        {
            // Arrange
            var price1 = new Price(100m);
            var price2 = new Price(100m);

            // Act
            bool areEqual = price1.Equals(price2);

            // Assert
            areEqual.Should().BeTrue();
        }

        [Fact]
        public void Equals_DifferentValue_ReturnsFalse()
        {
            // Arrange
            var price1 = new Price(100m);
            var price2 = new Price(200m);

            // Act
            bool areEqual = price1.Equals(price2);

            // Assert
            areEqual.Should().BeFalse();
        }

        [Fact]
        public void GetHashCode_SameValue_ReturnsSameHashCode()
        {
            // Arrange
            var price1 = new Price(100m);
            var price2 = new Price(100m);

            // Act
            int hashCode1 = price1.GetHashCode();
            int hashCode2 = price2.GetHashCode();

            // Assert
            hashCode1.Should().Be(hashCode2);
        }

        [Fact]
        public void GetHashCode_DifferentValue_ReturnsDifferentHashCode()
        {
            // Arrange
            var price1 = new Price(100m);
            var price2 = new Price(200m);

            // Act
            int hashCode1 = price1.GetHashCode();
            int hashCode2 = price2.GetHashCode();

            // Assert
            hashCode1.Should().NotBe(hashCode2);
        }
    }
}
