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
        Task<ServiceResponse<GetTeachingDto>> AddTeaching(AddTeachingDto createTeaching);

        Task<ServiceResponse<GetTeachingDto>> DeleteTeaching(Teaching deleteTeaching);
        Task<ServiceResponse<GetTeachingDto>> UpdateTeaching(UpdateTeachingDto updateTeaching);
        Task<bool> IsExisted(Expression<Func<Teaching, bool>> expression = null);
        Task<ServiceResponse<ICollection<GetTeachingDto>>> GetAllTeaching(Expression<Func<Teaching,
                                bool>> expression = null,
                                Func<IQueryable<Teaching>,
                               IOrderedQueryable<Teaching>> orderBy = null,
                                List<string> includes = null);
        Task<ServiceResponse<GetTeachingDto>> GetTeachingByCondition(Expression<Func<Teaching, bool>> expression = null, List<string> includes = null);
        Task<bool> SaveChange();
    }
}