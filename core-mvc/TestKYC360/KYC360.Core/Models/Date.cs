using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using KYC360.Commons.Models;

namespace KYC360.Core.Models
{
    public class Date: IIdentifiable<int>
    {

        public int Id { get ; set ; }
        public string? DateType { get; set; }
        public DateTime? DateVal { get; set; }
    }
}