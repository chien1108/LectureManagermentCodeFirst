﻿using AutoMapper;
using LecturerManagement.Core.Contracts;
using LecturerManagement.Core.Models;
using LecturerManagement.Core.Models.Entities;
using LecturerManagement.DTOS.Subject;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace LecturerManagement.Services.SubjectService
{
    public class SubjectService : ISubjectService
    {
        private readonly IMapper _mapper;
        private readonly IUnitOfWork _unitOfWork;
        public SubjectService(IMapper mapper, IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task<ServiceResponse<GetSubjectDto>> AddSubject(AddSubjectDto createSubject)
        {
            try
            {
                await _unitOfWork.Subjects.Create(_mapper.Map<Subject>(createSubject));
                if (await SaveChange())
                {
                    return new ServiceResponse<GetSubjectDto> { Success = true, Message = "Add Subject Success" };
                }
                else
                {
                    return new ServiceResponse<GetSubjectDto> { Success = false, Message = "Error when create new Subject" };
                }
            }
            catch (Exception ex)
            {
                return new ServiceResponse<GetSubjectDto> { Success = false, Message = ex.Message };
            }
        }
        public async Task<ServiceResponse<GetSubjectDto>> DeleteSubject(Subject deleteSubject)
        {
            try
            {
                _unitOfWork.Subjects.Delete(deleteSubject);
                if (!await SaveChange())
                {
                    return new ServiceResponse<GetSubjectDto> { Success = false, Message = "Error when delete Subject" };
                }
                return new ServiceResponse<GetSubjectDto> { Success = true, Message = "Delete Subject Success" };
            }
            catch (Exception ex)
            {
                return new ServiceResponse<GetSubjectDto> { Success = false, Message = ex.Message };
            }
        }

        public async Task<ServiceResponse<ICollection<GetSubjectDto>>> GetAllSubject(Expression<Func<Subject, bool>> expression = null, Func<IQueryable<Subject>, IOrderedQueryable<Subject>> orderBy = null, List<string> includes = null)
        {
            var listSubjectFromDb = _mapper.Map<ICollection<GetSubjectDto>>(await _unitOfWork.Subjects.FindAllAsync(expression, orderBy, includes));
            if (listSubjectFromDb != null)
            {
                return new() { Success = true, Message = "Get list Subject Success", Data = listSubjectFromDb };
            }
            return new() { Message = "List Subject is not exist", Success = false };
        }

        public async Task<ServiceResponse<GetSubjectDto>> GetSubjectByCondition(Expression<Func<Subject, bool>> expression = null, List<string> includes = null)
        {
            var subjectFromDb = _mapper.Map<GetSubjectDto>(await _unitOfWork.Subjects.FindByConditionAsync(expression, includes));
            if (subjectFromDb != null)
            {
                return new() { Success = true, Message = "Get Subject Success", Data = subjectFromDb };
            }
            return new() { Message = "Subject is not exist", Success = false };
        }

        public async Task<bool> IsExisted(Expression<Func<Subject, bool>> expression = null)
        {
            var isExist = await _unitOfWork.Subjects.FindByConditionAsync(expression);
            if (isExist == null)
            {
                return false;
            }
            return true;
        }

        public async Task<bool> SaveChange()
        => await _unitOfWork.Subjects.Save();

        public async Task<ServiceResponse<GetSubjectDto>> UpdateSubject(UpdateSubjectDto updateSubject)
        {
            try
            {
                var task = _mapper.Map<Subject>(updateSubject);
                _unitOfWork.Subjects.Update(task);
                if (!await SaveChange())
                {
                    return new ServiceResponse<GetSubjectDto> { Success = false, Message = "Error when update Subject" };
                }
                return new ServiceResponse<GetSubjectDto> { Success = true, Message = "Update Subject Success" };
            }
            catch (Exception ex)
            {
                return new ServiceResponse<GetSubjectDto> { Success = false, Message = ex.Message };
            }
        }
    }
}