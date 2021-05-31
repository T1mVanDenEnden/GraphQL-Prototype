using System;
using GraphQL_Prototype.Models;
using GraphQL_Prototype.Services;

namespace GraphQL_Prototype.GraphQL
{
    public class Mutation
    {
        public Product CreateProduct(Product product)
        {
            CatalogService.AddProduct(product);
            return product;
        }
        
        public Product EditProduct(Product product)
        {
            CatalogService.EditProduct(product);
            return product;
        }
        
        public Product RemoveProduct(Product product)
        {
            CatalogService.RemoveProduct(product);
            return product;
        }
    }
}