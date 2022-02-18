using AutoMapper;
using LecturerManagement.Core.Contracts;
using LecturerManagement.Core.Models;
using LecturerManagement.Core.Models.Entities;
using LecturerManagement.DTOS.SubjectDepartment;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace LecturerManagement.Services.SubjectDepartmentService
{
    public class SubjectDepartmentService : ISubjectDepartmentService
    {
        private readonly IMapper _mapper;
        private readonly IUnitOfWork _unitOfWork;
        public SubjectDepartmentService(IMapper mapper, IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task<ServiceResponse<GetSubjectDepartmentDto>> AddSubjectDepartment(AddSubjectDepartmentDto createSubjectDepartment)
        {
            try
            {
                await _unitOfWork.SubjectDepartments.Create(_mapper.Map<SubjectDepartment>(createSubjectDepartment));
                if (await SaveChange())
                {
                    return new ServiceResponse<GetSubjectDepartmentDto> { Success = true, Message = "Add Subject Department Success" };
                }
                else
                {
                    return new ServiceResponse<GetSubjectDepartmentDto> { Success = false, Message = "Error when create new Subject Department" };
                }
            }
            catch (Exception ex)
            {
                return new ServiceResponse<GetSubjectDepartmentDto> { Success = false, Message = ex.Message };
            }
        }
        public async Task<ServiceResponse<SubjectDepartment>> Delete(SubjectDepartment deleteSubjectDepartment)
        {
            try
            {
                var subjectDepartmentFromDB = await Find(x => x.Id == 1.ToString());
                if (subjectDepartmentFromDB != null)
                {
                    _unitOfWork.SubjectDepartments.Delete(deleteSubjectDepartment);
                    if (!await SaveChange())
                    {
                        return new ServiceResponse<SubjectDepartment> { Success = false, Message = "Error when delete Subject Department" };
                    }
                    return new ServiceResponse<SubjectDepartment> { Success = true, Message = "Delete Subject Department Success" };
                }
                else
                {
                    return new ServiceResponse<SubjectDepartment> { Success = false, Message = "Not Found Subject Department" };
                }
            }
            catch (Exception ex)
            {
                return new ServiceResponse<SubjectDepartment> { Success = false, Message = ex.Message };
            }
        }

        public async Task<ServiceResponse<GetSubjectDepartmentDto>> DeleteSubjectDepartment(SubjectDepartment deleteSubjectDepartment)
        {
            try
            {
                _unitOfWork.SubjectDepartments.Delete(deleteSubjectDepartment);
                if (!await SaveChange())
                {
                    return new ServiceResponse<GetSubjectDepartmentDto> { Success = false, Message = "Error when delete Subject Department" };
                }
                return new ServiceResponse<GetSubjectDepartmentDto> { Success = true, Message = "Delete Subject Department Success" };
            }
            catch (Exception ex)
            {
                return new ServiceResponse<GetSubjectDepartmentDto> { Success = false, Message = ex.Message };
            }
        }

        public async Task<GetSubjectDepartmentDto> Find(Expression<Func<SubjectDepartment, bool>> expression = null, List<string> includes = null)
         => _mapper.Map<GetSubjectDepartmentDto>(await _unitOfWork.SubjectDepartments.FindByConditionAsync(expression, includes));

        public async Task<ICollection<GetSubjectDepartmentDto>> FindAll(Expression<Func<SubjectDepartment, bool>> expression = null, Func<IQueryable<SubjectDepartment>, IOrderedQueryable<SubjectDepartment>> orderBy = null, List<string> includes = null)
        => _mapper.Map<ICollection<GetSubjectDepartmentDto>>(await _unitOfWork.SubjectDepartments.FindAllAsync(expression, orderBy, includes));

        public async Task<ServiceResponse<ICollection<GetSubjectDepartmentDto>>> GetAllSubjectDepartment(Expression<Func<SubjectDepartment, bool>> expression = null, Func<IQueryable<SubjectDepartment>, IOrderedQueryable<SubjectDepartment>> orderBy = null, List<string> includes = null)
        {
            var listSubjectDepartmentFromDB = _mapper.Map<ICollection<GetSubjectDepartmentDto>>(await _unitOfWork.SubjectDepartments.FindAllAsync(expression, orderBy, includes));

            if (listSubjectDepartmentFromDB != null)
            {
                return new ServiceResponse<ICollection<GetSubjectDepartmentDto>>() { Success = true, Message = "Get list Subject Department Success", Data = listSubjectDepartmentFromDB };
            }
            return new() { Message = "List Subject Department is not exist", Success = false };
        }

        public async Task<ServiceResponse<GetSubjectDepartmentDto>> GetSubjectDepartmentByCondition(Expression<Func<SubjectDepartment, bool>> expression = null, List<string> includes = null)
        {
            var subjectDepartmentFromDB = _mapper.Map<GetSubjectDepartmentDto>(await _unitOfWork.SubjectDepartments.FindByConditionAsync(expression, includes));

            if (subjectDepartmentFromDB != null)
            {
                return new ServiceResponse<GetSubjectDepartmentDto>() { Success = true, Message = "Get Subject Department Success", Data = subjectDepartmentFromDB };
            }
            return new() { Message = "Subject Department is not exist", Success = false };
        }

        public async Task<bool> IsExisted(Expression<Func<SubjectDepartment, bool>> expression = null)
        {
            var isExist = await _unitOfWork.SubjectDepartments.FindByConditionAsync(expression);
            if (isExist == null)
            {
                return false;
            }
            return true;
        }

        public async Task<bool> SaveChange()
        => await _unitOfWork.SubjectDepartments.Save();

        public async Task<ServiceResponse<UpdateSubjectDepartmentDto>> Update(UpdateSubjectDepartmentDto updateSubjectDepartment)
        {
            try
            {
                var subjectDepartmentFromDB = await Find(x => x.Id == 1.ToString());
                if (subjectDepartmentFromDB != null)
                {
                    var task = _mapper.Map<SubjectDepartment>(updateSubjectDepartment);
                    _unitOfWork.SubjectDepartments.Update(task);
                    if (!await SaveChange())
                    {
                        return new ServiceResponse<UpdateSubjectDepartmentDto> { Success = false, Message = "Error when update Subject Department" };
                    }
                    return new ServiceResponse<UpdateSubjectDepartmentDto> { Success = true, Message = "Update Subject Department Success" };
                }
                else
                {
                    return new ServiceResponse<UpdateSubjectDepartmentDto> { Success = false, Message = "Not Found Subject Department" };
                }
            }
            catch (Exception ex)
            {
                return new ServiceResponse<UpdateSubjectDepartmentDto> { Success = false, Message = ex.Message };
            }
        }

        public async Task<ServiceResponse<GetSubjectDepartmentDto>> UpdateSubjectDepartment(UpdateSubjectDepartmentDto updateSubjectDepartment)
        {
            try
            {
                var task = _mapper.Map<SubjectDepartment>(updateSubjectDepartment);
                _unitOfWork.SubjectDepartments.Update(task);
                if (!await SaveChange())
                {
                    return new ServiceResponse<GetSubjectDepartmentDto> { Success = false, Message = "Error when update Subject Department" };
                }
                return new ServiceResponse<GetSubjectDepartmentDto> { Success = true, Message = "Update Subject Department Success" };

            }
            catch (Exception ex)
            {
                return new ServiceResponse<GetSubjectDepartmentDto> { Success = false, Message = ex.Message };
            }
        }
    }
}
