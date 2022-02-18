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
        Task<ServiceResponse<GetPositionDto>> AddPosition(AddPositionDto newPosition);

        Task<ServiceResponse<GetPositionDto>> DeletePosition(Position deletePosition);
        Task<ServiceResponse<GetPositionDto>> UpdatePosition(UpdatePositionDto updatePosition);
        Task<bool> IsExisted(Expression<Func<Position, bool>> expression = null);
        Task<ServiceResponse<ICollection<GetPositionDto>>> GetAllPosition(Expression<Func<Position,
                                bool>> expression = null,
                                Func<IQueryable<Position>,
                               IOrderedQueryable<Position>> orderBy = null,
                                List<string> includes = null);
        Task<ServiceResponse<GetPositionDto>> GetPositionByCondition(Expression<Func<Position, bool>> expression = null, List<string> includes = null);
        Task<bool> SaveChange();
    }
}