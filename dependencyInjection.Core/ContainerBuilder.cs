using System;
using Microsoft.Extensions.DependencyInjection;

namespace dependencyInjection.Core
{
    public class ContainerBuilder
    {
        public IServiceProvider Build()
        {
            var container = new ServiceCollection();

            container.AddSingleton<IOrderManager, OrderManager>();
            container.AddSingleton<IPaymentProcessor, PaymentProcessor>();
            container.AddSingleton<IShippingProcessor, ShippingProcessor>();
            container.AddSingleton<IProductStockRepository, ProductStockRepository>();

            return container.BuildServiceProvider();
        }
    }
}
