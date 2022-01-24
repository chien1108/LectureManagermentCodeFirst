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

        public async Task<ServiceResponse<AddClassDto>> Create(AddClassDto createClass)
        {
            try
            {
                await _unitOfWork.Classes.Create(_mapper.Map<Class>(createClass));
                if (await SaveChange())
                {
                    return new ServiceResponse<AddClassDto> { Success = true, Message = "Add Class Success" };
                }
                else
                {
                    return new ServiceResponse<AddClassDto> { Success = false, Message = "Error when create new Class" };
                }
            }
            catch (Exception ex)
            {
                return new ServiceResponse<AddClassDto> { Success = false, Message = ex.Message };
            }
        }

        public async Task<ServiceResponse<Class>> Delete(Class deleteClass)
        {
            try
            {
                var deleteClassFromDB = await Find(x => x.Id == 1.ToString());
                if (deleteClassFromDB != null)
                {
                    _unitOfWork.Classes.Delete(deleteClass);
                    if (!await SaveChange())
                    {
                        return new ServiceResponse<Class> { Success = false, Message = "Error when delete Class" };
                    }
                    return new ServiceResponse<Class> { Success = true, Message = "Delete Class Success" };
                }
                else
                {
                    return new ServiceResponse<Class> { Success = false, Message = "Not Found Class" };
                }
            }
            catch (Exception ex)
            {
                return new ServiceResponse<Class> { Success = false, Message = ex.Message };
            }
        }

        public async Task<GetClassDto> Find(Expression<Func<Class, bool>> expression = null, List<string> includes = null)
        => _mapper.Map<GetClassDto>(await _unitOfWork.Classes.FindByConditionAsync(expression, includes));

        public async Task<ICollection<GetClassDto>> FindAll(Expression<Func<Class, bool>> expression = null, Func<IQueryable<Class>, IOrderedQueryable<Class>> orderBy = null, List<string> includes = null)
        => _mapper.Map<ICollection<GetClassDto>>(await _unitOfWork.Classes.FindAllAsync(expression, orderBy, includes));

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

        public async Task<ServiceResponse<UpdateClassDto>> Update(UpdateClassDto updateClass)
        {
            try
            {
                var classFromDB = await Find(x => x.Id == 1.ToString());
                if (classFromDB != null)
                {
                    var task = _mapper.Map<Class>(updateClass);
                    _unitOfWork.Classes.Update(task);
                    if (!await SaveChange())
                    {
                        return new ServiceResponse<UpdateClassDto> { Success = false, Message = "Error when update Class" };
                    }
                    return new ServiceResponse<UpdateClassDto> { Success = true, Message = "Update Class Success" };
                }
                else
                {
                    return new ServiceResponse<UpdateClassDto> { Success = false, Message = "Not Found Class" };
                }
            }
            catch (Exception ex)
            {
                return new ServiceResponse<UpdateClassDto> { Success = false, Message = ex.Message };
            }
        }
    }
}