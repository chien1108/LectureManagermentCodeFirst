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
        Task<ServiceResponse<GetSubjectTypeDto>> AddSubjectType(AddSubjectTypeDto createSubjectType);

        Task<ServiceResponse<GetSubjectTypeDto>> DeleteSubjectType(SubjectType deleteSubjectType);
        Task<ServiceResponse<GetSubjectTypeDto>> UpdateSubjectType(UpdateSubjectTypeDto updateSubjectType);
        Task<bool> IsExisted(Expression<Func<SubjectType, bool>> expression = null);
        Task<ServiceResponse<ICollection<GetSubjectTypeDto>>> GetAllSubjectType(Expression<Func<SubjectType,
                                bool>> expression = null,
                                Func<IQueryable<SubjectType>,
                               IOrderedQueryable<SubjectType>> orderBy = null,
                                List<string> includes = null);
        Task<ServiceResponse<GetSubjectTypeDto>> GetSubjectTypeByCondition(Expression<Func<SubjectType, bool>> expression = null, List<string> includes = null);
        Task<bool> SaveChange();
    }
}