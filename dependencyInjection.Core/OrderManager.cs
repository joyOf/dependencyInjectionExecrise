using System;

namespace dependencyInjection.Core
{
    public interface IOrderManager
    {
        public void Submit (Product product, string creditCardNumber, string expiryDate);
    }

    public class OrderManager : IOrderManager
    {
        private readonly IShippingProcessor _shippingProcessor;
        private readonly IPaymentProcessor _paymentProcessor;
        private readonly IProductStockRepository _productStockRepository;

        public OrderManager(IShippingProcessor shippingProcessor, IPaymentProcessor paymentProcessor,
            IProductStockRepository productStockRepository)
        {
            this._shippingProcessor = shippingProcessor;
            this._paymentProcessor = paymentProcessor;
            this._productStockRepository = productStockRepository;
        }

        public void Submit (Product product, string creditCardNumber, string expiryDate)
        {
            // Check product stock
            if (!this._productStockRepository.IsInStock(product))
                throw new Exception($"{product.ToString()} Currently Not In Stock");

            // Payment
            this._paymentProcessor.ChargeCreditCard(creditCardNumber, expiryDate);

            // Ship the product
            this._shippingProcessor.MailProduct(product);
        }
    }
}
