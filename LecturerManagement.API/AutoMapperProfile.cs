using AutoMapper;
using LecturerManagement.Core.Models.Entities;
using LecturerManagement.DTOS.Account;
using LecturerManagement.DTOS.AdvancedLearning;
using LecturerManagement.DTOS.Class;
using LecturerManagement.DTOS.GraduationThesis;
using LecturerManagement.DTOS.LecturerDTO;
using LecturerManagement.DTOS.MachineRoom;
using LecturerManagement.DTOS.Position;
using LecturerManagement.DTOS.ScientificResearchGuide;
using LecturerManagement.DTOS.StandardTime;
using LecturerManagement.DTOS.Subject;
using LecturerManagement.DTOS.SubjectDepartment;
using LecturerManagement.DTOS.SubjectType;
using LecturerManagement.DTOS.Teaching;
using LecturerManagement.DTOS.TrainingSystem;

namespace LecturerManagement.API
{
    public class AutoMapperProfile : Profile
    {
        public AutoMapperProfile()
        {
            // Account
            ////CreateMap<AccountResgisterDto, Lecturer>().ReverseMap();
            CreateMap<Account, GetAccountDto>().ReverseMap();


            //AdvancedLearning
            CreateMap<AdvancedLearning, AddAdvancedLearningDto>().ReverseMap();
            CreateMap<AdvancedLearning, UpdateAdvancedLearningDto>().ReverseMap();
            CreateMap<GetAdvancedLearningDto, AddAdvancedLearningDto>().ReverseMap();
            CreateMap<GetAdvancedLearningDto, UpdateAdvancedLearningDto>().ReverseMap();

            //Class
            CreateMap<Class, GetClassDto>().ReverseMap();
            CreateMap<AddClassDto, Class>().ReverseMap();

            //GraduationThesis
            CreateMap<GraduationThesis, GetGraduationThesisDto>().ReverseMap();

            //LecturerScien
            CreateMap<LecturerScientificResearch, GetLecturerDto>().ReverseMap();

            //Lecturer
            CreateMap<Lecturer, GetLecturerDto>().ReverseMap();

            //MachineRoom
            CreateMap<MachineRoom, GetMachineRoomDto>().ReverseMap();
            CreateMap<MachineRoom, UpdateMachineRoomDto>().ReverseMap();

            //Position
            CreateMap<Position, GetPositionDto>().ReverseMap();
            CreateMap<Position, UpdatePositionDto>().ReverseMap();

            //ScientificResarch
            CreateMap<ScientificResearchGuide, GetScientificResearchGuideDto>().ReverseMap();

            //StandardTime
            CreateMap<AddStandardTimeDto, StandardTime>().ReverseMap();
            CreateMap<StandardTime, GetStandardTimeDto>().ReverseMap();
            CreateMap<UpdateStandardTimeDto, GetStandardTimeDto>().ReverseMap();

            //SubjectDepartment
            CreateMap<SubjectDepartment, GetSubjectDepartmentDto>().ReverseMap();


            //Subject
            CreateMap<Subject, GetSubjectDto>().ReverseMap();

            //SubjectType
            CreateMap<SubjectType, GetSubjectTypeDto>().ReverseMap();

            //Teaching
            CreateMap<Teaching, GetTeachingDto>().ReverseMap();

            //TranningSystem
            CreateMap<TrainingSystem, GetTrainingSystemDto>().ReverseMap();
        }
    }
}