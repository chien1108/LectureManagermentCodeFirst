using LecturerManagement.Core.Models;
using LecturerManagement.Core.Models.Entities;
using LecturerManagement.DTOS.SubjectDepartment;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace LecturerManagement.Services.SubjectDepartmentService
{
    public interface ISubjectDepartmentService
    {
        //CRUD
        Task<ServiceResponse<AddSubjectDepartmentDto>> Create(AddSubjectDepartmentDto createSubjectDepartment);

        Task<ServiceResponse<SubjectDepartment>> Delete(SubjectDepartment deleteSubjectDepartment);
        Task<ServiceResponse<UpdateSubjectDepartmentDto>> Update(UpdateSubjectDepartmentDto updateSubjectDepartment);
        Task<bool> IsExisted(Expression<Func<SubjectDepartment, bool>> expression = null);
        Task<ICollection<GetSubjectDepartmentDto>> FindAll(Expression<Func<SubjectDepartment,
                                bool>> expression = null,
                                Func<IQueryable<SubjectDepartment>,
                               IOrderedQueryable<SubjectDepartment>> orderBy = null,
                                List<string> includes = null);
        Task<GetSubjectDepartmentDto> Find(Expression<Func<SubjectDepartment, bool>> expression = null, List<string> includes = null);
        Task<bool> SaveChange();
    }
}