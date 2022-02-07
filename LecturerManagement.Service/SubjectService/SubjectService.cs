using AutoMapper;
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

        public async Task<ServiceResponse<AddSubjectDto>> Create(AddSubjectDto createSubject)
        {
            try
            {
                await _unitOfWork.Subjects.Create(_mapper.Map<Subject>(createSubject));
                if (await SaveChange())
                {
                    return new ServiceResponse<AddSubjectDto> { Success = true, Message = "Add Subject Success" };
                }
                else
                {
                    return new ServiceResponse<AddSubjectDto> { Success = false, Message = "Error when create new Subject" };
                }
            }
            catch (Exception ex)
            {
                return new ServiceResponse<AddSubjectDto> { Success = false, Message = ex.Message };
            }
        }

        public async Task<ServiceResponse<Subject>> Delete(Subject deleteSubject)
        {
            try
            {
                var subjectFromDB = await Find(x => x.Id == 1.ToString());
                if (subjectFromDB != null)
                {
                    _unitOfWork.Subjects.Delete(deleteSubject);
                    if (!await SaveChange())
                    {
                        return new ServiceResponse<Subject> { Success = false, Message = "Error when delete Subject" };
                    }
                    return new ServiceResponse<Subject> { Success = true, Message = "Delete Subject Success" };
                }
                else
                {
                    return new ServiceResponse<Subject> { Success = false, Message = "Not Found Subject" };
                }
            }
            catch (Exception ex)
            {
                return new ServiceResponse<Subject> { Success = false, Message = ex.Message };
            }
        }

        public async Task<GetSubjectDto> Find(Expression<Func<Subject, bool>> expression = null, List<string> includes = null)
        => _mapper.Map<GetSubjectDto>(await _unitOfWork.Subjects.FindByConditionAsync(expression, includes));

        public async Task<ICollection<GetSubjectDto>> FindAll(Expression<Func<Subject, bool>> expression = null, Func<IQueryable<Subject>, IOrderedQueryable<Subject>> orderBy = null, List<string> includes = null)
        => _mapper.Map<ICollection<GetSubjectDto>>(await _unitOfWork.Subjects.FindAllAsync(expression, orderBy, includes));


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

        public async Task<ServiceResponse<UpdateSubjectDto>> Update(UpdateSubjectDto updateSubject)
        {
            try
            {
                var subjectFromDB = await Find(x => x.Id == 1.ToString());
                if (subjectFromDB != null)
                {
                    var task = _mapper.Map<Subject>(updateSubject);
                    _unitOfWork.Subjects.Update(task);
                    if (!await SaveChange())
                    {
                        return new ServiceResponse<UpdateSubjectDto> { Success = false, Message = "Error when update Subject" };
                    }
                    return new ServiceResponse<UpdateSubjectDto> { Success = true, Message = "Update Subject Success" };
                }
                else
                {
                    return new ServiceResponse<UpdateSubjectDto> { Success = false, Message = "Not Found Subject" };
                }
            }
            catch (Exception ex)
            {
                return new ServiceResponse<UpdateSubjectDto> { Success = false, Message = ex.Message };
            }
        }
    }
}
