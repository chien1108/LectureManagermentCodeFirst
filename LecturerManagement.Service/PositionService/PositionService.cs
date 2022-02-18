﻿using AutoMapper;
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

        public async Task<ServiceResponse<GetPositionDto>> AddPosition(AddPositionDto newPosition)
        {
            try
            {
                await _unitOfWork.Positions.Create(_mapper.Map<Position>(newPosition));
                if (await SaveChange())
                {
                    return new ServiceResponse<GetPositionDto> { Success = true, Message = "Add Position Success" };
                }
                else
                {
                    return new ServiceResponse<GetPositionDto> { Success = false, Message = "Error when create new Position" };
                }
            }
            catch (Exception ex)
            {
                return new ServiceResponse<GetPositionDto> { Success = false, Message = ex.Message };
            }
        }
        public async Task<ServiceResponse<GetPositionDto>> DeletePosition(Position deletePosition)
        {
            try
            {
                _unitOfWork.Positions.Delete(deletePosition);
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


        public async Task<ServiceResponse<GetPositionDto>> UpdatePosition(UpdatePositionDto updatePosition)
        {
            try
            {

                var task = _mapper.Map<Position>(updatePosition);
                _unitOfWork.Positions.Update(task);
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