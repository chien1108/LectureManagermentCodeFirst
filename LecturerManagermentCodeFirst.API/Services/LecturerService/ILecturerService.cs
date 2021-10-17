using LecturerManagermentCodeFirst.DTO.DTOS.Lecturer;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace LecturerManagermentCodeFirst.API.Services.LecturerService
{
    public interface ILecturerService
    {
        Task<ServiceResponse<List<GetLecturerDto>>> GetLecturers();

    }
}