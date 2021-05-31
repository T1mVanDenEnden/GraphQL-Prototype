using System.Collections.Generic;
using GraphQL_Prototype.Models;

namespace GraphQL_Prototype.Services
{
    public static class CatalogService
    {
        public static List<Product> Catalog = new List<Product>();

        public static void AddProduct(Product product)
        {
            Catalog.Add(product);
        }
        
        public static void RemoveProduct(Product product)
        {
            Product tempProduct = Catalog.Find(p => p.Id == product.Id);
            
            // Check if we found product.
            if (tempProduct != null)
            {
                Catalog.Remove(tempProduct);
            }
        }

        public static void EditProduct(Product product)
        {
            Product tempProduct = Catalog.Find(p => p.Id == product.Id);
            
            // Check if we found product.
            if (tempProduct != null)
            {
                Catalog.Remove(tempProduct);
            }
            
            Catalog.Add(product);
        }
    }
}