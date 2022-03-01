using LecturerManagement.Core.Models;
using LecturerManagement.Core.Models.Entities;
using LecturerManagement.DTOS.ScientificResearchGuide;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace LecturerManagement.Services.ScientificResearchGuideService
{
    public interface IScientificResearchGuideService
    {
        //CRUD
        Task<ServiceResponse<GetScientificResearchGuideDto>> AddScientificResearchGuide(AddScientificResearchGuideDto newScientificResearchGuide);

        Task<ServiceResponse<GetScientificResearchGuideDto>> DeleteScientificResearchGuide(ScientificResearchGuide deleteScientificResearchGuide);
        Task<ServiceResponse<GetScientificResearchGuideDto>> UpdateScientificResearchGuide(UpdateScientificResearchGuideDto updateScientificResearchGuide, Expression<Func<ScientificResearchGuide, bool>> expression = null);
        Task<bool> IsExisted(Expression<Func<ScientificResearchGuide, bool>> expression = null);
        Task<ServiceResponse<ICollection<GetScientificResearchGuideDto>>> GetAllScientificResearchGuide(Expression<Func<ScientificResearchGuide,
                                bool>> expression = null,
                                Func<IQueryable<ScientificResearchGuide>,
                               IOrderedQueryable<ScientificResearchGuide>> orderBy = null,
                                List<string> includes = null);
        Task<ServiceResponse<GetScientificResearchGuideDto>> GetScientificResearchGuideByCondition(Expression<Func<ScientificResearchGuide, bool>> expression = null, List<string> includes = null);
        Task<bool> SaveChange();
    }
}