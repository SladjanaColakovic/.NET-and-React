using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApplication_Backend.DTOs;
using WebApplication_Backend.Model;
using WebApplication_Backend.Repositories;

namespace WebApplication_Backend.Services
{
    public class UserService : UserServiceI
    {

        private readonly UserRepositoryI userRepository;
        private readonly AddressServiceI addressService;

        public UserService(UserRepositoryI userRepository, AddressServiceI addressService) {
            this.userRepository = userRepository;
            this.addressService = addressService;     
        }

        public User AddUser(NewUserDTO newUser)
        {
            Address address = new Address
            {
                Street = newUser.Street,
                City = newUser.City,
                Country = newUser.Country,
            };
            Address savedAddress = addressService.addAddress(address);
            User user = new User { Name = newUser.Name,
                    Surname = newUser.Surname,
                    Username = newUser.Username,
                    Password = newUser.Password,
                    Email = newUser.Email,
                    Role = newUser.Role,
                    AddressId = savedAddress.Id,
                    Address = savedAddress
            
            };
            return userRepository.AddUser(user);
        }

        public void Delete(long id)
        {
            userRepository.Delete(id);
        }

        public User EditUser(EditUserDTO editUser)
        {
            return userRepository.EditUser(editUser);
        }

        public List<User> GetAll()
        {
            return userRepository.GetAll();
        }

        public User GetById(long id)
        {
            return userRepository.GetById(id);
        }

        public User GetByUsername(string username)
        {
            return userRepository.GetByUsername(username);
        }
    }
}
