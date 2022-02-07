using AutoMapper;
using LecturerManagement.Core.Contracts;
using LecturerManagement.Core.Models;
using LecturerManagement.Core.Models.Entities;
using LecturerManagement.DTOS.ScientificResearchGuide;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace LecturerManagement.Services.ScientificResearchGuideService
{
    public class ScientificResearchGuideService : IScientificResearchGuideService
    {
        private readonly IMapper _mapper;
        private readonly IUnitOfWork _unitOfWork;
        public ScientificResearchGuideService(IMapper mapper, IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task<ServiceResponse<AddScientificResearchGuideDto>> Create(AddScientificResearchGuideDto createScientificResearchGuide)
        {
            try
            {
                await _unitOfWork.ScientificResearchGuides.Create(_mapper.Map<ScientificResearchGuide>(createScientificResearchGuide));
                if (await SaveChange())
                {
                    return new ServiceResponse<AddScientificResearchGuideDto> { Success = true, Message = "Add Scientific Research Guide Success" };
                }
                else
                {
                    return new ServiceResponse<AddScientificResearchGuideDto> { Success = false, Message = "Error when create new Scientific Research Guide" };
                }
            }
            catch (Exception ex)
            {
                return new ServiceResponse<AddScientificResearchGuideDto> { Success = false, Message = ex.Message };
            }
        }

        public async Task<ServiceResponse<ScientificResearchGuide>> Delete(ScientificResearchGuide deleteScientificResearchGuide)
        {
            try
            {
                var scientificResearchGuidFromDB = await Find(x => x.Id == 1.ToString());
                if (scientificResearchGuidFromDB != null)
                {
                    _unitOfWork.ScientificResearchGuides.Delete(deleteScientificResearchGuide);
                    if (!await SaveChange())
                    {
                        return new ServiceResponse<ScientificResearchGuide> { Success = false, Message = "Error when delete Scientific Research Guide" };
                    }
                    return new ServiceResponse<ScientificResearchGuide> { Success = true, Message = "Delete Lecturer Scientific Research Guide" };
                }
                else
                {
                    return new ServiceResponse<ScientificResearchGuide> { Success = false, Message = "Not Found Scientific Research Guide" };
                }
            }
            catch (Exception ex)
            {
                return new ServiceResponse<ScientificResearchGuide> { Success = false, Message = ex.Message };
            }
        }

        public async Task<GetScientificResearchGuideDto> Find(Expression<Func<ScientificResearchGuide, bool>> expression = null, List<string> includes = null)
        => _mapper.Map<GetScientificResearchGuideDto>(await _unitOfWork.ScientificResearchGuides.FindByConditionAsync(expression, includes));

        public async Task<ICollection<GetScientificResearchGuideDto>> FindAll(Expression<Func<ScientificResearchGuide, bool>> expression = null, Func<IQueryable<ScientificResearchGuide>, IOrderedQueryable<ScientificResearchGuide>> orderBy = null, List<string> includes = null)
            => _mapper.Map<ICollection<GetScientificResearchGuideDto>>(await _unitOfWork.ScientificResearchGuides.FindAllAsync(expression, orderBy, includes));


        public async Task<bool> IsExisted(Expression<Func<ScientificResearchGuide, bool>> expression = null)
        {
            var isExist = await _unitOfWork.ScientificResearchGuides.FindByConditionAsync(expression);
            if (isExist == null)
            {
                return false;
            }
            return true;
        }

        public async Task<bool> SaveChange()
        => await _unitOfWork.ScientificResearchGuides.Save();

        public async Task<ServiceResponse<UpdateScientificResearchGuideDto>> Update(UpdateScientificResearchGuideDto updateScientificResearchGuide)
        {
            try
            {
                var scientificResearchGuidFromDB = await Find(x => x.Id == 1.ToString());
                if (scientificResearchGuidFromDB != null)
                {
                    var task = _mapper.Map<ScientificResearchGuide>(updateScientificResearchGuide);
                    _unitOfWork.ScientificResearchGuides.Update(task);
                    if (!await SaveChange())
                    {
                        return new ServiceResponse<UpdateScientificResearchGuideDto> { Success = false, Message = "Error when update Scientific Research Guide" };
                    }
                    return new ServiceResponse<UpdateScientificResearchGuideDto> { Success = true, Message = "Update Scientific Research Guide Success" };
                }
                else
                {
                    return new ServiceResponse<UpdateScientificResearchGuideDto> { Success = false, Message = "Not Found Scientific Research Guide" };
                }
            }
            catch (Exception ex)
            {
                return new ServiceResponse<UpdateScientificResearchGuideDto> { Success = false, Message = ex.Message };
            }
        }
    }
}
