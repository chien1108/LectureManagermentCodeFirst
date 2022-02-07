using AutoMapper;
using LecturerManagement.Core.Contracts;
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
    public class PositionService : IPositionService
    {
        private readonly IMapper _mapper;
        private readonly IUnitOfWork _unitOfWork;
        public PositionService(IMapper mapper, IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task<ServiceResponse<AddPositionDto>> Create(AddPositionDto createPosition)
        {
            try
            {
                await _unitOfWork.Positions.Create(_mapper.Map<Position>(createPosition));
                if (await SaveChange())
                {
                    return new ServiceResponse<AddPositionDto> { Success = true, Message = "Add Position Success" };
                }
                else
                {
                    return new ServiceResponse<AddPositionDto> { Success = false, Message = "Error when create new Position" };
                }
            }
            catch (Exception ex)
            {
                return new ServiceResponse<AddPositionDto> { Success = false, Message = ex.Message };
            }
        }

        public async Task<ServiceResponse<Position>> Delete(Position deletePosition)
        {
            try
            {
                var positionFromDB = await Find(x => x.Id == 1.ToString());
                if (positionFromDB != null)
                {
                    _unitOfWork.Positions.Delete(deletePosition);
                    if (!await SaveChange())
                    {
                        return new ServiceResponse<Position> { Success = false, Message = "Error when delete Position" };
                    }
                    return new ServiceResponse<Position> { Success = true, Message = "Delete Position Success" };
                }
                else
                {
                    return new ServiceResponse<Position> { Success = false, Message = "Not Found Position" };
                }
            }
            catch (Exception ex)
            {
                return new ServiceResponse<Position> { Success = false, Message = ex.Message };
            }
        }

        public async Task<GetPositionDto> Find(Expression<Func<Position, bool>> expression = null, List<string> includes = null)
        => _mapper.Map<GetPositionDto>(await _unitOfWork.Positions.FindByConditionAsync(expression, includes));

        public async Task<ICollection<GetPositionDto>> FindAll(Expression<Func<Position, bool>> expression = null, Func<IQueryable<Position>, IOrderedQueryable<Position>> orderBy = null, List<string> includes = null)
        => _mapper.Map<ICollection<GetPositionDto>>(await _unitOfWork.Positions.FindAllAsync(expression, orderBy, includes));

        public async Task<bool> IsExisted(Expression<Func<Position, bool>> expression = null)
        {
            var isExist = await _unitOfWork.Positions.FindByConditionAsync(expression);
            if (isExist == null)
            {
                return false;
            }
            return true;
        }

        public async Task<bool> SaveChange()
        => await _unitOfWork.Positions.Save();

        public async Task<ServiceResponse<UpdatePositionDto>> Update(UpdatePositionDto updatePosition)
        {
            try
            {
                var positionFromDB = await Find(x => x.Id == 1.ToString());
                if (positionFromDB != null)
                {
                    var task = _mapper.Map<Position>(updatePosition);
                    _unitOfWork.Positions.Update(task);
                    if (!await SaveChange())
                    {
                        return new ServiceResponse<UpdatePositionDto> { Success = false, Message = "Error when update Position" };
                    }
                    return new ServiceResponse<UpdatePositionDto> { Success = true, Message = "Update Position Success" };
                }
                else
                {
                    return new ServiceResponse<UpdatePositionDto> { Success = false, Message = "Not Found Position" };
                }
            }
            catch (Exception ex)
            {
                return new ServiceResponse<UpdatePositionDto> { Success = false, Message = ex.Message };
            }
        }
    }
}
