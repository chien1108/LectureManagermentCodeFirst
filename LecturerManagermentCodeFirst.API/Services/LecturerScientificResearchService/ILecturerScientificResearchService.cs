using LecturerManagermentCodeFirst.DTO.DTOS.LecturerScientificResearch;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace LecturerManagermentCodeFirst.API.Services.LecturerScientificResearchService
{
    public interface ILecturerScientificResearchService
    {
        Task<ServiceResponse<IEnumerable<GetLecturerScientificResearchDto>>> GetLecturerScientificResearchs();
        Task<ServiceResponse<GetLecturerScientificResearchDto>> GetLecturerScientificResearchById(int id);
        Task<ServiceResponse<IEnumerable<GetLecturerScientificResearchDto>>> AddLecturerScientificResearch(AddLecturerScientificResearchDto add);
        Task<ServiceResponse<GetLecturerScientificResearchDto>> UpdateLecturerScientificResearch(UpdateLecturerScientificResearchDto update);
        Task<ServiceResponse<IEnumerable<GetLecturerScientificResearchDto>>> DeleteLecturerScientificResearch(int id);
    }
}