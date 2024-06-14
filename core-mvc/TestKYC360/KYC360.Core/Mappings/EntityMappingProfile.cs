using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using KYC360.Commons.DTOs;
using KYC360.Core.Models;

namespace KYC360.Core.Mappings
{
    public class EntityMappingProfile : Profile
    {
        public EntityMappingProfile()
        {
            CreateMap<Entity, EntityDTO>().ReverseMap();
            CreateMap<Address, AddressDTO>().ReverseMap();
            CreateMap<Date, DateDTO>().ReverseMap();
            CreateMap<Name, NameDTO>().ReverseMap();
        }
    }
}