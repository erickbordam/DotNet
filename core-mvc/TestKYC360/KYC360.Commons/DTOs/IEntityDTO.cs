using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using KYC360.Commons.Models;

namespace KYC360.Commons.DTOs
{
    public interface IEntityDTO : IIdentifiable<string>
    {
        List<AddressDTO>? Addresses { get; set; }
        List<DateDTO>? Dates { get; set; }
        bool Deceased { get; set; }
        string? Gender { get; set; }
        List<NameDTO>? Names { get; set; }
    }
}