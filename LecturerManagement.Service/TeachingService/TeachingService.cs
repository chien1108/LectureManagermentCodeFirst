using AutoMapper;
using LecturerManagement.Core.Contracts;
using LecturerManagement.Core.Models;
using LecturerManagement.Core.Models.Entities;
using LecturerManagement.DTOS.Modules.Functions;
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
                var listFromDb = await _unitOfWork.Teachings.FindAllAsync();
                var length = listFromDb.Count;

                var teaching = new Teaching()
                {
                    LectureId = createTeaching.LectureID,
                    ClassId = createTeaching.ClassID,
                    SubjectId = createTeaching.SubjectID,
                    NumberOfStudents = createTeaching.NumberOfStudents,
                    CreatedDate = DateTime.Now,
                    Status = DTOS.Modules.Enums.Status.IsActive,
                    Description = createTeaching.Description,
                    SchoolYear = createTeaching.SchoolYear
                };

                if (length != 0)
                {
                    teaching.Id = GenerateUniqueStringId.GenrateNewStringId(listFromDb[length - 1].Id);
                }
                else
                {
                    teaching.Id = "GD01";
                }

                await _unitOfWork.Teachings.Create(teaching);
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
                return new ServiceResponse<GetTeachingDto>
                {
                    Success = false,
                    Message = ex.StackTrace
                };
            }
        }

        public async Task<ServiceResponse<GetTeachingDto>> DeleteTeaching(Expression<Func<Teaching, bool>> expression = null)
        {
            try
            {
                var teachingFromDb = await _unitOfWork.Teachings.FindByConditionAsync(expression);
                _unitOfWork.Teachings.Delete(teachingFromDb);
                if (!await SaveChange())
                {
                    return new ServiceResponse<GetTeachingDto> { Success = false, Message = "Error when delete Teaching" };
                }
                return new ServiceResponse<GetTeachingDto> { Success = true, Message = "Delete Teaching Success" };
            }
            catch (Exception ex)
            {
                return new ServiceResponse<GetTeachingDto> { Success = false, Message = ex.StackTrace };
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
        public async Task<ServiceResponse<GetTeachingDto>> UpdateTeaching(UpdateTeachingDto updateTeaching, Expression<Func<Teaching, bool>> expression = null)
        {
            try
            {
                var teachingFromDb = await _unitOfWork.Teachings.FindByConditionAsync(expression);
                teachingFromDb.ModifiedDate = DateTime.Now;
                teachingFromDb.NumberOfStudents = updateTeaching.NumberOfStudents;
                teachingFromDb.SchoolYear = updateTeaching.SchoolYear;
                teachingFromDb.Description = updateTeaching.Description;
                _unitOfWork.Teachings.Update(teachingFromDb);
                if (!await SaveChange())
                {
                    return new ServiceResponse<GetTeachingDto> { Success = false, Message = "Error when update Teaching" };
                }
                return new ServiceResponse<GetTeachingDto> { Success = true, Message = "Update Teaching Success" };
            }
            catch (Exception ex)
            {
                return new ServiceResponse<GetTeachingDto> { Success = false, Message = ex.StackTrace };
            }
        }
    }
}
