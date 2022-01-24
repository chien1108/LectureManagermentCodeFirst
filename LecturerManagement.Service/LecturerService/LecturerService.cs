using AutoMapper;
using LecturerManagement.Core.Contracts;
using LecturerManagement.Core.Models;
using LecturerManagement.Core.Models.Entities;
using LecturerManagement.DTOS.LecturerDTO;
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

        public async Task<ServiceResponse<AddLecturerDto>> Create(AddLecturerDto createLecturer)
        {
            try
            {
                await _unitOfWork.Lecturers.Create(_mapper.Map<Lecturer>(createLecturer));
                if (await SaveChange())
                {
                    return new ServiceResponse<AddLecturerDto> { Success = true, Message = "Add Lecturer Success" };
                }
                else
                {
                    return new ServiceResponse<AddLecturerDto> { Success = false, Message = "Error when create new Lecturer" };
                }
            }
            catch (Exception ex)
            {
                return new ServiceResponse<AddLecturerDto> { Success = false, Message = ex.Message };
            }
        }

        public async Task<ServiceResponse<Lecturer>> Delete(Lecturer deleteLecturer)
        {
            try
            {
                var deleteLecturerFromDB = await Find(x => x.Id == 1.ToString());
                if (deleteLecturerFromDB != null)
                {
                    _unitOfWork.Lecturers.Delete(deleteLecturer);
                    if (!await SaveChange())
                    {
                        return new ServiceResponse<Lecturer> { Success = false, Message = "Error when delete Lecturer" };
                    }
                    return new ServiceResponse<Lecturer> { Success = true, Message = "Delete Lecturer Success" };
                }
                else
                {
                    return new ServiceResponse<Lecturer> { Success = false, Message = "Not Found Lecturer" };
                }
            }
            catch (Exception ex)
            {
                return new ServiceResponse<Lecturer> { Success = false, Message = ex.Message };
            }
        }

        public async Task<GetLecturerDto> Find(Expression<Func<Lecturer, bool>> expression = null, List<string> includes = null)
            => _mapper.Map<GetLecturerDto>(await _unitOfWork.Lecturers.FindByConditionAsync(expression, includes));

        public async Task<ICollection<GetLecturerDto>> FindAll(Expression<Func<Lecturer, bool>> expression = null,
                                                                Func<IQueryable<Lecturer>, IOrderedQueryable<Lecturer>> orderBy = null,
                                                                List<string> includes = null)
            => _mapper.Map<ICollection<GetLecturerDto>>(await _unitOfWork.Lecturers.FindAllAsync(expression, orderBy, includes));

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

        public async Task<ServiceResponse<UpdateLecturerDto>> Update(UpdateLecturerDto updateLecturer)
        {
            try
            {
                var lecturerFromDB = await Find(x => x.Id == 1.ToString());
                if (lecturerFromDB != null)
                {
                    var task = _mapper.Map<GraduationThesis>(updateLecturer);
                    _unitOfWork.GraduationThesises.Update(task);
                    if (!await SaveChange())
                    {
                        return new ServiceResponse<UpdateLecturerDto> { Success = false, Message = "Error when update Lecturer" };
                    }
                    return new ServiceResponse<UpdateLecturerDto> { Success = true, Message = "Update Lecturer Success" };
                }
                else
                {
                    return new ServiceResponse<UpdateLecturerDto> { Success = false, Message = "Not Found Lecturer" };
                }
            }
            catch (Exception ex)
            {
                return new ServiceResponse<UpdateLecturerDto> { Success = false, Message = ex.Message };
            }
        }
    }
}