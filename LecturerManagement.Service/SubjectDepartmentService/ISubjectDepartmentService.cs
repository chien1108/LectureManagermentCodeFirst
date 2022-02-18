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
        Task<ServiceResponse<GetSubjectDepartmentDto>> AddSubjectDepartment(AddSubjectDepartmentDto createSubjectDepartment);

        Task<ServiceResponse<GetSubjectDepartmentDto>> DeleteSubjectDepartment(SubjectDepartment deleteSubjectDepartment);
        Task<ServiceResponse<GetSubjectDepartmentDto>> UpdateSubjectDepartment(UpdateSubjectDepartmentDto updateSubjectDepartment);
        Task<bool> IsExisted(Expression<Func<SubjectDepartment, bool>> expression = null);
        Task<ServiceResponse<ICollection<GetSubjectDepartmentDto>>> GetAllSubjectDepartment(Expression<Func<SubjectDepartment,
                                bool>> expression = null,
                                Func<IQueryable<SubjectDepartment>,
                               IOrderedQueryable<SubjectDepartment>> orderBy = null,
                                List<string> includes = null);
        Task<ServiceResponse<GetSubjectDepartmentDto>> GetSubjectDepartmentByCondition(Expression<Func<SubjectDepartment, bool>> expression = null, List<string> includes = null);
        Task<bool> SaveChange();
    }
}