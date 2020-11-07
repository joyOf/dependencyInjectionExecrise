using System;
using System.Collections.Generic;

namespace dependencyInjection.Core
{
    public interface IProductStockRepository
    {
        bool IsInStock(Product product);
        void ReduceStock(Product product);
        void AddStock(Product product);
    }

    public class ProductStockRepository : IProductStockRepository
    {
        public static Dictionary<Product, int> ProductStockDatabase = Setup();

        private static Dictionary<Product, int> Setup()
        {
            var productStockDatabase = new Dictionary<Product, int>();
            productStockDatabase.Add(Product.Keyboard, 1);
            productStockDatabase.Add(Product.Mic, 1);
            productStockDatabase.Add(Product.Mouse, 1);
            productStockDatabase.Add(Product.Speaker, 1);
            return productStockDatabase;
        }

        public bool IsInStock(Product product)
        {
            Console.WriteLine("Call Get On Database");
            return ProductStockDatabase[product] > 0;
        }

        public void ReduceStock(Product product)
        {
            Console.WriteLine("Call Reduce On Database");
            ProductStockDatabase[product]--;
        }

        public void AddStock(Product product)
        {
            Console.WriteLine("Call Add On Database");
            ProductStockDatabase[product]++;
        }
    }
}
