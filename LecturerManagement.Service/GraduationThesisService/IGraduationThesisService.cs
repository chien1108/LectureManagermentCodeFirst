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
        Task<ServiceResponse<AddGraduationThesisDto>> Create(AddGraduationThesisDto createGraduationThesis);

        Task<ServiceResponse<GraduationThesis>> Delete(GraduationThesis deleteGraduationThesis);
        Task<ServiceResponse<UpdateGraduationThesisDto>> Update(UpdateGraduationThesisDto updateGraduationThesis);
        Task<bool> IsExisted(Expression<Func<GraduationThesis, bool>> expression = null);
        Task<ICollection<GetGraduationThesisDto>> FindAll(Expression<Func<GraduationThesis,
                                bool>> expression = null,
                                Func<IQueryable<GraduationThesis>,
                               IOrderedQueryable<GraduationThesis>> orderBy = null,
                                List<string> includes = null);
        Task<GetGraduationThesisDto> Find(Expression<Func<GraduationThesis, bool>> expression = null, List<string> includes = null);
        Task<bool> SaveChange();
    }
}