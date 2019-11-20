using ECommerce.DataAccess.Abstraction;
using ECommerce.Entities;

namespace ECommerce.DataAccess.Implementation
{
    public class CartsRepository : BaseRepository<Cart>
    {
        public CartsRepository(EShopContext context) : base(context)
        {
        }
    }
}
