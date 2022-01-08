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
        Task<ServiceResponse<AddTrainingSystemDto>> Create(AddTrainingSystemDto createTrainingSystem);

        Task<ServiceResponse<TrainingSystem>> Delete(TrainingSystem deleteTrainingSystem);
        Task<ServiceResponse<UpdateTrainingSystemDto>> Update(UpdateTrainingSystemDto updateTrainingSystem);
        Task<bool> IsExisted(Expression<Func<TrainingSystem, bool>> expression = null);
        Task<ICollection<GetTrainingSystemDto>> FindAll(Expression<Func<TrainingSystem,
                                bool>> expression = null,
                                Func<IQueryable<TrainingSystem>,
                               IOrderedQueryable<TrainingSystem>> orderBy = null,
                                List<string> includes = null);
        Task<GetTrainingSystemDto> Find(Expression<Func<TrainingSystem, bool>> expression = null, List<string> includes = null);
        Task<bool> SaveChange();
    }
}