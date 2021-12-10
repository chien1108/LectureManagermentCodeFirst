using AutoMapper;
using LecturerManagement.Core.Models.Entities;
using LecturerManagement.DTOS.Account;
using LecturerManagement.DTOS.AdvancedLearning;
using LecturerManagement.DTOS.Class;
using LecturerManagement.DTOS.LecturerDTO;
using LecturerManagement.DTOS.StandardTime;
using LecturerManagement.DTOS.TrainingSystem;

namespace LecturerManagement.API
{
    public class AutoMapperProfile : Profile
    {
        public AutoMapperProfile()
        {
            CreateMap<AdvancedLearning, AddAdvancedLearningDto>().ReverseMap();
            CreateMap<AccountResgisterDto, Lecturer>().ReverseMap();
            CreateMap<Lecturer, GetLecturerDto>().ReverseMap();
            CreateMap<Account, GetAccountDto>().ReverseMap();
            CreateMap<Class, GetClassDto>().ReverseMap();
            CreateMap<AddClassDto, Class>().ReverseMap();
            CreateMap<TrainingSystem, GetTrainingSystemDto>().ReverseMap();
            CreateMap<AddStandardTimeDto, StandardTime>().ReverseMap();
            CreateMap<StandardTime, GetStandardTimeDto>().ReverseMap();
        }
    }
}
