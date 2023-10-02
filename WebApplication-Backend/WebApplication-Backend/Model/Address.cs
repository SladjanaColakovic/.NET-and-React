﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebApplication_Backend.Model
{
    public class Address
    {
        public long Id { get; set; }
        public string City { get; set; }
        public string Country { get; set; }
        public string Street { get; set; }
        public virtual List<User> Users { get; set; }

    }
}
