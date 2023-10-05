using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApplication_Backend.Model;

namespace WebApplication_Backend.Repositories
{
    public class AddressRepository : AddressRepositoryI
    {
        private readonly MyDbContext context;

        public AddressRepository(MyDbContext context) {
            this.context = context;
        }
        public Address addAddress(Address address)
        {
            Address result = context.Addresses.Add(address).Entity;
            context.SaveChanges();
            return result;
        }
    }
}
