using LecturerManagermentCodeFirst.API.Entities;
using LecturerManagermentCodeFirst.DTO.DTOS.StandardTime;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace LecturerManagermentCodeFirst.API.Services.StandardTimeService
{
    public interface IStandardTimeService
    {
        Task<ServiceResponse<IEnumerable<GetStandardTimeDto>>> GetStandardTimes();
        Task<ServiceResponse<GetStandardTimeDto>> GetStandardTimeByName(string name);
        Task<ServiceResponse<IEnumerable<GetStandardTimeDto>>> AddStandardTime(AddStandardTimeDto add);
        Task<ServiceResponse<GetStandardTimeDto>> UpdateStandardTime(UpdateStandardTimeDto update);
        Task<ServiceResponse<IEnumerable<GetStandardTimeDto>>> DeleteStandardTime(string name);
    }
}