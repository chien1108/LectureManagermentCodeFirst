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
        Task<ServiceResponse<AddLecturerScientificResearchDto>> Create(AddLecturerScientificResearchDto createLecturerScientificResearch);

        Task<ServiceResponse<LecturerScientificResearch>> Delete(LecturerScientificResearch deleteLecturerScientificResearch);
        Task<ServiceResponse<UpdateLecturerScientificResearchDto>> Update(UpdateLecturerScientificResearchDto updateLecturerScientificResearch);
        Task<bool> IsExisted(Expression<Func<LecturerScientificResearch, bool>> expression = null);
        Task<ICollection<GetLecturerScientificResearchDto>> FindAll(Expression<Func<LecturerScientificResearch,
                                bool>> expression = null,
                                Func<IQueryable<LecturerScientificResearch>,
                               IOrderedQueryable<LecturerScientificResearch>> orderBy = null,
                                List<string> includes = null);
        Task<GetLecturerScientificResearchDto> Find(Expression<Func<LecturerScientificResearch, bool>> expression = null, List<string> includes = null);
        Task<bool> SaveChange();
    }
}