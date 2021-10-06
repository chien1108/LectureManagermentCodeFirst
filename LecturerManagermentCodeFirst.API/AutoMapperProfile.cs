using AutoMapper;
using LecturerManagermentCodeFirst.API.Entities;
using LecturerManagermentCodeFirst.DTO.DTOS.AdvancedLearning;

namespace LecturerManagermentCodeFirst.API
{
    public class AutoMapperProfile :Profile
    {
        public AutoMapperProfile()
        {
            CreateMap<AdvancedLearning, AddAdvancedLearningDto>();
            CreateMap<AddAdvancedLearningDto, AdvancedLearning>();
        }
    }
}
