using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace kyc360test.Models
{
    public class Entity : IEntity
    {
        public List<Address>? Addresses { get; set; }
        public List<Date>? Dates { get; set ; }
        public bool Deceased { get ; set ; }
        public string? Gender { get ; set ; }
        public string Id { get; set; }
        public List<Name>? Names { get; set ; }
    }
}