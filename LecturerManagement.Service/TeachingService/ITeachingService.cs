using LecturerManagement.Core.Models;
using LecturerManagement.Core.Models.Entities;
using LecturerManagement.DTOS.Teaching;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace LecturerManagement.Services.TeachingService
{
    public interface ITeachingService
    {
        //CRUD
        Task<ServiceResponse<AddTeachingDto>> Create(AddTeachingDto createTeaching);

        Task<ServiceResponse<Teaching>> Delete(Teaching deleteTeaching);
        Task<ServiceResponse<UpdateTeachingDto>> Update(UpdateTeachingDto updateTeaching);
        Task<bool> IsExisted(Expression<Func<Teaching, bool>> expression = null);
        Task<ICollection<GetTeachingDto>> FindAll(Expression<Func<Teaching,
                                bool>> expression = null,
                                Func<IQueryable<Teaching>,
                               IOrderedQueryable<Teaching>> orderBy = null,
                                List<string> includes = null);
        Task<GetTeachingDto> Find(Expression<Func<Teaching, bool>> expression = null, List<string> includes = null);
        Task<bool> SaveChange();
    }
}