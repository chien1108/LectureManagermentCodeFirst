using AutoMapper;
using LecturerManagement.Core.Contracts;
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
    public class StandardTimeService : IStandardTimeService
    {
        private readonly IMapper _mapper;
        private readonly IUnitOfWork _unitOfWork;
        public StandardTimeService(IMapper mapper, IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task<ServiceResponse<GetStandardTimeDto>> AddStandardTime(AddStandardTimeDto createStandardTime)
        {
            try
            {
                await _unitOfWork.StandardTimes.Create(_mapper.Map<StandardTime>(createStandardTime));
                if (!await SaveChange())
                {
                    return new ServiceResponse<GetStandardTimeDto> { Success = false, Message = "Error when create new Standard Time" };

                }
                return new ServiceResponse<GetStandardTimeDto> { Success = true, Message = "Add Standard Time Success" };
            }
            catch (Exception ex)
            {
                return new ServiceResponse<GetStandardTimeDto> { Success = false, Message = ex.Message };
            }
        }

        public async Task<ServiceResponse<GetStandardTimeDto>> DeleteStandardTime(StandardTime deleteStandardTime)
        {
            try
            {
                _unitOfWork.StandardTimes.Delete(deleteStandardTime);
                if (!await SaveChange())
                {
                    return new ServiceResponse<GetStandardTimeDto> { Success = false, Message = "Error when delete Standard Time" };
                }
                return new ServiceResponse<GetStandardTimeDto> { Success = true, Message = "Delete Standard Time Success" };
            }
            catch (Exception ex)
            {
                return new ServiceResponse<GetStandardTimeDto> { Success = false, Message = ex.Message };
            }
        }

        public async Task<ServiceResponse<GetStandardTimeDto>> GetStandardTimeByCondition(Expression<Func<StandardTime, bool>> expression = null, List<string> includes = null)
        {
            var standardTime = _mapper.Map<GetStandardTimeDto>(await _unitOfWork.StandardTimes.FindByConditionAsync(expression, includes));

            if (standardTime != null)
            {
                return new() { Success = true, Message = "Get Standard Time Success", Data = standardTime };
            }

            return new() { Message = "Standard Time is not exist", Success = false };

        }

        public async Task<ServiceResponse<ICollection<GetStandardTimeDto>>> GetAllStandardTime(Expression<Func<StandardTime, bool>> expression = null,
                                                                            Func<IQueryable<StandardTime>, IOrderedQueryable<StandardTime>> orderBy = null,
                                                                            List<string> includes = null)
        {
            var standardTime = _mapper.Map<ICollection<GetStandardTimeDto>>(await _unitOfWork.StandardTimes.FindAllAsync(expression, orderBy, includes));

            if (standardTime != null)
            {
                return new() { Success = true, Message = "Get Standard Time Success", Data = standardTime };
            }
            return new() { Message = "Standard Time is not exist", Success = false };
        }


        public async Task<ServiceResponse<GetStandardTimeDto>> IsExisted(Expression<Func<StandardTime, bool>> expression = null)
        {
            var isExist = await _unitOfWork.StandardTimes.FindByConditionAsync(expression);
            if (isExist != null)
            {
                return new ServiceResponse<GetStandardTimeDto>() { Data = _mapper.Map<GetStandardTimeDto>(isExist), Success = true, Message = "Standard Time is exist" };
            }

            return new ServiceResponse<GetStandardTimeDto>() { Success = false, Message = "Standard Time is not exist" };
        }

        public async Task<bool> SaveChange()
        => await _unitOfWork.StandardTimes.Save();

        public async Task<ServiceResponse<GetStandardTimeDto>> UpdateStandardTime(UpdateStandardTimeDto updateStandardTime)
        {
            try
            {
                ////var standardTimeFromDB = await _unitOfWork.StandardTimes.FindByConditionAsync(x => x.Id == updateStandardTime.Id);
                ////if (standardTimeFromDB != null)
                ////{
                var task = _mapper.Map<StandardTime>(updateStandardTime);
                _unitOfWork.StandardTimes.Update(task);
                if (!await SaveChange())
                {
                    return new ServiceResponse<GetStandardTimeDto> { Success = false, Message = "Error when update Standard Time" };
                }
                return new ServiceResponse<GetStandardTimeDto> { Success = true, Message = "Update Standard Time Success" };
                ////}
                ////else
                ////{
                ////    return new ServiceResponse<GetStandardTimeDto> { Success = false, Message = "Not Found Standard Time" };
                ////}
            }
            catch (Exception ex)
            {
                return new ServiceResponse<GetStandardTimeDto> { Success = false, Message = ex.Message };
            }
        }

    }
}