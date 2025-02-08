using Checkout.Src.Constants;
using Checkout.Src.Entities;
using Checkout.Src.Exceptions;
using Checkout.Tests.Builders;
using FluentAssertions;
using System;
using System.Collections.Generic;
using Xunit;

namespace Checkout.Tests
{
    public class CheckoutTests
    {
        [Fact]
        public void CalculateTotal_With_Default_Strategy_Returns_Total()
        {
            // Arrange
            var pricingRulesList = new List<PricingRule>
            {
                PricingRules.RuleA,
                PricingRules.RuleB
            };

            var checkout = new CheckoutBuilder()
                .WithDefaultPricingStrategy(pricingRulesList)
                .WithScannedItem(new Sku("A"))
                .WithScannedItem(new Sku("A"))
                .WithScannedItem(new Sku("A"))
                .WithScannedItem(new Sku("B"))
                .WithScannedItem(new Sku("B"))
                .Build();

            // Act
            Price total = checkout.CalculateTotal();

            // Assert
            total.Value.Should().Be(175);
        }

        [Fact]
        public void Constructor_With_Null_Strategy_Throws()
        {
            // Act
            Action act = () => new Checkout(null!);

            // Assert
            act.Should().Throw<ArgumentNullException>();
        }



    }
}
