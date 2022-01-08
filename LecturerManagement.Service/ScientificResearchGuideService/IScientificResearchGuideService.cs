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
        Task<ServiceResponse<AddScientificResearchGuideDto>> Create(AddScientificResearchGuideDto createScientificResearchGuide);

        Task<ServiceResponse<ScientificResearchGuide>> Delete(ScientificResearchGuide deleteScientificResearchGuide);
        Task<ServiceResponse<UpdateScientificResearchGuideDto>> Update(UpdateScientificResearchGuideDto updateScientificResearchGuide);
        Task<bool> IsExisted(Expression<Func<ScientificResearchGuide, bool>> expression = null);
        Task<ICollection<GetScientificResearchGuideDto>> FindAll(Expression<Func<ScientificResearchGuide,
                                bool>> expression = null,
                                Func<IQueryable<ScientificResearchGuide>,
                               IOrderedQueryable<ScientificResearchGuide>> orderBy = null,
                                List<string> includes = null);
        Task<GetScientificResearchGuideDto> Find(Expression<Func<ScientificResearchGuide, bool>> expression = null, List<string> includes = null);
        Task<bool> SaveChange();
    }
}