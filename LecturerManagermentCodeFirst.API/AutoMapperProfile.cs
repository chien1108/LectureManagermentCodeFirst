using AutoMapper;
using LecturerManagermentCodeFirst.API.Entities;
using LecturerManagermentCodeFirst.DTO.DTOS.Account;
using LecturerManagermentCodeFirst.DTO.DTOS.AdvancedLearning;
using LecturerManagermentCodeFirst.DTO.DTOS.Lecturer;

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
        }
    }
}
