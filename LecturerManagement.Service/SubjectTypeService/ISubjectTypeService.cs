using LecturerManagement.Core.Models;
using LecturerManagement.Core.Models.Entities;
using LecturerManagement.DTOS.SubjectType;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace LecturerManagement.Services.SubjectTypeService
{
    public interface ISubjectTypeService
    {
        //CRUD
        Task<ServiceResponse<AddSubjectTypeDto>> Create(AddSubjectTypeDto createSubjectType);

        Task<ServiceResponse<SubjectType>> Delete(SubjectType deleteSubjectType);
        Task<ServiceResponse<UpdateSubjectTypeDto>> Update(UpdateSubjectTypeDto updateSubjectType);
        Task<bool> IsExisted(Expression<Func<SubjectType, bool>> expression = null);
        Task<ICollection<GetSubjectTypeDto>> FindAll(Expression<Func<SubjectType,
                                bool>> expression = null,
                                Func<IQueryable<SubjectType>,
                               IOrderedQueryable<SubjectType>> orderBy = null,
                                List<string> includes = null);
        Task<GetSubjectTypeDto> Find(Expression<Func<SubjectType, bool>> expression = null, List<string> includes = null);
        Task<bool> SaveChange();
    }
}