using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebApplication_Backend.Model
{
    public class MyDbContext : DbContext
    {
        public MyDbContext(DbContextOptions<MyDbContext> options) : base(options) { }

        public DbSet<User> Users { get; set; }
        public DbSet<Address> Addresses { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Address>().HasData(
                new Address { Id = 1, City = "Novi Sad", Country = "Srbija", Street = "Zmaj Jovina 1", Users = new List<User>()},
                new Address { Id = 2, City = "Beograd", Country = "Srbija", Street = "Dunavksa 3", Users = new List<User>() }

            );
            modelBuilder.Entity<User>().HasData(
                new User { Id = 1, Name = "Ana", Surname = "Bogdanovic", Email = "ana@gmail.com", Password = "123", Role = "Seller", Username = "ana", AddressId = 1 },
                new User { Id = 2, Name = "Luka", Surname = "Lukic", Email = "luka@gmail.com", Password = "123", Role = "Admin", Username = "luka", AddressId = 2 }
            );
        }
    }
}
