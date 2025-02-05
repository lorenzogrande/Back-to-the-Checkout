using Checkout.Src.Entities;
using Checkout.Src.Exceptions;
using FluentAssertions;
using System;
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
            quantity.Value.Should().Be(value);
        }

        [Fact]
        public void Constructor_ZeroValue_SetsValue()
        {
            // Arrange
            int value = 0;

            // Act
            var quantity = new Quantity(value);

            // Assert
            quantity.Value.Should().Be(value);
        }

        [Fact]
        public void Constructor_NegativeValue_ThrowsNegativeQuantityException()
        {
            // Arrange
            int value = -1;

            // Act & Assert
            Action act = () => new Quantity(value);
            act.Should().Throw<NegativeQuantityException>();
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
            areEqual.Should().BeTrue();
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
            areEqual.Should().BeFalse();
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
            hashCode1.Should().Be(hashCode2);
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
            hashCode1.Should().NotBe(hashCode2);
        }
    }
}
