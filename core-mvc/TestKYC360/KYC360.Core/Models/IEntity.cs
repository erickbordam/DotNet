using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using KYC360.Commons.Models;

namespace KYC360.Core.Models
{
     public interface IEntity : IIdentifiable<string>
    {
        List<Address>? Addresses { get; set; }
        List<Date>? Dates { get; set; }
        bool Deceased { get; set; }
        string? Gender { get; set; }
        List<Name>? Names { get; set; }
    }
}