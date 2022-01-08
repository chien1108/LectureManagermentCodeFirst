using LecturerManagement.Core.Models;
using LecturerManagement.Core.Models.Entities;
using LecturerManagement.DTOS.Position;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace LecturerManagement.Services.PositionService
{
    public interface IPositionService
    {
        //CRUD
        Task<ServiceResponse<AddPositionDto>> Create(AddPositionDto createPosition);

        Task<ServiceResponse<Position>> Delete(Position deletePosition);
        Task<ServiceResponse<UpdatePositionDto>> Update(UpdatePositionDto updatePosition);
        Task<bool> IsExisted(Expression<Func<Position, bool>> expression = null);
        Task<ICollection<GetPositionDto>> FindAll(Expression<Func<Position,
                                bool>> expression = null,
                                Func<IQueryable<Position>,
                               IOrderedQueryable<Position>> orderBy = null,
                                List<string> includes = null);
        Task<GetPositionDto> Find(Expression<Func<Position, bool>> expression = null, List<string> includes = null);
        Task<bool> SaveChange();
    }
}