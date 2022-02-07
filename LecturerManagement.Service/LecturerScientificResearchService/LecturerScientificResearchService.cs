using AutoMapper;
using LecturerManagement.Core.Contracts;
using LecturerManagement.Core.Models;
using LecturerManagement.Core.Models.Entities;
using LecturerManagement.DTOS.LecturerScientificResearch;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace LecturerManagement.Services.LecturerScientificResearchService
{
    public class LecturerScientificResearchService : ILecturerScientificResearchService
    {
        private readonly IMapper _mapper;
        private readonly IUnitOfWork _unitOfWork;
        public LecturerScientificResearchService(IMapper mapper, IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task<ServiceResponse<AddLecturerScientificResearchDto>> Create(AddLecturerScientificResearchDto createLecturerScientificResearch)
        {
            try
            {
                await _unitOfWork.LecturerScientificResearches.Create(_mapper.Map<LecturerScientificResearch>(createLecturerScientificResearch));
                if (await SaveChange())
                {
                    return new ServiceResponse<AddLecturerScientificResearchDto> { Success = true, Message = "Add Lecturer Scientific Research Success" };
                }
                else
                {
                    return new ServiceResponse<AddLecturerScientificResearchDto> { Success = false, Message = "Error when create new Lecturer Scientific Research" };
                }
            }
            catch (Exception ex)
            {
                return new ServiceResponse<AddLecturerScientificResearchDto> { Success = false, Message = ex.Message };
            }
        }

        public async Task<ServiceResponse<LecturerScientificResearch>> Delete(LecturerScientificResearch deleteLecturerScientificResearch)
        {
            try
            {
                var lecturerScientificResearchFromDB = await Find(x => x.Id == 1.ToString());
                if (lecturerScientificResearchFromDB != null)
                {
                    _unitOfWork.LecturerScientificResearches.Delete(deleteLecturerScientificResearch);
                    if (!await SaveChange())
                    {
                        return new ServiceResponse<LecturerScientificResearch> { Success = false, Message = "Error when delete Lecturer" };
                    }
                    return new ServiceResponse<LecturerScientificResearch> { Success = true, Message = "Delete Lecturer Success" };
                }
                else
                {
                    return new ServiceResponse<LecturerScientificResearch> { Success = false, Message = "Not Found Lecturer" };
                }
            }
            catch (Exception ex)
            {

                return new ServiceResponse<LecturerScientificResearch> { Success = false, Message = ex.Message };
            }
        }

        public async Task<GetLecturerScientificResearchDto> Find(Expression<Func<LecturerScientificResearch, bool>> expression = null, List<string> includes = null)
        => _mapper.Map<GetLecturerScientificResearchDto>(await _unitOfWork.LecturerScientificResearches.FindByConditionAsync(expression, includes));

        public async Task<ICollection<GetLecturerScientificResearchDto>> FindAll(Expression<Func<LecturerScientificResearch, bool>> expression = null, Func<IQueryable<LecturerScientificResearch>, IOrderedQueryable<LecturerScientificResearch>> orderBy = null, List<string> includes = null)
        => _mapper.Map<ICollection<GetLecturerScientificResearchDto>>(await _unitOfWork.LecturerScientificResearches.FindAllAsync(expression, orderBy, includes));

        public async Task<bool> IsExisted(Expression<Func<LecturerScientificResearch, bool>> expression = null)
        {
            var isExist = await _unitOfWork.LecturerScientificResearches.FindByConditionAsync(expression);
            if (isExist == null)
            {
                return false;
            }
            return true;
        }

        public async Task<bool> SaveChange()
            => await _unitOfWork.LecturerScientificResearches.Save();

        public async Task<ServiceResponse<UpdateLecturerScientificResearchDto>> Update(UpdateLecturerScientificResearchDto updateLecturerScientificResearch)
        {
            try
            {
                var lecturerScientificResearchFromDB = await Find(x => x.Id == 1.ToString());
                if (lecturerScientificResearchFromDB != null)
                {
                    var task = _mapper.Map<LecturerScientificResearch>(updateLecturerScientificResearch);
                    _unitOfWork.LecturerScientificResearches.Update(task);
                    if (!await SaveChange())
                    {
                        return new ServiceResponse<UpdateLecturerScientificResearchDto> { Success = false, Message = "Error when update Lecturer Scientific Research" };
                    }
                    return new ServiceResponse<UpdateLecturerScientificResearchDto> { Success = true, Message = "Update Lecturer Scientific Research Success" };
                }
                else
                {
                    return new ServiceResponse<UpdateLecturerScientificResearchDto> { Success = false, Message = "Not Found Lecturer Scientific Research" };
                }
            }
            catch (Exception ex)
            {
                return new ServiceResponse<UpdateLecturerScientificResearchDto> { Success = false, Message = ex.Message };
            }
        }
    }
}
