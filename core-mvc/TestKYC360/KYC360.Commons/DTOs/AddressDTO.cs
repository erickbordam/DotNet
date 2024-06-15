using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using KYC360.Commons.Models;

namespace KYC360.Commons.DTOs
{
    public class AddressDTO : IIdentifiable<int>
    {
        
        public int Id { get ; set ; }
        public int? AddressLine { get; set; }
        public String? AddressLineDesc { get; set; }
        public int? City { get; set; }
        public String? CityName { get; set; }
        public int? Country { get; set; }
        public String? CountryName { get; set; }
    }
}