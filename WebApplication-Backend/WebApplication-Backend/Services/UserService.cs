using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApplication_Backend.Model;
using WebApplication_Backend.Repositories;

namespace WebApplication_Backend.Services
{
    public class UserService : UserServiceI
    {

        private readonly UserRepositoryI userRepository;

        public UserService(UserRepositoryI userRepository) {
            this.userRepository = userRepository;
        }
        public List<User> GetAll()
        {
            return userRepository.GetAll();
        }

        public User GetByUsername(string username)
        {
            return userRepository.GetByUsername(username);
        }
    }
}
