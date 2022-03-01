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
                var lisrFromDb = await _unitOfWork.SubjectDepartments.FindAllAsync();
                SubjectDepartment newSubjectDepartment;
                var length = lisrFromDb.Count;
                if (length != 0)
                {
                    newSubjectDepartment = new()
                    {
                        //Id = GenerateUniqueStringId.GenrateNewStringId(lisrFromDb[length - 1].Id),
                        Name = createSubjectDepartment.Name,
                        Description = createSubjectDepartment.Description,
                        CreatedDate = DateTime.Now,
                        Status = DTOS.Modules.Enums.Status.IsActive
                    };
                }
                else
                {
                    newSubjectDepartment = new()
                    {
                        Id = "BM01",
                        Name = createSubjectDepartment.Name,
                        Description = createSubjectDepartment.Description,
                        CreatedDate = DateTime.Now,
                        Status = DTOS.Modules.Enums.Status.IsActive
                    };
                }

                await _unitOfWork.SubjectDepartments.Create(newSubjectDepartment);
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
                return new ServiceResponse<GetSubjectDepartmentDto>
                {
                    Success = false,
                    Message = ex.StackTrace
                };
            }
        }

        public async Task<ServiceResponse<GetSubjectDepartmentDto>> DeleteSubjectDepartment(Expression<Func<SubjectDepartment, bool>> expression = null)
        {
            try
            {
                var subjectDepartmentFromDb = await _unitOfWork.SubjectDepartments.FindByConditionAsync(expression);
                _unitOfWork.SubjectDepartments.Delete(subjectDepartmentFromDb);
                if (!await SaveChange())
                {
                    return new ServiceResponse<GetSubjectDepartmentDto> { Success = false, Message = "Error when delete Subject Department" };
                }
                return new ServiceResponse<GetSubjectDepartmentDto> { Success = true, Message = "Delete Subject Department Success" };
            }
            catch (Exception ex)
            {
                return new ServiceResponse<GetSubjectDepartmentDto> { Success = false, Message = ex.StackTrace };
            }
        }

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


        public async Task<ServiceResponse<GetSubjectDepartmentDto>> UpdateSubjectDepartment(UpdateSubjectDepartmentDto updateSubjectDepartment, Expression<Func<SubjectDepartment, bool>> expression = null)
        {
            try
            {
                var subjectDepartmentFromDb = await _unitOfWork.SubjectDepartments.FindByConditionAsync(expression);
                subjectDepartmentFromDb.Name = updateSubjectDepartment.Name;
                subjectDepartmentFromDb.ModifiedDate = DateTime.Now;
                subjectDepartmentFromDb.Description = updateSubjectDepartment.Description;
                _unitOfWork.SubjectDepartments.Update(subjectDepartmentFromDb);
                if (!await SaveChange())
                {
                    return new ServiceResponse<GetSubjectDepartmentDto> { Success = false, Message = "Error when update Subject Department" };
                }
                return new ServiceResponse<GetSubjectDepartmentDto> { Success = true, Message = "Update Subject Department Success" };

            }
            catch (Exception ex)
            {
                return new ServiceResponse<GetSubjectDepartmentDto> { Success = false, Message = ex.StackTrace };
            }
        }
    }
}
