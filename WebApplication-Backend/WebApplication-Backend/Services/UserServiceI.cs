using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApplication_Backend.DTOs;
using WebApplication_Backend.Model;

namespace WebApplication_Backend.Services
{
    public interface UserServiceI
    {
        public List<User> GetAll();
        public User GetByUsername(string username);
        public User addUser(NewUserDTO newUser);
    }
}
