using LecturerManagermentCodeFirst.DTO.DTOS.Lecturer;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace LecturerManagermentCodeFirst.API.Services.LecturerService
{
    public interface ILecturerService
    {
        Task<ServiceResponse<List<GetLecturerDto>>> GetLecturers();
        Task<ServiceResponse<GetLecturerDto>> GetLecturerById(int id);
        Task<ServiceResponse<IEnumerable<GetLecturerDto>>> AddLecturer(AddLecturerDto add);
        Task<ServiceResponse<GetLecturerDto>> UpdateLecturer(UpdateLecturerDto update);
        Task<ServiceResponse<IEnumerable<GetLecturerDto>>> DeleteLecturer(int id);
    }
}