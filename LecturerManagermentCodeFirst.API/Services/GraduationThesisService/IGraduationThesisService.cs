using LecturerManagermentCodeFirst.API.Entities;
using LecturerManagermentCodeFirst.DTO.DTOS.GraduationThesis;
using System.Collections;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace LecturerManagermentCodeFirst.API.Services.GraduationThesisService
{
    public interface IGraduationThesisService
    {
        Task<ServiceResponse<IEnumerable<GetGraduationThesisDto>>> GetGraduationThesises();
        Task<ServiceResponse<GetGraduationThesisDto>> GetGraduationThesisById(int id);
        Task<ServiceResponse<IEnumerable<GetGraduationThesisDto>>> AddGraduationThesis(AddGraduationThesisDto add);
        Task<ServiceResponse<GetGraduationThesisDto>> UpdateGraduationThesis(UpdateGraduationThesisDto update);
        Task<ServiceResponse<IEnumerable<GetGraduationThesisDto>>> DeleteGraduationThesis(int id);
     }
}