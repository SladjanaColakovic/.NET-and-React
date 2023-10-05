using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApplication_Backend.DTOs;
using WebApplication_Backend.Model;

namespace WebApplication_Backend.Repositories
{
    public interface UserRepositoryI
    {
        public List<User> GetAll();
        public User GetByUsername(string username);

        public User addUser(User newUser);


    }
}
