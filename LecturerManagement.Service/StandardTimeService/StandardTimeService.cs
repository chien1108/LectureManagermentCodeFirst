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

        public async Task<ServiceResponse<AddStandardTimeDto>> Create(AddStandardTimeDto createStandardTime)
        {
            try
            {
                await _unitOfWork.StandardTimes.Create(_mapper.Map<StandardTime>(createStandardTime));
                if (await SaveChange())
                {
                    return new ServiceResponse<AddStandardTimeDto> { Success = true, Message = "Add Standard Time Success" };
                }
                else
                {
                    return new ServiceResponse<AddStandardTimeDto> { Success = false, Message = "Error when create new Standard Time" };
                }
            }
            catch (Exception ex)
            {
                return new ServiceResponse<AddStandardTimeDto> { Success = false, Message = ex.Message };
            }
        }

        public async Task<ServiceResponse<StandardTime>> Delete(StandardTime deleteStandardTime)
        {
            try
            {
                var standardTimeFromDB = await Find(x => x.Id == 1.ToString());
                if (standardTimeFromDB != null)
                {
                    _unitOfWork.StandardTimes.Delete(deleteStandardTime);
                    if (!await SaveChange())
                    {
                        return new ServiceResponse<StandardTime> { Success = false, Message = "Error when delete Standard Time" };
                    }
                    return new ServiceResponse<StandardTime> { Success = true, Message = "Delete Standard Time Success" };
                }
                else
                {
                    return new ServiceResponse<StandardTime> { Success = false, Message = "Not Found Standard Time" };
                }
            }
            catch (Exception ex)
            {
                return new ServiceResponse<StandardTime> { Success = false, Message = ex.Message };
            }
        }

        public async Task<GetStandardTimeDto> Find(Expression<Func<StandardTime, bool>> expression = null, List<string> includes = null)
        => _mapper.Map<GetStandardTimeDto>(await _unitOfWork.StandardTimes.FindByConditionAsync(expression, includes));

        public async Task<ICollection<GetStandardTimeDto>> FindAll(Expression<Func<StandardTime, bool>> expression = null, Func<IQueryable<StandardTime>, IOrderedQueryable<StandardTime>> orderBy = null, List<string> includes = null)
        => _mapper.Map<ICollection<GetStandardTimeDto>>(await _unitOfWork.StandardTimes.FindAllAsync(expression, orderBy, includes));

        public async Task<bool> IsExisted(Expression<Func<StandardTime, bool>> expression = null)
        {
            var isExist = await _unitOfWork.StandardTimes.FindByConditionAsync(expression);
            if (isExist == null)
            {
                return false;
            }
            return true;
        }

        public async Task<bool> SaveChange()
        => await _unitOfWork.StandardTimes.Save();

        public async Task<ServiceResponse<UpdateStandardTimeDto>> Update(UpdateStandardTimeDto updateStandardTime)
        {
            try
            {
                var standardTimeFromDB = await Find(x => x.Id == 1.ToString());
                if (standardTimeFromDB != null)
                {
                    var task = _mapper.Map<StandardTime>(updateStandardTime);
                    _unitOfWork.StandardTimes.Update(task);
                    if (!await SaveChange())
                    {
                        return new ServiceResponse<UpdateStandardTimeDto> { Success = false, Message = "Error when update Standard Time" };
                    }
                    return new ServiceResponse<UpdateStandardTimeDto> { Success = true, Message = "Update Standard Time Success" };
                }
                else
                {
                    return new ServiceResponse<UpdateStandardTimeDto> { Success = false, Message = "Not Found Standard Time" };
                }
            }
            catch (Exception ex)
            {
                return new ServiceResponse<UpdateStandardTimeDto> { Success = false, Message = ex.Message };
            }
        }
    }
}
