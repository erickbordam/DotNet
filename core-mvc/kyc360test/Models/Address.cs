using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace kyc360test.Models
{
    public class Address : IIdentifiable<int>
    {
        
        public int Id { get ; set ; }

        public int? AddressLine { get; set; }
        public int? City { get; set; }

        public int? Country { get; set; }
    }
}