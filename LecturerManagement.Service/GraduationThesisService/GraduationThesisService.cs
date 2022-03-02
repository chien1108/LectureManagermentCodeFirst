using AutoMapper;
using LecturerManagement.Core.Contracts;
using LecturerManagement.Core.Models;
using LecturerManagement.Core.Models.Entities;
using LecturerManagement.DTOS.GraduationThesis;
using LecturerManagement.DTOS.Modules.Functions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace LecturerManagement.Services.GraduationThesisService
{
    public class GraduationThesisService : IGraduationThesisService
    {

        private readonly IMapper _mapper;
        private readonly IUnitOfWork _unitOfWork;
        public GraduationThesisService(IMapper mapper, IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task<ServiceResponse<GetGraduationThesisDto>> AddGraduationThesis(AddGraduationThesisDto newGraduationThesis)
        {
            try
            {
                var listFromDb = await _unitOfWork.GraduationThesises.FindAllAsync();
                var length = listFromDb.Count();

                var graduationThesis = new GraduationThesis()
                {
                    CreatedDate = DateTime.Now,
                    Status = DTOS.Modules.Enums.Status.IsActive,
                    MarkSessionNumbers = newGraduationThesis.MarkSessionNumbers,
                    RebuttalProjectNumbers = newGraduationThesis.RebuttalProjectNumbers,
                    SchoolYear = newGraduationThesis.SchoolYear,
                    TopicNumbers = newGraduationThesis.TopicNumbers,
                    Description = newGraduationThesis.Description
                };

                if (length == 0)
                {
                    graduationThesis.Id = "GT01";
                }
                else
                {
                    graduationThesis.Id = GenerateUniqueStringId.GenrateNewStringId(prefix: listFromDb[length - 1].Id, textFormatPrefix: 2, numberFormatPrefix: 2);
                }

                await _unitOfWork.GraduationThesises.Create(graduationThesis);
                if (await SaveChange())
                {
                    return new ServiceResponse<GetGraduationThesisDto> { Success = true, Message = "Add Graduation Thesis Success" };
                }
                return new ServiceResponse<GetGraduationThesisDto> { Success = false, Message = "Error when create new Graduation Thesis" };
            }
            catch (Exception ex)
            {
                return new ServiceResponse<GetGraduationThesisDto> { Success = false, Message = ex.Message };
            }
        }

        public async Task<ServiceResponse<GetGraduationThesisDto>> DeleteGraduationThesis(Expression<Func<GraduationThesis, bool>> expression = null)
        {
            try
            {
                var elementFromDb = await _unitOfWork.GraduationThesises.FindByConditionAsync(expression);
                _unitOfWork.GraduationThesises.Delete(elementFromDb);
                if (!await SaveChange())
                {
                    return new ServiceResponse<GetGraduationThesisDto> { Success = false, Message = "Error when delete Graduation Thesis" };
                }
                return new ServiceResponse<GetGraduationThesisDto> { Success = true, Message = "Delete Graduation Thesis Success" };
            }
            catch (Exception ex)
            {
                return new ServiceResponse<GetGraduationThesisDto> { Success = false, Message = ex.Message };
            }
        }

        public async Task<ServiceResponse<IEnumerable<GetGraduationThesisDto>>> GetAllGraduationThesis(Expression<Func<GraduationThesis, bool>> expression = null, Func<IQueryable<GraduationThesis>, IOrderedQueryable<GraduationThesis>> orderBy = null, List<string> includes = null)
        {
            var listGraduationThesisFromDB = _mapper.Map<IEnumerable<GetGraduationThesisDto>>(await _unitOfWork.GraduationThesises.FindAllAsync(expression, orderBy, includes));
            if (listGraduationThesisFromDB != null)
            {
                return new() { Success = true, Message = "Get All Graduation Thesis Success", Data = listGraduationThesisFromDB };
            }
            return new() { Message = "List Graduation Thesis is Null", Success = false };
        }

        public async Task<ServiceResponse<GetGraduationThesisDto>> GetGraduationThesisByCondition(Expression<Func<GraduationThesis, bool>> expression = null, List<string> includes = null)
        {
            var graduationThesisFromDB = _mapper.Map<GetGraduationThesisDto>(await _unitOfWork.GraduationThesises.FindByConditionAsync(expression, includes));

            if (graduationThesisFromDB != null)
            {
                return new ServiceResponse<GetGraduationThesisDto>() { Success = true, Message = "Get Graduation Thesis Success", Data = graduationThesisFromDB };
            }
            return new() { Message = "Graduation Thesis is not exist", Success = false };
        }

        public async Task<bool> IsExisted(Expression<Func<GraduationThesis, bool>> expression = null)
        {
            var isExist = await _unitOfWork.GraduationThesises.FindByConditionAsync(expression);
            if (isExist == null)
            {
                return false;
            }
            return true;
        }

        public async Task<bool> SaveChange()
            => await _unitOfWork.GraduationThesises.Save();

        public async Task<ServiceResponse<GetGraduationThesisDto>> UpdateGraduationThesis(UpdateGraduationThesisDto updateGraduationThesis, Expression<Func<GraduationThesis, bool>> expression = null)
        {
            try
            {
                var graduationThesisFromDb = await _unitOfWork.GraduationThesises.FindByConditionAsync(expression);

                graduationThesisFromDb.ModifiedDate = DateTime.Now;
                graduationThesisFromDb.MarkSessionNumbers = updateGraduationThesis.MarkSessionNumbers;
                graduationThesisFromDb.TopicNumbers = updateGraduationThesis.TopicNumbers;
                graduationThesisFromDb.RebuttalProjectNumbers = updateGraduationThesis.RebuttalProjectNumbers;
                graduationThesisFromDb.SchoolYear = updateGraduationThesis.SchoolYear;
                graduationThesisFromDb.Description = updateGraduationThesis.Description;

                _unitOfWork.GraduationThesises.Update(graduationThesisFromDb);
                if (!await SaveChange())
                {
                    return new ServiceResponse<GetGraduationThesisDto> { Success = false, Message = "Error when update Graduation Thesis" };
                }
                return new ServiceResponse<GetGraduationThesisDto> { Success = true, Message = "Update Graduation Thesis Success", Data = _mapper.Map<GetGraduationThesisDto>(graduationThesisFromDb) };
            }
            catch (Exception ex)
            {
                return new ServiceResponse<GetGraduationThesisDto> { Success = false, Message = ex.Message };
            }
        }
    }
}
