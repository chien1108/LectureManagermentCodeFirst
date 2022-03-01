using LecturerManagement.Core.Models;
using LecturerManagement.Core.Models.Entities;
using LecturerManagement.DTOS.LecturerScientificResearch;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace LecturerManagement.Services.LecturerScientificResearchService
{
    public interface ILecturerScientificResearchService
    {
        //CRUD
        Task<ServiceResponse<GetLecturerScientificResearchDto>> AddLecturerScientificResearch(AddLecturerScientificResearchDto newLecturerScientificResearch);

        Task<ServiceResponse<GetLecturerScientificResearchDto>> DeleteLecturerScientificResearch(LecturerScientificResearch deleteLecturerScientificResearch);
        Task<ServiceResponse<GetLecturerScientificResearchDto>> UpdateLecturerScientificResearch(UpdateLecturerScientificResearchDto updatedLecturerScientificResearch, Expression<Func<LecturerScientificResearch, bool>> expression = null);
        Task<bool> IsExisted(Expression<Func<LecturerScientificResearch, bool>> expression = null);
        Task<ServiceResponse<ICollection<GetLecturerScientificResearchDto>>> GetAllLecturerScientificResearch(Expression<Func<LecturerScientificResearch,
                                bool>> expression = null,
                                Func<IQueryable<LecturerScientificResearch>,
                               IOrderedQueryable<LecturerScientificResearch>> orderBy = null,
                                List<string> includes = null);
        Task<ServiceResponse<GetLecturerScientificResearchDto>> GetLecturerScientificResearchByCondition(Expression<Func<LecturerScientificResearch, bool>> expression = null, List<string> includes = null);
        Task<bool> SaveChange();
    }
}