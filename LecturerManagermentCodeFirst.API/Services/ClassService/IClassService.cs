using LecturerManagermentCodeFirst.DTO.DTOS.Class;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace LecturerManagermentCodeFirst.API.Services.ClassService
{
    public interface IClassService
    {
        Task<ServiceResponse<List<GetClassDto>>> GetClasses();
        Task<ServiceResponse<GetClassDto>> GetClassById(string Id);
        Task<ServiceResponse<List<GetClassDto>>> AddClass(AddClassDto addClass);
        Task<ServiceResponse<GetClassDto>> UpdateClass(UpdateClassDto updateClass);
        Task<ServiceResponse<List<GetClassDto>>> DeleteClass(string Id);
    }
}