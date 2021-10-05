using AutoMapper;
using LecturerManagermentCodeFirst.API.Entities;
using LecturerManagermentCodeFirst.DTO.DTOS.AdvancedLearning;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LecturerManagermentCodeFirst.API
{
    public class AutoMapperProfile : Profile
    {
        public AutoMapperProfile()
        {
            CreateMap<AdvancedLearning, GetAdvancedLearningDto>();
            CreateMap<AddAdvancedLearningDto, AdvancedLearning>();
        }
    }
}
