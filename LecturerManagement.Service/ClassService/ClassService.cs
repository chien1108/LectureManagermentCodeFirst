using AutoMapper;
using LecturerManagement.Core.Contracts;
using LecturerManagement.Core.Models;
using LecturerManagement.Core.Models.Entities;
using LecturerManagement.DTOS.Class;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace LecturerManagement.Services.ClassService
{
    public class ClassService : IClassService
    {
        private readonly IMapper _mapper;
        private readonly IUnitOfWork _unitOfWork;

        public ClassService(IMapper mapper, IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task<ServiceResponse<GetClassDto>> AddNewClass(AddClassDto createClass)
        {
            try
            {
                await _unitOfWork.Classes.Create(_mapper.Map<Class>(createClass));
                if (!await SaveChange())
                {
                    return new ServiceResponse<GetClassDto> { Success = false, Message = "Error when create new Class" };
                }
                return new ServiceResponse<GetClassDto> { Success = true, Message = "Add Class Success" };
                ///, Data = _mapper.Map<GetClassDto>(await _unitOfWork.Classes.FindAllAsync())
            }
            catch (Exception ex)
            {
                return new ServiceResponse<GetClassDto> { Success = false, Message = ex.Message };
            }
        }

        public async Task<ServiceResponse<GetClassDto>> DeleteClass(Class deleteClass)
        {
            try
            {
                _unitOfWork.Classes.Delete(deleteClass);
                if (!await SaveChange())
                {
                    return new ServiceResponse<GetClassDto> { Success = false, Message = "Error when delete Class" };
                }
                return new ServiceResponse<GetClassDto> { Success = true, Message = "Delete Class Success" };
            }
            catch (Exception ex)
            {
                return new ServiceResponse<GetClassDto> { Success = false, Message = ex.Message };
            }
        }

        public async Task<ServiceResponse<ICollection<GetClassDto>>> GetAllClass(Expression<Func<Class, bool>> expression = null, Func<IQueryable<Class>, IOrderedQueryable<Class>> orderBy = null, List<string> includes = null)
        {
            var classes = _mapper.Map<ICollection<GetClassDto>>(await _unitOfWork.Classes.FindAllAsync(expression, orderBy, includes));
            if (classes != null)
            {
                return new() { Success = true, Message = "Get list Classe Success", Data = classes };
            }
            return new() { Message = "List Class is not exist", Success = false };
        }

        public async Task<ServiceResponse<GetClassDto>> GetClassByCondition(Expression<Func<Class, bool>> expression = null, List<string> includes = null)
        {
            var classFromDB = _mapper.Map<GetClassDto>(await _unitOfWork.Classes.FindByConditionAsync(expression, includes));

            if (classFromDB != null)
            {
                return new ServiceResponse<GetClassDto>() { Success = true, Message = "Get Class Success", Data = classFromDB };
            }
            return new() { Message = "Class is not exist", Success = false };
        }

        public async Task<bool> IsExisted(Expression<Func<Class, bool>> expression = null)
        {
            var isExist = await _unitOfWork.Classes.FindByConditionAsync(expression);
            if (isExist == null)
            {
                return false;
            }
            return true;
        }

        public async Task<bool> SaveChange()
             => await _unitOfWork.Classes.Save();

        public async Task<ServiceResponse<GetClassDto>> UpdateClass(UpdateClassDto updateClass)
        {
            try
            {
                var classFromDB = await _unitOfWork.Classes.FindByConditionAsync(x => x.Id == updateClass.Id);
                if (classFromDB != null)
                {
                    var task = _mapper.Map<Class>(updateClass);
                    _unitOfWork.Classes.Update(task);
                    if (!await SaveChange())
                    {
                        return new ServiceResponse<GetClassDto> { Success = false, Message = "Error when update Class" };
                    }
                    return new ServiceResponse<GetClassDto> { Success = true, Message = "Update Class Success", Data = _mapper.Map<GetClassDto>(task) };
                }
                else
                {
                    return new ServiceResponse<GetClassDto> { Success = false, Message = "Not Found Class" };
                }
            }
            catch (Exception ex)
            {
                return new ServiceResponse<GetClassDto> { Success = false, Message = ex.Message };
            }
        }
    }
}