using System;
using Checkout.Src.Constants;
using Checkout.Src.Entities;
using Checkout.Src.Exceptions;
using Checkout.Tests.Builders;
using FluentAssertions;
using Xunit;

namespace Checkout.Tests.Pricings
{
    public class DefaultPricingStrategyTests
    {
        [Fact]
        public void CalculateTotal_With_No_Items_Returns_Zero()
        {
            // Arrange
            var pricingStrategy = new DefaultPricingStrategyBuilder()
                                           .WithEveryPricingRule()
                                           .Build();
            var scannedItems = new ScannedItems();

            // Act
            var total = pricingStrategy.CalculateTotal(scannedItems);

            // Assert
            total.Value.Should().Be(0);
        }

        [Fact]
        public void CalculateTotal_With_Single_Non_Discounted_Item_Returns_Total()
        {
            // Arrange
            var pricingStrategy = new DefaultPricingStrategyBuilder()
                                       .WithEveryPricingRule()
                                       .Build();
            var scannedItems = new ScannedItems();
            scannedItems.Add(new Sku("C"));

            // Act
            var total = pricingStrategy.CalculateTotal(scannedItems);

            // Assert
            total.Value.Should().Be(20);
        }

        [Fact]
        public void CalculateTotal_With_A_Discounted_Item_Returns_Discounted_Total()
        {
            // Arrange
            var pricingStrategy = new DefaultPricingStrategyBuilder()
                                           .WithEveryPricingRule()
                                           .Build();
            var scannedItems = new ScannedItems();
            scannedItems.Add(new Sku("A"));
            scannedItems.Add(new Sku("A"));
            scannedItems.Add(new Sku("A"));

            // Act
            var total = pricingStrategy.CalculateTotal(scannedItems);

            // Assert
            total.Value.Should().Be(130);
        }

        [Fact]
        public void CalculateTotal_With_Multiple_Discounted_Items_Returns_Discounted_Total()
        {
            // Arrange
            var pricingStrategy = new DefaultPricingStrategyBuilder()
                                           .WithEveryPricingRule()
                                           .Build();
            var scannedItems = new ScannedItems();
            scannedItems.Add(new Sku("A"));
            scannedItems.Add(new Sku("A"));
            scannedItems.Add(new Sku("A"));
            scannedItems.Add(new Sku("B"));
            scannedItems.Add(new Sku("B"));

            // Act
            var total = pricingStrategy.CalculateTotal(scannedItems);

            // Assert
            total.Value.Should().Be(175);
        }


        [Fact]
        public void CalculateTotal_With_No_Discounted_Items_Returns_Total()
        {
            // Arrange
            var pricingStrategy = new DefaultPricingStrategyBuilder()
                                           .WithEveryPricingRule()
                                           .Build();
            var scannedItems = new ScannedItems();
            scannedItems.Add(new Sku("C"));
            scannedItems.Add(new Sku("C"));
            scannedItems.Add(new Sku("C"));
            scannedItems.Add(new Sku("C"));
            scannedItems.Add(new Sku("C"));

            // Act
            var total = pricingStrategy.CalculateTotal(scannedItems);

            // Assert
            total.Value.Should().Be(100);
        }

        [Fact]
        public void CalculateTotal_With_Missing_PricingRule_Throws()
        {
            // Arrange
            var pricingStrategy = new DefaultPricingStrategyBuilder()
                                            .Build();
            var scannedItems = new ScannedItems();
            scannedItems.Add(new Sku("A"));
            scannedItems.Add(new Sku("A"));
            scannedItems.Add(new Sku("A"));

            // Act
            Action act = () => pricingStrategy.CalculateTotal(scannedItems);

            // Assert
            act.Should().Throw<MissingPricingRuleException>();
        }

        [Fact]
        public void Constructor_WithDuplicatePricingRules_Throws()
        {
            // Arrange
            // Act
            Action act = () => new DefaultPricingStrategyBuilder()
                                       .WithPricingRule(PricingRules.RuleA)
                                       .WithPricingRule(PricingRules.RuleA)
                                       .Build();

            // Assert
            act.Should().Throw<DuplicatePricingRuleException>();
        }
    }
}
