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
        Task<ServiceResponse<AddClassDto>> Create(AddClassDto createClass);

        Task<ServiceResponse<Class>> Delete(Class deleteClass);
        Task<ServiceResponse<UpdateClassDto>> Update(UpdateClassDto updateClass);
        Task<bool> IsExisted(Expression<Func<Class, bool>> expression = null);
        Task<ICollection<GetClassDto>> FindAll(Expression<Func<Class,
                                bool>> expression = null,
                                Func<IQueryable<Class>,
                               IOrderedQueryable<Class>> orderBy = null,
                                List<string> includes = null);
        Task<GetClassDto> Find(Expression<Func<Class, bool>> expression = null, List<string> includes = null);
        Task<bool> SaveChange();
    }
}