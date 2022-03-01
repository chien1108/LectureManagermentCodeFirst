using AutoMapper;
using LecturerManagement.Core.Contracts;
using LecturerManagement.Core.Models;
using LecturerManagement.Core.Models.Entities;
using LecturerManagement.DTOS.Modules.Functions;
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

        public async Task<ServiceResponse<GetPositionDto>> AddPosition(AddPositionDto newPosition)
        {
            try
            {

                var checkIsExist = await _unitOfWork.Positions.FindByConditionAsync(x => x.Name.ToLower().Trim() == newPosition.Name.Trim().ToLower());
                if (checkIsExist == null)
                {
                    Position position = new()
                    {
                        Name = newPosition.Name,
                        Description = newPosition.Description,
                        DiscountPercent = newPosition.DiscountPercent,
                        Status = DTOS.Modules.Enums.Status.IsActive,
                        CreatedDate = DateTime.Now,
                    };

                    var listPositionFromDB = await _unitOfWork.Positions.FindAllAsync();
                    var length = listPositionFromDB.Count;

                    if (length == 0)
                    {
                        position.Id = "CV01";
                    }
                    else
                    {
                        position.Id = GenerateUniqueStringId.GenrateNewStringId(prefix: listPositionFromDB[length - 1].Id, numberFormatPrefix: 2, textFormatPrefix: 2);
                    }


                    await _unitOfWork.Positions.Create(position);


                    if (await SaveChange())
                    {
                        return new ServiceResponse<GetPositionDto> { Success = true, Message = "Add Position Success" };
                    }
                    else
                    {
                        return new ServiceResponse<GetPositionDto> { Success = false, Message = "Error when create new Position" };
                    }
                }
                else
                {
                    return new ServiceResponse<GetPositionDto>
                    {
                        Success = false,
                        Message = "Position Is Exist",
                        Data = _mapper.Map<GetPositionDto>(checkIsExist)
                    };
                }
            }
            catch (Exception ex)
            {
                return new ServiceResponse<GetPositionDto>
                {
                    Success = false,
                    Message = ex.Message
                };
            }
        }
        public async Task<ServiceResponse<GetPositionDto>> DeletePosition(Expression<Func<Position, bool>> expression = null)
        {
            try
            {
                var positionFromDb = await _unitOfWork.Positions.FindByConditionAsync(expression);
                _unitOfWork.Positions.Delete(positionFromDb);
                if (!await SaveChange())
                {
                    return new ServiceResponse<GetPositionDto> { Success = false, Message = "Error when delete Position" };
                }
                return new ServiceResponse<GetPositionDto> { Success = true, Message = "Delete Position Success" };

            }
            catch (Exception ex)
            {
                return new ServiceResponse<GetPositionDto> { Success = false, Message = ex.Message };
            }
        }
        public async Task<ServiceResponse<ICollection<GetPositionDto>>> GetAllPosition(Expression<Func<Position, bool>> expression = null, Func<IQueryable<Position>, IOrderedQueryable<Position>> orderBy = null, List<string> includes = null)
        {
            var listPositionFromDB = _mapper.Map<ICollection<GetPositionDto>>(await _unitOfWork.Positions.FindAllAsync(expression, orderBy, includes));
            if (listPositionFromDB != null)
            {
                return new() { Success = true, Message = "Get list Position Success", Data = listPositionFromDB };
            }
            return new() { Message = "List Position is not exist", Success = false };
        }

        public async Task<ServiceResponse<GetPositionDto>> GetPositionByCondition(Expression<Func<Position, bool>> expression = null, List<string> includes = null)
        {
            var positionFromDB = _mapper.Map<GetPositionDto>(await _unitOfWork.Positions.FindByConditionAsync(expression, includes));
            if (positionFromDB != null)
            {
                return new() { Success = true, Message = "Get list Position Success", Data = positionFromDB };
            }
            return new() { Message = "List Position is not exist", Success = false };
        }

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


        public async Task<ServiceResponse<GetPositionDto>> UpdatePosition(string id, UpdatePositionDto updatePosition)
        {
            try
            {
                var positionFromDb = await _unitOfWork.Positions.FindByConditionAsync(x => x.Id == id);

                positionFromDb.Name = updatePosition.Name;
                positionFromDb.Description = updatePosition.Description;
                positionFromDb.DiscountPercent = updatePosition.DiscountPercent;
                positionFromDb.ModifiedDate = DateTime.Now;
                _unitOfWork.Positions.Update(positionFromDb);
                if (!await SaveChange())
                {
                    return new ServiceResponse<GetPositionDto> { Success = false, Message = "Error when update Position" };
                }
                return new ServiceResponse<GetPositionDto> { Success = true, Message = "Update Position Success" };

            }
            catch (Exception ex)
            {
                return new ServiceResponse<GetPositionDto> { Success = false, Message = ex.Message };
            }
        }
    }
}
