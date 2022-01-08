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
        Task<ServiceResponse<AddStandardTimeDto>> Create(AddStandardTimeDto createStandardTime);

        Task<ServiceResponse<StandardTime>> Delete(StandardTime deleteStandardTime);
        Task<ServiceResponse<UpdateStandardTimeDto>> Update(UpdateStandardTimeDto updateStandardTime);
        Task<bool> IsExisted(Expression<Func<StandardTime, bool>> expression = null);
        Task<ICollection<GetStandardTimeDto>> FindAll(Expression<Func<StandardTime,
                                bool>> expression = null,
                                Func<IQueryable<StandardTime>,
                               IOrderedQueryable<StandardTime>> orderBy = null,
                                List<string> includes = null);
        Task<GetStandardTimeDto> Find(Expression<Func<StandardTime, bool>> expression = null, List<string> includes = null);
        Task<bool> SaveChange();
    }
}