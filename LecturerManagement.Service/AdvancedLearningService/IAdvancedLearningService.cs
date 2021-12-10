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
        Task<ServiceResponse<AddAdvancedLearningDto>> Create(AddAdvancedLearningDto createAdvancedLearning);

        Task<ServiceResponse<AdvancedLearning>> Delete(AdvancedLearning deleteAdvancedLearning);
        Task<ServiceResponse<UpdateAdvancedLearningDto>> Update(UpdateAdvancedLearningDto updateAdvanceLearning);
        Task<bool> IsExisted(Expression<Func<AdvancedLearning, bool>> expression = null);
        Task<ICollection<GetAdvancedLearningDto>> FindAll(Expression<Func<AdvancedLearning,
                                bool>> expression = null,
                                Func<IQueryable<AdvancedLearning>,
                               IOrderedQueryable<AdvancedLearning>> orderBy = null,
                                List<string> includes = null);
        Task<GetAdvancedLearningDto> Find(Expression<Func<AdvancedLearning, bool>> expression = null, List<string> includes = null);
        Task<bool> SaveChange();
    }
}