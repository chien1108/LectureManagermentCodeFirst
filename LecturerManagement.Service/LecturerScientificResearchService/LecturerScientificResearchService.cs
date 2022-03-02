using AutoMapper;
using LecturerManagement.Core.Contracts;
using LecturerManagement.Core.Models;
using LecturerManagement.Core.Models.Entities;
using LecturerManagement.DTOS.LecturerScientificResearch;
using LecturerManagement.DTOS.Modules.Functions;
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

        public async Task<ServiceResponse<GetLecturerScientificResearchDto>> AddLecturerScientificResearch(AddLecturerScientificResearchDto newLecturerScientificResearch)
        {
            try
            {
                var listFromDb = await _unitOfWork.LecturerScientificResearches.FindAllAsync();
                var length = listFromDb.Count();

                var gvNCKH = new LecturerScientificResearch()
                {
                    LecturerId = newLecturerScientificResearch.LecturerID,
                    CreatedDate = DateTime.Now,
                    Status = DTOS.Modules.Enums.Status.Working,
                    Name = newLecturerScientificResearch.Name,
                    Description = newLecturerScientificResearch.Description,
                    YearOfResearchParticipation = newLecturerScientificResearch.YearOfResearchParticipation,
                    LevelOfResearch = newLecturerScientificResearch.LevelOfResearch
                };

                if (length == 0)
                {
                    gvNCKH.Id = "GVUTTNCKH001";
                }
                else
                {
                    gvNCKH.Id = GenerateUniqueStringId.GenrateNewStringId(prefix: listFromDb[length - 1].Id, textFormatPrefix: 9, numberFormatPrefix: 3);
                }

                await _unitOfWork.LecturerScientificResearches.Create(gvNCKH);
                if (await SaveChange())
                {
                    return new ServiceResponse<GetLecturerScientificResearchDto> { Success = true, Message = "Add Lecturer Scientific Research Success" };
                }
                else
                {
                    return new ServiceResponse<GetLecturerScientificResearchDto> { Success = false, Message = "Error when create new Lecturer Scientific Research" };
                }
            }
            catch (Exception ex)
            {
                return new ServiceResponse<GetLecturerScientificResearchDto> { Success = false, Message = ex.StackTrace };
            }
        }

        public async Task<ServiceResponse<GetLecturerScientificResearchDto>> DeleteLecturerScientificResearch(Expression<Func<LecturerScientificResearch, bool>> expression = null)
        {
            try
            {
                var elementFromDb = await _unitOfWork.LecturerScientificResearches.FindByConditionAsync(expression);
                _unitOfWork.LecturerScientificResearches.Delete(elementFromDb);
                if (!await SaveChange())
                {
                    return new ServiceResponse<GetLecturerScientificResearchDto> { Success = false, Message = "Error when delete Lecturer" };
                }
                return new ServiceResponse<GetLecturerScientificResearchDto> { Success = true, Message = "Delete Lecturer Success" };

            }
            catch (Exception ex)
            {

                return new ServiceResponse<GetLecturerScientificResearchDto> { Success = false, Message = ex.Message };
            }
        }

        public async Task<ServiceResponse<ICollection<GetLecturerScientificResearchDto>>> GetAllLecturerScientificResearch(Expression<Func<LecturerScientificResearch, bool>> expression = null, Func<IQueryable<LecturerScientificResearch>, IOrderedQueryable<LecturerScientificResearch>> orderBy = null, List<string> includes = null)
        {
            var classes = _mapper.Map<ICollection<GetLecturerScientificResearchDto>>(await _unitOfWork.LecturerScientificResearches.FindAllAsync(expression, orderBy, includes));
            if (classes != null)
            {
                return new() { Success = true, Message = "Get List Lecturer Scientific Research Success", Data = classes };
            }
            return new() { Message = "Lecturer Scientific Researches is null", Success = false };
        }

        public async Task<ServiceResponse<GetLecturerScientificResearchDto>> GetLecturerScientificResearchByCondition(Expression<Func<LecturerScientificResearch, bool>> expression = null, List<string> includes = null)
        {
            var classFromDB = _mapper.Map<GetLecturerScientificResearchDto>(await _unitOfWork.LecturerScientificResearches.FindByConditionAsync(expression, includes));

            if (classFromDB != null)
            {
                return new ServiceResponse<GetLecturerScientificResearchDto>() { Success = true, Message = "Get Lecturer Scientific Research Success", Data = classFromDB };
            }
            return new() { Message = "Lecturer Scientific Research is not exist", Success = false };
        }

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

        public async Task<ServiceResponse<GetLecturerScientificResearchDto>> UpdateLecturerScientificResearch(UpdateLecturerScientificResearchDto updatedLecturerScientificResearch, Expression<Func<LecturerScientificResearch, bool>> expression = null)
        {
            try
            {
                var lecturerScientificResearchFromDb = await _unitOfWork.LecturerScientificResearches.FindByConditionAsync(expression);
                lecturerScientificResearchFromDb.ModifiedDate = DateTime.Now;
                lecturerScientificResearchFromDb.Name = updatedLecturerScientificResearch.Name;
                lecturerScientificResearchFromDb.LevelOfResearch = updatedLecturerScientificResearch.LevelOfResearch;
                lecturerScientificResearchFromDb.YearOfResearchParticipation = updatedLecturerScientificResearch.YearOfResearchParticipation;
                lecturerScientificResearchFromDb.Description = updatedLecturerScientificResearch.Description;
                var task = _mapper.Map<Class>(updatedLecturerScientificResearch);
                _unitOfWork.Classes.Update(task);
                if (!await SaveChange())
                {
                    return new ServiceResponse<GetLecturerScientificResearchDto> { Success = false, Message = "Error when update Lecturer Scientific Research" };
                }
                return new ServiceResponse<GetLecturerScientificResearchDto> { Success = true, Message = "Update Lecturer Scientific Research Success", Data = _mapper.Map<GetLecturerScientificResearchDto>(task) };
            }
            catch (Exception ex)
            {
                return new ServiceResponse<GetLecturerScientificResearchDto> { Success = false, Message = ex.Message };
            }
        }
    }
}
