using AutoMapper;
using LecturerManagement.Core.Contracts;
using LecturerManagement.Core.Models;
using LecturerManagement.Core.Models.Entities;
using LecturerManagement.DTOS.LecturerDTO;
using LecturerManagement.DTOS.Modules.Functions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace LecturerManagement.Services.LecturerService
{
    public class LecturerService : ILecturerService
    {
        private readonly IMapper _mapper;
        private readonly IUnitOfWork _unitOfWork;

        public LecturerService(IMapper mapper, IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task<ServiceResponse<GetLecturerDto>> AddLecturer(AddLecturerDto createLecturer)
        {
            try
            {
                var listfromDb = await _unitOfWork.Lecturers.FindAllAsync();
                var length = listfromDb.Count();

                var lecturer = new Lecturer()
                {
                    FullName = createLecturer.FullName,
                    Gender = createLecturer.Gender,
                    BirthDate = createLecturer.BirthDate,
                    IdentityCardNumber = createLecturer.IdentityCardNumber,
                    Portrait = createLecturer.Portrait,
                    AcademicLevel = createLecturer.AcademicLevel,
                    YearStartWork = createLecturer.YearStartWork,
                    Email = createLecturer.Email,
                    Address = createLecturer.Address,
                    PhoneNumber = createLecturer.PhoneNumber,
                    Description = createLecturer.Description,
                    CreatedDate = DateTime.Now,
                };

                if (length != 0)
                {
                    lecturer.Id = GenerateUniqueStringId.GenrateNewStringId(prefix: listfromDb[length - 1].Id, textFormatPrefix: 5, numberFormatPrefix: 5);
                }
                else
                {
                    lecturer.Id = "GVUTT00001";
                }

                await _unitOfWork.Lecturers.Create(lecturer);
                if (await SaveChange())
                {
                    return new ServiceResponse<GetLecturerDto> { Success = true, Message = "Add Lecturer Success" };
                }
                else
                {
                    return new ServiceResponse<GetLecturerDto> { Success = false, Message = "Error when create new Lecturer" };
                }
            }
            catch (Exception ex)
            {
                return new ServiceResponse<GetLecturerDto> { Success = false, Message = ex.Message };
            }
        }



        public async Task<ServiceResponse<GetLecturerDto>> DeleteLecturer(Expression<Func<Lecturer, bool>> expression = null)
        {
            try
            {
                var lecturerFromDb = await _unitOfWork.Lecturers.FindByConditionAsync(expression);
                _unitOfWork.Lecturers.Delete(lecturerFromDb);
                if (!await SaveChange())
                {
                    return new ServiceResponse<GetLecturerDto> { Success = false, Message = "Error when delete Lecturer" };
                }
                return new ServiceResponse<GetLecturerDto> { Success = true, Message = "Delete Lecturer Success" };

            }
            catch (Exception ex)
            {
                return new ServiceResponse<GetLecturerDto> { Success = false, Message = ex.Message };
            }
        }

        public async Task<ServiceResponse<ICollection<GetLecturerDto>>> GetAllLecturer(Expression<Func<Lecturer, bool>> expression = null, Func<IQueryable<Lecturer>, IOrderedQueryable<Lecturer>> orderBy = null, List<string> includes = null)
        {
            var listLecturerFromDB = _mapper.Map<ICollection<GetLecturerDto>>(await _unitOfWork.Lecturers.FindAllAsync(expression, orderBy, includes));

            if (listLecturerFromDB != null)
            {
                return new ServiceResponse<ICollection<GetLecturerDto>>() { Success = true, Message = "Get Lecturer Success", Data = listLecturerFromDB };
            }
            return new() { Message = "Lecturer is not exist", Success = false };
        }

        public async Task<ServiceResponse<GetLecturerDto>> GetLecturerByCondition(Expression<Func<Lecturer, bool>> expression = null, List<string> includes = null)
        {
            var lecturerFromDB = _mapper.Map<GetLecturerDto>(await _unitOfWork.Lecturers.FindByConditionAsync(expression, includes));

            if (lecturerFromDB != null)
            {
                return new ServiceResponse<GetLecturerDto>() { Success = true, Message = "Get Lecturer Success", Data = lecturerFromDB };
            }
            return new() { Message = "Lecturer is not exist", Success = false };
        }

        public async Task<bool> IsExisted(Expression<Func<Lecturer, bool>> expression = null)
        {
            var isExist = await _unitOfWork.Lecturers.FindByConditionAsync(expression);
            if (isExist == null)
            {
                return false;
            }
            return true;
        }

        public async Task<bool> SaveChange()
            => await _unitOfWork.Lecturers.Save();



        public async Task<ServiceResponse<GetLecturerDto>> UpdateLecturer(UpdateLecturerDto updateLecturer, Expression<Func<Lecturer, bool>> expression = null)
        {
            try
            {
                #region UpdateLecturer
                var lecturerFromDb = await _unitOfWork.Lecturers.FindByConditionAsync(expression);

                lecturerFromDb.ModifiedDate = DateTime.Now;
                lecturerFromDb.IdentityCardNumber = updateLecturer.IdentityCardNumber;
                lecturerFromDb.FullName = updateLecturer.FullName;
                lecturerFromDb.Gender = updateLecturer.Gender;
                lecturerFromDb.Portrait = updateLecturer.Portrait;
                lecturerFromDb.AcademicLevel = updateLecturer.AcademicLevel;
                lecturerFromDb.Email = updateLecturer.Email;
                lecturerFromDb.Address = updateLecturer.Address;
                lecturerFromDb.BirthDate = updateLecturer.BirthDate;
                lecturerFromDb.Description = updateLecturer.Description;
                lecturerFromDb.YearStartWork = updateLecturer.YearStartWork;
                lecturerFromDb.PhoneNumber = updateLecturer.PhoneNumber;
                #endregion 
                _unitOfWork.Lecturers.Update(lecturerFromDb);
                if (!await SaveChange())
                {
                    return new ServiceResponse<GetLecturerDto> { Success = false, Message = "Error when update Lecturer" };
                }
                return new ServiceResponse<GetLecturerDto> { Success = true, Message = "Update Lecturer Success", Data = _mapper.Map<GetLecturerDto>(lecturerFromDb) };

            }
            catch (Exception ex)
            {
                return new ServiceResponse<GetLecturerDto> { Success = false, Message = ex.Message };
            }
        }
    }
}