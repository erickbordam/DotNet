using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace KYC360.Commons.Models
{
    public interface IIdentifiable<TId>
    {
        TId Id { get; }
    }
}