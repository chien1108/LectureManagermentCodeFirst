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

        public async Task<ServiceResponse<AddAdvancedLearningDto>> Create(AddAdvancedLearningDto createAdvancedLearning)
        {
            try
            {
                await _unitOfWork.AdvancedLearnings.Create(_mapper.Map<AdvancedLearning>(createAdvancedLearning));
                if (await SaveChange())
                {
                    return new ServiceResponse<AddAdvancedLearningDto> { Success = true, Message = "Add Advanced Learning Success" };
                }
                else
                {
                    return new ServiceResponse<AddAdvancedLearningDto> { Success = false, Message = "Error when create new Advanced Learning" };
                }
            }
            catch (Exception ex)
            {
                return new ServiceResponse<AddAdvancedLearningDto> { Success = false, Message = ex.Message };
            }
        }

        public async Task<ServiceResponse<AdvancedLearning>> Delete(AdvancedLearning deleteAdvancedLearning)
        {
            try
            {
                var deleteAdvanceLearningFromDB = await Find(x => x.Id == deleteAdvancedLearning.Id);
                if (deleteAdvanceLearningFromDB != null)
                {
                    _unitOfWork.AdvancedLearnings.Delete(deleteAdvancedLearning);
                    if (!await SaveChange())
                    {
                        return new ServiceResponse<AdvancedLearning> { Success = false, Message = "Error when delete Advanced Learning" };
                    }
                    return new ServiceResponse<AdvancedLearning> { Success = true, Message = "Delete Advanced Learning Success" };
                }
                else
                {
                    return new ServiceResponse<AdvancedLearning> { Success = false, Message = "Not Found Advanced Learning" };
                }
            }
            catch (Exception ex)
            {

                return new ServiceResponse<AdvancedLearning> { Success = false, Message = ex.Message };
            }
        }

        public async Task<GetAdvancedLearningDto> Find(Expression<Func<AdvancedLearning, bool>> expression = null, List<string> includes = null)
        => _mapper.Map<GetAdvancedLearningDto>(await _unitOfWork.AdvancedLearnings.FindByCondition(expression, includes));

        public async Task<ICollection<GetAdvancedLearningDto>> FindAll(Expression<Func<AdvancedLearning, bool>> expression = null, Func<IQueryable<AdvancedLearning>, IOrderedQueryable<AdvancedLearning>> orderBy = null, List<string> includes = null)
        => _mapper.Map<ICollection<GetAdvancedLearningDto>>(await _unitOfWork.AdvancedLearnings.GetAll(expression, orderBy, includes));

        public async Task<bool> IsExisted(Expression<Func<AdvancedLearning, bool>> expression = null)
        {
            var isExist = await _unitOfWork.AdvancedLearnings.FindByCondition(expression);
            if (isExist == null)
            {
                return false;
            }
            return true;
        }

        public async Task<bool> SaveChange()
             => await _unitOfWork.AdvancedLearnings.Save();

        public async Task<ServiceResponse<UpdateAdvancedLearningDto>> Update(UpdateAdvancedLearningDto updateAdvanceLearning)
        {
            try
            {
                var advanceLearningFromDB = await Find(x => x.Id == 1);
                if (advanceLearningFromDB != null)
                {
                    var task = _mapper.Map<AdvancedLearning>(updateAdvanceLearning);
                    _unitOfWork.AdvancedLearnings.Update(task);
                    if (!await SaveChange())
                    {
                        return new ServiceResponse<UpdateAdvancedLearningDto> { Success = false, Message = "Error when update Advanced Learning" };
                    }
                    return new ServiceResponse<UpdateAdvancedLearningDto> { Success = true, Message = "Update Advanced Learning Success" };
                }
                else
                {
                    return new ServiceResponse<UpdateAdvancedLearningDto> { Success = false, Message = "Not Found Advanced Learning" };
                }
            }
            catch (Exception ex)
            {
                return new ServiceResponse<UpdateAdvancedLearningDto> { Success = false, Message = ex.Message };
            }
        }
    }
}
