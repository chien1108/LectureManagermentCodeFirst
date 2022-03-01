using AutoMapper;
using LecturerManagement.Core.Contracts;
using LecturerManagement.Core.Models;
using LecturerManagement.Core.Models.Entities;
using LecturerManagement.DTOS.Modules.Functions;
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
                var listFromDb = await _unitOfWork.StandardTimes.FindAllAsync();
                var length = listFromDb.Count;

                var standardTime = new StandardTime()
                {
                    Name = createStandardTime.Name,
                    CreatedDate = DateTime.Now,
                    Status = DTOS.Modules.Enums.Status.IsActive,
                    StandardHours = createStandardTime.StandardHours,
                    Description = createStandardTime.Description,
                };

                if (length != 0)
                {
                    standardTime.Id = GenerateUniqueStringId.GenrateNewStringId(prefix: listFromDb[length - 1].Id, textFormatPrefix: 2, numberFormatPrefix: 2);
                }
                else
                {
                    standardTime.Id = "CD01";
                }


                await _unitOfWork.StandardTimes.Create(standardTime);
                if (!await SaveChange())
                {
                    return new ServiceResponse<GetStandardTimeDto> { Success = false, Message = "Error when create new Standard Time" };

                }
                return new ServiceResponse<GetStandardTimeDto> { Success = true, Message = "Add Standard Time Success" };
            }
            catch (Exception ex)
            {
                return new ServiceResponse<GetStandardTimeDto> { Success = false, Message = ex.StackTrace };
            }
        }

        public async Task<ServiceResponse<GetStandardTimeDto>> DeleteStandardTime(Expression<Func<StandardTime, bool>> expression = null)
        {
            try
            {
                var standardTimeFromDb = await _unitOfWork.StandardTimes.FindByConditionAsync(expression);
                _unitOfWork.StandardTimes.Delete(standardTimeFromDb);
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

        public async Task<ServiceResponse<GetStandardTimeDto>> UpdateStandardTime(UpdateStandardTimeDto updateStandardTime, Expression<Func<StandardTime, bool>> expression = null)
        {
            try
            {
                var standardTimeFromDB = await _unitOfWork.StandardTimes.FindByConditionAsync(expression);
                standardTimeFromDB.ModifiedDate = DateTime.Now;
                standardTimeFromDB.Name = updateStandardTime.Name;
                standardTimeFromDB.Description = updateStandardTime.Description;
                standardTimeFromDB.StandardHours = updateStandardTime.StandardHours;
                _unitOfWork.StandardTimes.Update(standardTimeFromDB);
                if (!await SaveChange())
                {
                    return new ServiceResponse<GetStandardTimeDto> { Success = false, Message = "Error when update Standard Time" };
                }
                return new ServiceResponse<GetStandardTimeDto> { Success = true, Message = "Update Standard Time Success" };
            }
            catch (Exception ex)
            {
                return new ServiceResponse<GetStandardTimeDto> { Success = false, Message = ex.Message };
            }
        }

    }
}