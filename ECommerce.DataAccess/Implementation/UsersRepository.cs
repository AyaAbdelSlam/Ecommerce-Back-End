using ECommerce.DataAccess.Abstraction;
using ECommerce.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace ECommerce.DataAccess.Implementation
{
    public class UsersRepository : BaseRepository<User>
    {
        public UsersRepository(EShopContext context) :base(context)
        {

        }
    }
}
