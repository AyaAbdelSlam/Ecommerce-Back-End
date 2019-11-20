using ECommerce.Entities;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace ECommerce.Core.Abstractions
{
    public interface IUsersService
    {
        Task<IEnumerable<User>> GetAllUsers();

        Task<User> GetUser(int id);

        Task UpdateUser(User user);

        Task<IEnumerable<Cart>> GetUserCarts(int userId); 
        
    }
}
