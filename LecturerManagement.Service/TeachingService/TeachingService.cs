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

        public async Task<ServiceResponse<AddTeachingDto>> Create(AddTeachingDto createTeaching)
        {
            try
            {
                await _unitOfWork.Teachings.Create(_mapper.Map<Teaching>(createTeaching));
                if (await SaveChange())
                {
                    return new ServiceResponse<AddTeachingDto> { Success = true, Message = "Add Teaching Success" };
                }
                else
                {
                    return new ServiceResponse<AddTeachingDto> { Success = false, Message = "Error when create new Teaching" };
                }
            }
            catch (Exception ex)
            {
                return new ServiceResponse<AddTeachingDto> { Success = false, Message = ex.Message };
            }
        }

        public async Task<ServiceResponse<Teaching>> Delete(Teaching deleteTeaching)
        {
            try
            {
                var teachingFromDB = await Find(x => x.Id == 1);
                if (teachingFromDB != null)
                {
                    _unitOfWork.Teachings.Delete(deleteTeaching);
                    if (!await SaveChange())
                    {
                        return new ServiceResponse<Teaching> { Success = false, Message = "Error when delete Teaching" };
                    }
                    return new ServiceResponse<Teaching> { Success = true, Message = "Delete Teaching Success" };
                }
                else
                {
                    return new ServiceResponse<Teaching> { Success = false, Message = "Not Found Teaching" };
                }
            }
            catch (Exception ex)
            {
                return new ServiceResponse<Teaching> { Success = false, Message = ex.Message };
            }
        }

        public async Task<GetTeachingDto> Find(Expression<Func<Teaching, bool>> expression = null, List<string> includes = null)
            => _mapper.Map<GetTeachingDto>(await _unitOfWork.Teachings.FindByConditionAsync(expression, includes));


        public async Task<ICollection<GetTeachingDto>> FindAll(Expression<Func<Teaching, bool>> expression = null, Func<IQueryable<Teaching>, IOrderedQueryable<Teaching>> orderBy = null, List<string> includes = null)
        => _mapper.Map<ICollection<GetTeachingDto>>(await _unitOfWork.Teachings.FindAllAsync(expression, orderBy, includes));

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

        public async Task<ServiceResponse<UpdateTeachingDto>> Update(UpdateTeachingDto updateTeaching)
        {
            try
            {
                var teachingFromDB = await Find(x => x.Id == 1);
                if (teachingFromDB != null)
                {
                    var task = _mapper.Map<Teaching>(updateTeaching);
                    _unitOfWork.Teachings.Update(task);
                    if (!await SaveChange())
                    {
                        return new ServiceResponse<UpdateTeachingDto> { Success = false, Message = "Error when update Teaching" };
                    }
                    return new ServiceResponse<UpdateTeachingDto> { Success = true, Message = "Update Teaching Success" };
                }
                else
                {
                    return new ServiceResponse<UpdateTeachingDto> { Success = false, Message = "Not Found Teaching" };
                }
            }
            catch (Exception ex)
            {
                return new ServiceResponse<UpdateTeachingDto> { Success = false, Message = ex.Message };
            }
        }
    }
}
