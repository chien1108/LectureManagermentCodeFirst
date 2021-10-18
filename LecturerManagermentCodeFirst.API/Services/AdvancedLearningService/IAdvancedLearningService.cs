using LecturerManagermentCodeFirst.DTO.DTOS.AdvancedLearning;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace LecturerManagermentCodeFirst.API.Services.AdvancedLearningService
{
    public interface IAdvancedLearningService
    {
        Task<ServiceResponse<GetAdvancedLearningDto>> GetAdvancedLearningById(int id);
        Task<ServiceResponse<IEnumerable<GetAdvancedLearningDto>>> GetAdvancedLearnings();
        Task<ServiceResponse<GetAdvancedLearningDto>> UpdateAdvancedLearning(UpdateAdvancedLearningDto update);
        Task<ServiceResponse<IEnumerable<GetAdvancedLearningDto>>> AddAdvancedLearning(AddAdvancedLearningDto add);
        Task<ServiceResponse<IEnumerable<GetAdvancedLearningDto>>> DeleteAdvancedLearning(int id);

    }
} 