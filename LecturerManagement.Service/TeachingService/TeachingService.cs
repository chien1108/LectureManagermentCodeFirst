using AutoMapper;
using LecturerManagement.Core.Contracts;
using LecturerManagement.Core.Models;
using LecturerManagement.Core.Models.Entities;
using LecturerManagement.DTOS.Teaching;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace LecturerManagement.Services.TeachingService
{
    public class TeachingService : ITeachingService
    {
        private readonly IMapper _mapper;
        private readonly IUnitOfWork _unitOfWork;
        public TeachingService(IMapper mapper, IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task<ServiceResponse<GetTeachingDto>> AddTeaching(AddTeachingDto createTeaching)
        {
            try
            {
                await _unitOfWork.Teachings.Create(_mapper.Map<Teaching>(createTeaching));
                if (await SaveChange())
                {
                    return new ServiceResponse<GetTeachingDto> { Success = true, Message = "Add Teaching Success" };
                }
                else
                {
                    return new ServiceResponse<GetTeachingDto> { Success = false, Message = "Error when create new Teaching" };
                }
            }
            catch (Exception ex)
            {
                return new ServiceResponse<GetTeachingDto> { Success = false, Message = ex.Message };
            }
        }

        public async Task<ServiceResponse<GetTeachingDto>> DeleteTeaching(Teaching deleteTeaching)
        {
            try
            {
                _unitOfWork.Teachings.Delete(deleteTeaching);
                if (!await SaveChange())
                {
                    return new ServiceResponse<GetTeachingDto> { Success = false, Message = "Error when delete Teaching" };
                }
                return new ServiceResponse<GetTeachingDto> { Success = true, Message = "Delete Teaching Success" };
            }
            catch (Exception ex)
            {
                return new ServiceResponse<GetTeachingDto> { Success = false, Message = ex.Message };
            }
        }

        public async Task<ServiceResponse<ICollection<GetTeachingDto>>> GetAllTeaching(Expression<Func<Teaching, bool>> expression = null, Func<IQueryable<Teaching>, IOrderedQueryable<Teaching>> orderBy = null, List<string> includes = null)
        {
            var listTeachingFromDb = _mapper.Map<ICollection<GetTeachingDto>>(await _unitOfWork.Teachings.FindAllAsync(expression, orderBy, includes));
            if (listTeachingFromDb != null)
            {
                return new() { Success = true, Message = "Get list Teaching Success", Data = listTeachingFromDb };
            }
            return new() { Message = "List Teaching is not exist", Success = false };
        }

        public async Task<ServiceResponse<GetTeachingDto>> GetTeachingByCondition(Expression<Func<Teaching, bool>> expression = null, List<string> includes = null)
        {
            var teachingFromDb = _mapper.Map<GetTeachingDto>(await _unitOfWork.Teachings.FindByConditionAsync(expression, includes));
            if (teachingFromDb != null)
            {
                return new() { Success = true, Message = "Get Teaching Success", Data = teachingFromDb };
            }
            return new() { Message = "Teaching is not exist", Success = false };
        }

        public async Task<bool> IsExisted(Expression<Func<Teaching, bool>> expression = null)
        {
            var isExist = await _unitOfWork.Teachings.FindByConditionAsync(expression);
            if (isExist == null)
            {
                return false;
            }
            return true;
        }

        public async Task<bool> SaveChange()
        => await _unitOfWork.Teachings.Save();
        public async Task<ServiceResponse<GetTeachingDto>> UpdateTeaching(UpdateTeachingDto updateTeaching)
        {
            try
            {
                var task = _mapper.Map<Teaching>(updateTeaching);
                _unitOfWork.Teachings.Update(task);
                if (!await SaveChange())
                {
                    return new ServiceResponse<GetTeachingDto> { Success = false, Message = "Error when update Teaching" };
                }
                return new ServiceResponse<GetTeachingDto> { Success = true, Message = "Update Teaching Success" };
            }
            catch (Exception ex)
            {
                return new ServiceResponse<GetTeachingDto> { Success = false, Message = ex.Message };
            }
        }
    }
}
