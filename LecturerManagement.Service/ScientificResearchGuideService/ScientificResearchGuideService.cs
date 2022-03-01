using AutoMapper;
using LecturerManagement.Core.Contracts;
using LecturerManagement.Core.Models;
using LecturerManagement.Core.Models.Entities;
using LecturerManagement.DTOS.Modules.Functions;
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

        public async Task<ServiceResponse<GetScientificResearchGuideDto>> AddScientificResearchGuide(AddScientificResearchGuideDto newScientificResearchGuide)
        {
            try
            {
                var listFromDb = await _unitOfWork.ScientificResearchGuides.FindAllAsync();
                var length = listFromDb.Count;

                var scientificResearchGuide = new ScientificResearchGuide()
                {
                    CreatedDate = DateTime.Now,
                    LecturerId = newScientificResearchGuide.LecturerID,
                    Description = newScientificResearchGuide.Description,
                    Quantity = newScientificResearchGuide.Quantity,
                    SchoolYear = newScientificResearchGuide.SchoolYear,
                    StudentYear = newScientificResearchGuide.StudentYear,
                    Status = DTOS.Modules.Enums.Status.IsActive
                };

                if (length == 0)
                {
                    scientificResearchGuide.Id = "HDNCKHUTT001";
                }
                else
                {
                    scientificResearchGuide.Id = GenerateUniqueStringId.GenrateNewStringId(prefix: listFromDb[length - 1].Id, textFormatPrefix: 9, numberFormatPrefix: 3);
                }

                await _unitOfWork.ScientificResearchGuides.Create(scientificResearchGuide);
                if (await SaveChange())
                {
                    return new ServiceResponse<GetScientificResearchGuideDto> { Success = true, Message = "Add Scientific Research Guide Success" };
                }
                else
                {
                    return new ServiceResponse<GetScientificResearchGuideDto> { Success = false, Message = "Error when create new Scientific Research Guide" };
                }
            }
            catch (Exception ex)
            {
                return new ServiceResponse<GetScientificResearchGuideDto> { Success = false, Message = ex.StackTrace };
            }
        }
        public async Task<ServiceResponse<GetScientificResearchGuideDto>> DeleteScientificResearchGuide(ScientificResearchGuide deleteScientificResearchGuide)
        {
            try
            {

                _unitOfWork.ScientificResearchGuides.Delete(deleteScientificResearchGuide);
                if (!await SaveChange())
                {
                    return new ServiceResponse<GetScientificResearchGuideDto> { Success = false, Message = "Error when delete Scientific Research Guide" };
                }
                return new ServiceResponse<GetScientificResearchGuideDto> { Success = true, Message = "Delete Lecturer Scientific Research Guide" };

            }
            catch (Exception ex)
            {
                return new ServiceResponse<GetScientificResearchGuideDto> { Success = false, Message = ex.StackTrace };
            }
        }

        public async Task<ServiceResponse<ICollection<GetScientificResearchGuideDto>>> GetAllScientificResearchGuide(Expression<Func<ScientificResearchGuide, bool>> expression = null, Func<IQueryable<ScientificResearchGuide>, IOrderedQueryable<ScientificResearchGuide>> orderBy = null, List<string> includes = null)
        {
            var listScientificResearchGuidFromDB = _mapper.Map<ICollection<GetScientificResearchGuideDto>>(await _unitOfWork.ScientificResearchGuides.FindAllAsync(expression, orderBy, includes));
            if (listScientificResearchGuidFromDB != null)
            {
                return new() { Success = true, Message = "Get list Scientific Research Guide Success", Data = listScientificResearchGuidFromDB };
            }
            return new() { Message = "List Scientific Research Guide is not exist", Success = false };
        }

        public async Task<ServiceResponse<GetScientificResearchGuideDto>> GetScientificResearchGuideByCondition(Expression<Func<ScientificResearchGuide, bool>> expression = null, List<string> includes = null)
        {
            var scientificResearchGuidFromDB = _mapper.Map<GetScientificResearchGuideDto>(await _unitOfWork.ScientificResearchGuides.FindByConditionAsync(expression, includes));
            if (scientificResearchGuidFromDB != null)
            {
                return new() { Success = true, Message = "Get list Scientific Research Guide Success", Data = scientificResearchGuidFromDB };
            }
            return new() { Message = "List Scientific Research Guide is not exist", Success = false };
        }

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

        public async Task<ServiceResponse<GetScientificResearchGuideDto>> UpdateScientificResearchGuide(UpdateScientificResearchGuideDto updateScientificResearchGuide, Expression<Func<ScientificResearchGuide, bool>> expression = null)
        {
            try
            {
                var scientificResearchGuideFromDb = await _unitOfWork.ScientificResearchGuides.FindByConditionAsync(expression);

                scientificResearchGuideFromDb.ModifiedDate = DateTime.Now;
                scientificResearchGuideFromDb.Quantity = updateScientificResearchGuide.Quantity;
                scientificResearchGuideFromDb.StudentYear = updateScientificResearchGuide.StudentYear;
                scientificResearchGuideFromDb.SchoolYear = updateScientificResearchGuide.SchoolYear;
                scientificResearchGuideFromDb.Description = updateScientificResearchGuide.Description;
                _unitOfWork.ScientificResearchGuides.Update(scientificResearchGuideFromDb);
                if (!await SaveChange())
                {
                    return new ServiceResponse<GetScientificResearchGuideDto> { Success = false, Message = "Error when update Scientific Research Guide" };
                }
                return new ServiceResponse<GetScientificResearchGuideDto> { Success = true, Message = "Update Scientific Research Guide Success" };
            }
            catch (Exception ex)
            {
                return new ServiceResponse<GetScientificResearchGuideDto> { Success = false, Message = ex.StackTrace };
            }
        }
    }
}
