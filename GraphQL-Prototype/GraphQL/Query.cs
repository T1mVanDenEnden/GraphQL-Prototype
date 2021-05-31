using System;
using System.Collections.Generic;
using System.Linq;
using GraphQL_Prototype.Models;
using GraphQL_Prototype.Services;
using HotChocolate.Data;
using HotChocolate.Types;

namespace GraphQL_Prototype.GraphQL
{
    public class Query
    {
        [UsePaging]
        [UseFiltering]
        [UseSorting]
        [UseOffsetPaging]
        public IQueryable<Product> GetCatalog(string? search)
        {
            if (search != null)
            {
                return CatalogService.Catalog.Where(p => p.Name.Contains(search)).AsQueryable();
            }
            
            return CatalogService.Catalog.AsQueryable();
        }
        
        public Product GetProduct(int id)
        {
            if (CatalogService.Catalog.Count == 0)
            {
                throw new Exception("There are no products.");
            }
            
            
            List<Product> products = CatalogService.Catalog.Where(p => p.Id == id).ToList();
            if (products.Count == 0)
            {
                throw new Exception("Could not find any product with this id.");
            }

            return products.Single();
        }
    }
}