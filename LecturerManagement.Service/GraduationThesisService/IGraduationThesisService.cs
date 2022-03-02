using LecturerManagement.Core.Models;
using LecturerManagement.Core.Models.Entities;
using LecturerManagement.DTOS.GraduationThesis;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace LecturerManagement.Services.GraduationThesisService
{
    public interface IGraduationThesisService
    {
        //CRUD
        Task<ServiceResponse<GetGraduationThesisDto>> AddGraduationThesis(AddGraduationThesisDto newGraduationThesis);

        Task<ServiceResponse<GetGraduationThesisDto>> DeleteGraduationThesis(Expression<Func<GraduationThesis, bool>> expression = null);
        Task<ServiceResponse<GetGraduationThesisDto>> UpdateGraduationThesis(UpdateGraduationThesisDto updateGraduationThesis, Expression<Func<GraduationThesis, bool>> expression = null);
        Task<bool> IsExisted(Expression<Func<GraduationThesis, bool>> expression = null);
        Task<ServiceResponse<IEnumerable<GetGraduationThesisDto>>> GetAllGraduationThesis(Expression<Func<GraduationThesis,
                                bool>> expression = null,
                                Func<IQueryable<GraduationThesis>,
                               IOrderedQueryable<GraduationThesis>> orderBy = null,
                                List<string> includes = null);
        Task<ServiceResponse<GetGraduationThesisDto>> GetGraduationThesisByCondition(Expression<Func<GraduationThesis, bool>> expression = null, List<string> includes = null);
        Task<bool> SaveChange();
    }
}