using AutoMapper;
using KnowIt.Domain.DTO;
using KnowIt.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace KnowIt.Domain.Mappings
{
    public class DtoToModelProfile : Profile
    {
        public DtoToModelProfile()
        {
            CreateMap<EventDetail, EventDetailDto>().ReverseMap();
            CreateMap<EventDetailDto, EventDetail>().ReverseMap();
        }
    }
}
