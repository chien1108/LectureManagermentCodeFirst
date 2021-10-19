using AutoMapper;
using LecturerManagermentCodeFirst.API.Entities;
using LecturerManagermentCodeFirst.DTO.DTOS.Account;
using LecturerManagermentCodeFirst.DTO.DTOS.AdvancedLearning;
using LecturerManagermentCodeFirst.DTO.DTOS.Class;
using LecturerManagermentCodeFirst.DTO.DTOS.Lecturer;
using LecturerManagermentCodeFirst.DTO.DTOS.StandardTime;
using LecturerManagermentCodeFirst.DTO.DTOS.TrainingSystem;

namespace LecturerManagermentCodeFirst.API
{
    public class AutoMapperProfile :Profile
    {
        public AutoMapperProfile()
        {
            CreateMap<AdvancedLearning, AddAdvancedLearningDto>();
            CreateMap<AddAdvancedLearningDto, AdvancedLearning>();
            CreateMap<AccountResgisterDto, Lecturer>();
            CreateMap<Lecturer, GetLecturerDto>();
            CreateMap<Account, GetAccountDto>();
            CreateMap<Class, GetClassDto>();
            CreateMap<AddClassDto, Class>();
            CreateMap<TrainingSystem, GetTrainingSystemDto>();
            CreateMap<AddStandardTimeDto, StandardTime>();
            CreateMap<StandardTime, GetStandardTimeDto>();
        }
    }
}
