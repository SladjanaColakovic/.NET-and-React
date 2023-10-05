using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApplication_Backend.Model;

namespace WebApplication_Backend.Services
{
    public interface AddressServiceI
    {
        public Address addAddress(Address address);
    }
}
