using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApplication_Backend.Model;
using WebApplication_Backend.Repositories;

namespace WebApplication_Backend.Services
{
    public class AddressService : AddressServiceI
    {
        private readonly AddressRepositoryI addressRepository;

        public AddressService(AddressRepositoryI addressRepository) {
            this.addressRepository = addressRepository;
        }
        public Address addAddress(Address address)
        {
            return addressRepository.addAddress(address);
        }
    }
}
