using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;

namespace KYC360.Commons.Mapper
{
    public class GenericMapper<TDto, TEntity>
    {
        private readonly IMapper _mapper;

        public GenericMapper(IMapper mapper)
        {
            _mapper = mapper;
        }

        public TEntity MapToEntity(TDto dto)
        {
            return _mapper.Map<TEntity>(dto);
        }

        public TDto MapToDto(TEntity entity)
        {
            return _mapper.Map<TDto>(entity);
        }

        public IEnumerable<TEntity> MapToEntity(IEnumerable<TDto> dtos)
        {
            return _mapper.Map<IEnumerable<TEntity>>(dtos);
        }

        public IEnumerable<TDto> MapToDto(IEnumerable<TEntity> entities)
        {
            return _mapper.Map<IEnumerable<TDto>>(entities);
        }
    }
}