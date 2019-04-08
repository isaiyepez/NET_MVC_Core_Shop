using System;
using System.Collections.Generic;
using System.Linq;
using Shop.Web2.Data.Entities;

namespace Shop.Web2.Data
{
    public class ProductRepository : GenericRepository<Product>, IProductRepository
    {
        public ProductRepository(DataContext context) : base(context)
        {
        }
    }
}
