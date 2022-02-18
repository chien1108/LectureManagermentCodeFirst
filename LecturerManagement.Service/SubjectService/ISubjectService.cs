using LecturerManagement.Core.Models;
using LecturerManagement.Core.Models.Entities;
using LecturerManagement.DTOS.Subject;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace LecturerManagement.Services.SubjectService
{
    public interface ISubjectService
    {
        //CRUD
        Task<ServiceResponse<GetSubjectDto>> AddSubject(AddSubjectDto createSubject);

        Task<ServiceResponse<GetSubjectDto>> DeleteSubject(Subject deleteSubject);
        Task<ServiceResponse<GetSubjectDto>> UpdateSubject(UpdateSubjectDto updateSubject);
        Task<bool> IsExisted(Expression<Func<Subject, bool>> expression = null);
        Task<ServiceResponse<ICollection<GetSubjectDto>>> GetAllSubject(Expression<Func<Subject,
                                bool>> expression = null,
                                Func<IQueryable<Subject>,
                               IOrderedQueryable<Subject>> orderBy = null,
                                List<string> includes = null);
        Task<ServiceResponse<GetSubjectDto>> GetSubjectByCondition(Expression<Func<Subject, bool>> expression = null, List<string> includes = null);
        Task<bool> SaveChange();
    }
}