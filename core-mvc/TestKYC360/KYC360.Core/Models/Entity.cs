using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using KYC360.Commons.Models;

namespace KYC360.Core.Models
{
    public class Entity : IEntity
    {
        public List<Address>? Addresses { get; set; }
        public List<Date>? Dates { get; set ; }
        public bool Deceased { get ; set ; }
        public string? Gender { get ; set ; }
        public string Id { get; set; } = Guid.NewGuid().ToString();
        public List<Name>? Names { get; set ; }

        public Entity()
        {
            Addresses = new List<Address>();
            Dates = new List<Date>();
            Names = new List<Name>();
        }
    }
}