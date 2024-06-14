using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace kyc360test.Models
{
    public interface IIdentifiable<TId>
    {
        TId Id { get; }
    }
}