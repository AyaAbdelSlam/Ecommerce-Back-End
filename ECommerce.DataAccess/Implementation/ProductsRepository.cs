using ECommerce.DataAccess.Abstraction;
using ECommerce.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace ECommerce.DataAccess.Implementation
{
    public class ProductsRepository: BaseRepository<Product>
    {
        public ProductsRepository(EShopContext context) :base(context)
        {

        }
    }
}
