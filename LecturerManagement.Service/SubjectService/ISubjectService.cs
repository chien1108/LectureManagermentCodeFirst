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
        Task<ServiceResponse<AddSubjectDto>> Create(AddSubjectDto createSubject);

        Task<ServiceResponse<Subject>> Delete(Subject deleteSubject);
        Task<ServiceResponse<UpdateSubjectDto>> Update(UpdateSubjectDto updateSubject);
        Task<bool> IsExisted(Expression<Func<Subject, bool>> expression = null);
        Task<ICollection<GetSubjectDto>> FindAll(Expression<Func<Subject,
                                bool>> expression = null,
                                Func<IQueryable<Subject>,
                               IOrderedQueryable<Subject>> orderBy = null,
                                List<string> includes = null);
        Task<GetSubjectDto> Find(Expression<Func<Subject, bool>> expression = null, List<string> includes = null);
        Task<bool> SaveChange();
    }
}