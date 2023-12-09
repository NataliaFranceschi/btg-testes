using btg_testes_auto.CartDiscount;
using btg_testes_auto.Order;
using NSubstitute;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace btg_test.CartDiscountTest
{
    public class CartServiceTest
    {
        private readonly IDiscountService _mockDiscountService;
        private readonly CartService _sut;

        public CartServiceTest()
        {
            _mockDiscountService = Substitute.For<IDiscountService>();
            _sut = new CartService(_mockDiscountService);
        }

        [Fact]
        public void ProcessCart_Cart_Return270()
        {
            // Arrange
            CartItem cartItem = new()
            {
                ProductId = "1",
                Price = 150,
            };

            List<CartItem> cart = new() {  cartItem, cartItem };

            _mockDiscountService.CalculateDiscount(cart)
                .Returns(30);

            double result = _sut.CalculateTotalWithDiscount(cart);

            // Assert
            result.Equals(270);
            _mockDiscountService.Received().CalculateDiscount(cart);
        }
    }
}
