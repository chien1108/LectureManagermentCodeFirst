using AutoMapper;
using LecturerManagement.Core.Contracts;
using LecturerManagement.Core.Models;
using LecturerManagement.Core.Models.Entities;
using LecturerManagement.DTOS.SubjectType;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace LecturerManagement.Services.SubjectTypeService
{
    public class SubjectTypeService : ISubjectTypeService
    {
        private readonly IMapper _mapper;
        private readonly IUnitOfWork _unitOfWork;
        public SubjectTypeService(IMapper mapper, IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task<ServiceResponse<GetSubjectTypeDto>> AddSubjectType(AddSubjectTypeDto createSubjectType)
        {
            try
            {
                await _unitOfWork.SubjectTypes.Create(_mapper.Map<SubjectType>(createSubjectType));
                if (await SaveChange())
                {
                    return new ServiceResponse<GetSubjectTypeDto> { Success = true, Message = "Add Subject Type Success" };
                }
                else
                {
                    return new ServiceResponse<GetSubjectTypeDto> { Success = false, Message = "Error when create new Subject Type" };
                }
            }
            catch (Exception ex)
            {
                return new ServiceResponse<GetSubjectTypeDto> { Success = false, Message = ex.StackTrace };
            }
        }
        public async Task<ServiceResponse<GetSubjectTypeDto>> DeleteSubjectType(Expression<Func<SubjectType, bool>> expression = null)
        {
            try
            {
                var subjectTypeFromDB = await _unitOfWork.SubjectTypes.FindByConditionAsync(expression);
                _unitOfWork.SubjectTypes.Delete(subjectTypeFromDB);
                if (!await SaveChange())
                {
                    return new ServiceResponse<GetSubjectTypeDto> { Success = false, Message = "Error when delete Subject Type" };
                }
                return new ServiceResponse<GetSubjectTypeDto> { Success = true, Message = "Delete Subject Type Success" };
            }
            catch (Exception ex)
            {
                return new ServiceResponse<GetSubjectTypeDto> { Success = false, Message = ex.StackTrace };
            }
        }

        public async Task<ServiceResponse<ICollection<GetSubjectTypeDto>>> GetAllSubjectType(Expression<Func<SubjectType, bool>> expression = null, Func<IQueryable<SubjectType>, IOrderedQueryable<SubjectType>> orderBy = null, List<string> includes = null)
        {
            var listSubjectTypeFromDb = _mapper.Map<ICollection<GetSubjectTypeDto>>(await _unitOfWork.SubjectTypes.FindAllAsync(expression, orderBy, includes));
            if (listSubjectTypeFromDb != null)
            {
                return new() { Success = true, Message = "Get list Subject Type Success", Data = listSubjectTypeFromDb };
            }
            return new() { Message = "List Subject Type is not exist", Success = false };
        }

        public async Task<ServiceResponse<GetSubjectTypeDto>> GetSubjectTypeByCondition(Expression<Func<SubjectType, bool>> expression = null, List<string> includes = null)
        {
            var subjectTypeFromDb = _mapper.Map<GetSubjectTypeDto>(await _unitOfWork.SubjectTypes.FindByConditionAsync(expression, includes));
            if (subjectTypeFromDb != null)
            {
                return new() { Success = true, Message = "Get Subject Type Success", Data = subjectTypeFromDb };
            }
            return new() { Message = "Subject Type is not exist", Success = false };
        }

        public async Task<bool> IsExisted(Expression<Func<SubjectType, bool>> expression = null)
        {
            var isExist = await _unitOfWork.SubjectTypes.FindByConditionAsync(expression);
            if (isExist == null)
            {
                return false;
            }
            return true;
        }

        public async Task<bool> SaveChange()
        => await _unitOfWork.SubjectTypes.Save();
        public async Task<ServiceResponse<GetSubjectTypeDto>> UpdateSubjectType(UpdateSubjectTypeDto updateSubjectType, Expression<Func<SubjectType, bool>> expression = null)
        {
            try
            {
                var subjectTypeFromDb = await _unitOfWork.SubjectTypes.FindByConditionAsync(expression);
                subjectTypeFromDb.Name = updateSubjectType.Name;
                subjectTypeFromDb.Description = updateSubjectType.Description;
                subjectTypeFromDb.ModifiedDate = DateTime.Now;
                _unitOfWork.SubjectTypes.Update(subjectTypeFromDb);
                if (!await SaveChange())
                {
                    return new ServiceResponse<GetSubjectTypeDto> { Success = false, Message = "Error when update Subject Type" };
                }
                return new ServiceResponse<GetSubjectTypeDto> { Success = true, Message = "Update Subject Type Success" };
            }
            catch (Exception ex)
            {
                return new ServiceResponse<GetSubjectTypeDto> { Success = false, Message = ex.StackTrace };
            }
        }
    }
}
