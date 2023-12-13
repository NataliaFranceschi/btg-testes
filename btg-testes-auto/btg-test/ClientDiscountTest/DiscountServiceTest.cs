using btg_testes_auto.CartDiscount;
using btg_testes_auto.Discount;
using FluentAssertions;
using NSubstitute;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace btg_test.ClientDiscountTest
{
    public class DiscountServiceTest
    {
        private readonly ICustomerService _mockCustomerService;
        private readonly DiscountService _sut;

        public DiscountServiceTest()
        {
            _mockCustomerService = Substitute.For<ICustomerService>();
            _sut = new DiscountService(_mockCustomerService);
        }

        [Fact]
        public void GetDiscount_CustomerPremium_ReturnPriceWith10PercentOff()
        {
            _mockCustomerService.GetCustomerType(1)
                .Returns(CustomerType.Premium);

            double result = _sut.GetDiscount(1, 200);

            result.Should().Be(20);
            _mockCustomerService.Received().GetCustomerType(1);
        }

        [Fact]
        public void GetDiscount_CustomerRegular_ReturnPriceWith5PercentOff()
        {
            _mockCustomerService.GetCustomerType(1)
                .Returns(CustomerType.Regular);

            double result = _sut.GetDiscount(1, 200);

            result.Should().Be(10);
            _mockCustomerService.Received().GetCustomerType(1);
        }

        [Fact]
        public void GetDiscount_CustomerUnknown_ReturnFullPrice()
        {
            _mockCustomerService.GetCustomerType(1)
                .Returns(CustomerType.NotClient);

            double result = _sut.GetDiscount(1, 200);

            result.Should().Be(0);
            _mockCustomerService.Received().GetCustomerType(1);
        }
    }
}
