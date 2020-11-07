using System;

namespace dependencyInjection.Core
{
    public interface IShippingProcessor
    {
        void MailProduct(Product product);
    }

    public class ShippingProcessor : IShippingProcessor
    {
        private readonly IProductStockRepository _productStockRepository;

        public ShippingProcessor(IProductStockRepository productStockRepository)
        {
            this._productStockRepository = productStockRepository;
        }

        public ShippingProcessor()
        {
        }

        public void MailProduct(Product product)
        {
            this._productStockRepository.ReduceStock(product);

            Console.WriteLine("Call To Shipping API");
        }
    }
}
