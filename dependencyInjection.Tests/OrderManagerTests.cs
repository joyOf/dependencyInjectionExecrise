using System;
using dependencyInjection.Core;
using Moq;
using Xunit;

namespace dependencyInjection.Tests
{
    public class OrderManagerTests
    {
        [Fact]
        public void Test1()
        {
            var productStockRepositoryMock = new Mock<IProductStockRepository>();
            productStockRepositoryMock.Setup(m => m.IsInStock(It.IsAny<Product>())).Returns(false);

            var paymentProcessorMock = new Mock<IPaymentProcessor>();
            var shippingProcessorMock = new Mock<ShippingProcessor>();

            var orderManager = new OrderManager(shippingProcessorMock.Object, paymentProcessorMock.Object,
                productStockRepositoryMock.Object
            );

            Assert.ThrowsAny<Exception>(() => { orderManager.Submit(Product.Keyboard, "1000100010001000", "1230"); });
        }
    }
}
