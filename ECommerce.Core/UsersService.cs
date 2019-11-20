using ECommerce.Core.Abstractions;
using ECommerce.DataAccess.Abstraction;
using ECommerce.Entities;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace ECommerce.Core
{
    public class UsersService : IUsersService
    {
        private readonly IRepository<User> _usersRepository;
        private readonly IRepository<Cart> _cartsRepository;

        public UsersService(IRepository<User> repo, IRepository<Cart> cartRepo)
        {
            _usersRepository = repo;
            _cartsRepository = cartRepo;
        }
        public Task<IEnumerable<User>> GetAllUsers()
        {
            return _usersRepository.GetAll();
        }

        public Task<User> GetUser(int id)
        {
            return _usersRepository.GetById(id);
        }

        public Task UpdateUser(User user)
        {
            return _usersRepository.Update(user);
        }

        public Task<IEnumerable<Cart>> GetUserCarts(int userId)
        {
            return _cartsRepository.GetWhere(c => c.UserId == userId);
        }
    }
}
