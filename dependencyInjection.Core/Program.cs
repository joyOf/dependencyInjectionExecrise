using System;
using Microsoft.Extensions.DependencyInjection;

namespace dependencyInjection.Core
{
    class Program
    {
        public static readonly IServiceProvider Container = new ContainerBuilder().Build();

        static void Main(string[] args)
        {
            var product = string.Empty;
            var productStockRepo = new ProductStockRepository();

            var orderManager = Container.GetService<IOrderManager>();


            while (product != "exit")
            {
                Console.WriteLine(@"Enter Your Product:
Keyboard = 0,
Mouse = 1,
Mic = 2,
Speaker = 3");
                product = Console.ReadLine();

                try
                {
                    if (Enum.TryParse(product, out Product productEnum))
                    {
                        Console.WriteLine("Please Enter a Valid Payment Method: XXXXXXXXXXXXXXXX;MMYY");
                        var paymentMethod = Console.ReadLine();

                        if (string.IsNullOrEmpty(paymentMethod) || paymentMethod.Split(";").Length != 2)
                            throw new Exception("Invalid Payment method");

                        orderManager.Submit(productEnum, paymentMethod.Split(";")[0], paymentMethod.Split(";")[1]);

                        Console.WriteLine($"{productEnum.ToString()} Has Been Shipped");
                    }
                    else
                    {
                        Console.WriteLine("Invalid Product");
                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                }

                Console.WriteLine(Environment.NewLine);
            }
        }
    }
}
