using LecturerManagement.Core.Models;
using LecturerManagement.Core.Models.Entities;
using LecturerManagement.DTOS.AdvancedLearning;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace LecturerManagement.Services.AdvancedLearningService
{
    public interface IAdvancedLearningService
    {
        //CRUD
        Task<ServiceResponse<GetAdvancedLearningDto>> AddAdvancedLearning(AddAdvancedLearningDto createAdvancedLearning);

        Task<ServiceResponse<ICollection<GetAdvancedLearningDto>>> DeleteAdvancedLearning(Expression<Func<AdvancedLearning, bool>> expression = null);
        Task<ServiceResponse<GetAdvancedLearningDto>> UpdateAdvancedLearning(UpdateAdvancedLearningDto updateAdvanceLearning, Expression<Func<AdvancedLearning, bool>> expression = null);
        Task<ServiceResponse<GetAdvancedLearningDto>> IsExisted(Expression<Func<AdvancedLearning, bool>> expression = null);
        Task<ServiceResponse<ICollection<GetAdvancedLearningDto>>> GetAllAdvancedLearning(Expression<Func<AdvancedLearning,
                                bool>> expression = null,
                                Func<IQueryable<AdvancedLearning>,
                               IOrderedQueryable<AdvancedLearning>> orderBy = null,
                                List<string> includes = null);
        Task<ServiceResponse<GetAdvancedLearningDto>> GetAdvancedLearningByCondition(Expression<Func<AdvancedLearning, bool>> expression = null, List<string> includes = null);
        Task<bool> SaveChange();
    }
}