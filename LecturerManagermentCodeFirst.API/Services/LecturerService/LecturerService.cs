using LecturerManagermentCodeFirst.DTO.DTOS.Lecturer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LecturerManagermentCodeFirst.API.Services.LecturerService
{
    public class LecturerService : ILecturerService
    {
        public Task<ServiceResponse<List<GetLecturerDto>>> GetLecturers()
        {
            throw new NotImplementedException();
        }
    }
}
