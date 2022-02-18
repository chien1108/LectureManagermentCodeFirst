using LecturerManagement.Core.Models;
using LecturerManagement.Core.Models.Entities;
using LecturerManagement.DTOS.Class;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace LecturerManagement.Services.ClassService
{
    public interface IClassService
    {
        //CRUD
        Task<ServiceResponse<GetClassDto>> AddNewClass(AddClassDto createClass);

        Task<ServiceResponse<GetClassDto>> DeleteClass(Class deleteClass);
        Task<ServiceResponse<GetClassDto>> UpdateClass(UpdateClassDto updateClass);
        Task<bool> IsExisted(Expression<Func<Class, bool>> expression = null);
        Task<ServiceResponse<ICollection<GetClassDto>>> GetAllClass(Expression<Func<Class,
                                bool>> expression = null,
                                Func<IQueryable<Class>,
                               IOrderedQueryable<Class>> orderBy = null,
                                List<string> includes = null);
        Task<ServiceResponse<GetClassDto>> GetClassByCondition(Expression<Func<Class, bool>> expression = null, List<string> includes = null);
        Task<bool> SaveChange();
    }
}