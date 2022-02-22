using AutoMapper;
using LecturerManagement.Core.Contracts;
using LecturerManagement.Core.Models;
using LecturerManagement.Core.Models.Entities;
using LecturerManagement.DTOS.AdvancedLearning;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace LecturerManagement.Services.AdvancedLearningService
{
    public class AdvancedLearningService : IAdvancedLearningService
    {
        private readonly IMapper _mapper;
        private readonly IUnitOfWork _unitOfWork;


        public AdvancedLearningService(IMapper mapper, IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task<ServiceResponse<GetAdvancedLearningDto>> AddAdvancedLearning(AddAdvancedLearningDto createAdvancedLearning)
        {
            try
            {
                await _unitOfWork.AdvancedLearnings.Create(_mapper.Map<AdvancedLearning>(createAdvancedLearning));

                if (!await SaveChange())
                {
                    return new ServiceResponse<GetAdvancedLearningDto> { Success = false, Message = "Error when create new Advanced Learning" };

                }
                return new ServiceResponse<GetAdvancedLearningDto> { Success = true, Message = "Add Advanced Learning Success" };
            }
            catch (Exception ex)
            {
                return new ServiceResponse<GetAdvancedLearningDto> { Success = false, Message = ex.StackTrace };
            }
        }

        public async Task<ServiceResponse<ICollection<GetAdvancedLearningDto>>> DeleteAdvancedLearning(AdvancedLearning deletedAdvancedLearning)
        {
            try
            {
                _unitOfWork.AdvancedLearnings.Delete(deletedAdvancedLearning);
                if (!await SaveChange())
                {
                    return new ServiceResponse<ICollection<GetAdvancedLearningDto>> { Success = false, Message = "Error when delete Advanced Learning" };
                }
                return new ServiceResponse<ICollection<GetAdvancedLearningDto>> { Success = true, Message = "Delete Advanced Learning Success" };
            }
            catch (Exception ex)
            {
                return new ServiceResponse<ICollection<GetAdvancedLearningDto>> { Success = false, Message = ex.Message };
            }

        }


        public async Task<ServiceResponse<GetAdvancedLearningDto>> GetAdvancedLearningByCondition(Expression<Func<AdvancedLearning, bool>> expression = null, List<string> includes = null)
        {
            var dbAdvancedLearning = _mapper.Map<GetAdvancedLearningDto>(await _unitOfWork.AdvancedLearnings.FindByConditionAsync(expression, includes));
            if (dbAdvancedLearning != null)
            {
                return new() { Success = true, Message = "Get Advanced Learning from DB Success", Data = dbAdvancedLearning };
            }

            return new() { Message = "Advanced Learning is not exist", Success = false };
        }


        public async Task<ServiceResponse<ICollection<GetAdvancedLearningDto>>> GetAllAdvancedLearning(Expression<Func<AdvancedLearning, bool>> expression = null, Func<IQueryable<AdvancedLearning>, IOrderedQueryable<AdvancedLearning>> orderBy = null, List<string> includes = null)
        {
            var dbAdvancedLearning = _mapper.Map<ICollection<GetAdvancedLearningDto>>(await _unitOfWork.AdvancedLearnings.FindAllAsync(expression, orderBy, includes));

            if (dbAdvancedLearning != null)
            {
                return new() { Success = true, Message = "Get list Advanced Learning Success", Data = dbAdvancedLearning };
            }
            return new() { Message = "lits Advanced Learninge is not availble", Success = false };
        }


        public async Task<ServiceResponse<GetAdvancedLearningDto>> IsExisted(Expression<Func<AdvancedLearning, bool>> expression = null)
        {
            var isExist = _mapper.Map<GetAdvancedLearningDto>(await _unitOfWork.AdvancedLearnings.FindByConditionAsync(expression));
            if (isExist != null)
            {
                return new ServiceResponse<GetAdvancedLearningDto>() { Data = isExist, Success = true, Message = "Advanced Learning is Exist" };
            }
            return new ServiceResponse<GetAdvancedLearningDto>() { Success = false, Message = "Advanced Learning is not exist" };
        }

        public async Task<bool> SaveChange()
             => await _unitOfWork.AdvancedLearnings.Save();

        public async Task<ServiceResponse<GetAdvancedLearningDto>> UpdateAdvancedLearning(UpdateAdvancedLearningDto updateAdvanceLearning)
        {
            try
            {
                var advanceLearningFromDB = await GetAdvancedLearningByCondition(x => x.Id == updateAdvanceLearning.Id);
                if (advanceLearningFromDB.Data != null)
                {
                    var task = _mapper.Map<AdvancedLearning>(updateAdvanceLearning);
                    _unitOfWork.AdvancedLearnings.Update(task);
                    if (!await SaveChange())
                    {
                        return new ServiceResponse<GetAdvancedLearningDto> { Success = false, Message = "Error when update Advanced Learning" };
                    }
                    return new ServiceResponse<GetAdvancedLearningDto> { Data = _mapper.Map<GetAdvancedLearningDto>(updateAdvanceLearning), Success = true, Message = "Update Advanced Learning Success" };
                }
                else
                {
                    return new ServiceResponse<GetAdvancedLearningDto> { Success = false, Message = "Not Found Advanced Learning" };
                }
            }
            catch (Exception ex)
            {
                return new ServiceResponse<GetAdvancedLearningDto> { Success = false, Message = ex.Message };
            }
        }
    }
}
