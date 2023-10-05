using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApplication_Backend.Model;

namespace WebApplication_Backend.Repositories
{
    public interface AddressRepositoryI
    {
        public Address addAddress(Address address);
    }
}
