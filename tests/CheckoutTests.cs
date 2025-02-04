using Checkout.Src.Entities;
using Checkout.Src.Exceptions;
using FluentAssertions;
using System;
using Xunit;

namespace Checkout.Tests
{
    public class CheckoutTests
    {
        [Fact]
        public void CalculateTotal_With_No_Items_Returns_Zero()
        {
            // Arrange
            var checkout = new CheckoutBuilder()
                .WithEveryPricingRules()
                .Build();

            // Act
            Price total = checkout.CalculateTotal();

            // Assert
            total.Value.Should().Be(0);
        }

        [Fact]
        public void CalculateTotal_With_Single_Item_Returns_RegularPrice()
        {
            // Arrange
            var checkout = new CheckoutBuilder()
                .WithEveryPricingRules()
                .WithScannedItem(new Sku("A"))
                .Build();

            // Act
            Price total = checkout.CalculateTotal();

            // Assert
            total.Value.Should().Be(50);
        }

        [Fact]
        public void CalculateTotal_With_Single_Discounted_Items_Returns_Discounted_Total()
        {
            // Arrange
            var checkout = new CheckoutBuilder()
                .WithEveryPricingRules()
                .WithScannedItem(new Sku("A"))
                .WithScannedItem(new Sku("A"))
                .WithScannedItem(new Sku("A"))
                .Build();

            // Act
            Price total = checkout.CalculateTotal();

            // Assert
            total.Value.Should().Be(130);
        }

        [Fact]
        public void CalculateTotal_With_Multiple_Discounted_Items_Returns_Discounted_Total()
        {
            // Arrange
            var checkout = new CheckoutBuilder()
                .WithEveryPricingRules()
                .WithScannedItem(new Sku("A"))
                .WithScannedItem(new Sku("A"))
                .WithScannedItem(new Sku("A"))
                .WithScannedItem(new Sku("B"))
                .WithScannedItem(new Sku("B"))
                .WithScannedItem(new Sku("C"))
                .Build();

            // Act
            Price total = checkout.CalculateTotal();

            // Assert
            total.Value.Should().Be(195);
        }

        [Fact]
        public void CalculateTotal_With_No_Discounted_Items_Returns_Total()
        {
            // Arrange
            var checkout = new CheckoutBuilder()
                .WithEveryPricingRules()
                .WithScannedItem(new Sku("C"))
                .WithScannedItem(new Sku("C"))
                .WithScannedItem(new Sku("C"))
                .WithScannedItem(new Sku("C"))
                .WithScannedItem(new Sku("C"))
                .Build();

            // Act
            Price total = checkout.CalculateTotal();

            // Assert
            total.Value.Should().Be(100);
        }

        [Fact]
        public void CalculateTotal_Without_Pricing_Rule_Throws()
        {
            // Arrange
            var checkout = new CheckoutBuilder()
                .WithScannedItem(new Sku("A"))
                .Build();

            // Act
            Action act = () => checkout.CalculateTotal();

            // Assert
            act.Should().Throw<MissingPricingRuleException>()
                .WithMessage("No pricing rule defined for SKU: A");
        }
    }
}
