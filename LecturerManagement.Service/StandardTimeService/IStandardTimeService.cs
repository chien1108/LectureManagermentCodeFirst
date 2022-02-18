using LecturerManagement.Core.Models;
using LecturerManagement.Core.Models.Entities;
using LecturerManagement.DTOS.StandardTime;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace LecturerManagement.Services.StandardTimeService
{
    public interface IStandardTimeService
    {
        //CRUD
        Task<ServiceResponse<GetStandardTimeDto>> AddStandardTime(AddStandardTimeDto createStandardTime);

        Task<ServiceResponse<GetStandardTimeDto>> DeleteStandardTime(StandardTime deleteStandardTime);
        Task<ServiceResponse<GetStandardTimeDto>> UpdateStandardTime(UpdateStandardTimeDto updateStandardTime);
        Task<ServiceResponse<GetStandardTimeDto>> IsExisted(Expression<Func<StandardTime, bool>> expression = null);
        Task<ServiceResponse<ICollection<GetStandardTimeDto>>> GetAllStandardTime(Expression<Func<StandardTime,
                                bool>> expression = null,
                                Func<IQueryable<StandardTime>,
                               IOrderedQueryable<StandardTime>> orderBy = null,
                                List<string> includes = null);
        Task<ServiceResponse<GetStandardTimeDto>> GetStandardTimeByCondition(Expression<Func<StandardTime, bool>> expression = null, List<string> includes = null);
        Task<bool> SaveChange();
    }
}