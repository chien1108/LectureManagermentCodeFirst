using LecturerManagement.Core.Models;
using LecturerManagement.Core.Models.Entities;
using LecturerManagement.DTOS.TrainingSystem;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace LecturerManagement.Services.TrainingSystemService
{
    public interface ITrainingSystemService
    {
        //CRUD
        Task<ServiceResponse<GetTrainingSystemDto>> AddTrainingSystem(AddTrainingSystemDto createTrainingSystem);

        Task<ServiceResponse<GetTrainingSystemDto>> DeleteTrainingSystem(TrainingSystem deleteTrainingSystem);
        Task<ServiceResponse<GetTrainingSystemDto>> UpdateTrainingSystem(UpdateTrainingSystemDto updateTrainingSystem);
        Task<bool> IsExisted(Expression<Func<TrainingSystem, bool>> expression = null);
        Task<ServiceResponse<ICollection<GetTrainingSystemDto>>> GetAllTrainingSystem(Expression<Func<TrainingSystem,
                                bool>> expression = null,
                                Func<IQueryable<TrainingSystem>,
                               IOrderedQueryable<TrainingSystem>> orderBy = null,
                                List<string> includes = null);
        Task<ServiceResponse<GetTrainingSystemDto>> GetTrainingSystemByCondition(Expression<Func<TrainingSystem, bool>> expression = null, List<string> includes = null);
        Task<bool> SaveChange();
    }
}