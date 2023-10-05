﻿using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApplication_Backend.DTOs;
using WebApplication_Backend.Model;

namespace WebApplication_Backend.Repositories
{
    public class UserRepository : UserRepositoryI
    {
        private readonly MyDbContext context;

        public UserRepository(MyDbContext context) {
            this.context = context;
        }

        public User addUser(User newUser)
        {
             User user = context.Users.Add(newUser).Entity;
             context.SaveChanges();
             return user;
            
        }

        public List<User> GetAll()
        {
            return context.Users.Include(u => u.Address).ToList();
        }

        public User GetByUsername(string username)
        {
            return context.Users.Include(u => u.Address).FirstOrDefault(u => u.Username.Equals(username));
        }
    }
}
