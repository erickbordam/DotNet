using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace kyc360test.Models
{
    public class Name : IIdentifiable<int>
    {
        public int Id { get ; set ; }
        public string? FirstName { get; set; }
        public string? MiddleName { get; set; }
        public string? Surname { get; set; }
    }
}