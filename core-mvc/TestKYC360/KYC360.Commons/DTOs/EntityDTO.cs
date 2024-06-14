using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using KYC360.Commons.DTOs;
using KYC360.Commons.Models;

namespace KYC360.Commons.DTOs
{
    public class EntityDTO : IEntityDTO
    {
        public List<AddressDTO>? Addresses { get; set; }
        public List<DateDTO>? Dates { get; set ; }
        public bool Deceased { get ; set ; }
        public string? Gender { get ; set ; }
        public string Id { get; set; } = Guid.NewGuid().ToString();
        public List<NameDTO>? Names { get; set ; }

        public EntityDTO()
        {
            Addresses = new List<AddressDTO>();
            Dates = new List<DateDTO>();
            Names = new List<NameDTO>();
        }
    }
}