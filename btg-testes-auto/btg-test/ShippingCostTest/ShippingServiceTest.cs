﻿using btg_testes_auto.Discount;
using btg_testes_auto.ShippingCost;
using FluentAssertions;
using NSubstitute;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace btg_test.ShippingCostTest
{
    public class ShippingServiceTest
    {
        private readonly IDeliveryCostCalculator _mockDeliveryCostCalculator;
        private readonly ShippingService _sut;

        public ShippingServiceTest()
        {
            _mockDeliveryCostCalculator = Substitute.For<IDeliveryCostCalculator>();
            _sut = new ShippingService(_mockDeliveryCostCalculator);
        }

        [Fact]
        public void CalculateShippingCost_DistanceGreaterThan200DeliveryTypeExpress_ReturnCost50PercentOff()
        {
            var cost = _mockDeliveryCostCalculator.CalculateCost(220, DeliveryType.Express)
                .Returns(100);

            double result = _sut.CalculateShippingCost(220, DeliveryType.Express);

            result.Should().Be(50);
            _mockDeliveryCostCalculator.Received().CalculateCost(220, DeliveryType.Express);
        }

        [Fact]
        public void CalculateShippingCost_DistanceEqual200DeliveryTypeExpress_ResturnNormalCost()
        {
            var cost = _mockDeliveryCostCalculator.CalculateCost(200, DeliveryType.Express)
                .Returns(100);

            double result = _sut.CalculateShippingCost(200, DeliveryType.Express);

            result.Should().Be(100);
            _mockDeliveryCostCalculator.Received().CalculateCost(200, DeliveryType.Express);
        }

        [Fact]
        public void CalculateShippingCost_DistanceLessThan200DeliveryTypeExpress_ReturnNormalCost()
        {
            var cost = _mockDeliveryCostCalculator.CalculateCost(180, DeliveryType.Express)
                .Returns(100);

            double result = _sut.CalculateShippingCost(180, DeliveryType.Express);

            result.Should().Be(100);
            _mockDeliveryCostCalculator.Received().CalculateCost(180, DeliveryType.Express);
        }

        [Fact]
        public void CalculateShippingCost_DistanceGreaterThan200DeliveryTypeOrdinary_ReturnNormalCost()
        {
            var cost = _mockDeliveryCostCalculator.CalculateCost(220, DeliveryType.Ordinary)
                .Returns(100);

            double result = _sut.CalculateShippingCost(220, DeliveryType.Ordinary);

            result.Should().Be(100);
            _mockDeliveryCostCalculator.Received().CalculateCost(220, DeliveryType.Ordinary);
        }

        [Fact]
        public void CalculateShippingCost_DistanceLessThan200DeliveryTypeOrdinary_ReturnNormalCost()
        {
            var cost = _mockDeliveryCostCalculator.CalculateCost(220, DeliveryType.Ordinary)
                .Returns(100);

            double result = _sut.CalculateShippingCost(220, DeliveryType.Ordinary);

            result.Should().Be(100);
            _mockDeliveryCostCalculator.Received().CalculateCost(220, DeliveryType.Ordinary);
        }
    
}
}
