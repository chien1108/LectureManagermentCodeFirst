using AutoMapper;
using LecturerManagement.Core.Contracts;
using LecturerManagement.Core.Models;
using LecturerManagement.Core.Models.Entities;
using LecturerManagement.DTOS.Modules.Functions;
using LecturerManagement.DTOS.TrainingSystem;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace LecturerManagement.Services.TrainingSystemService
{
    public class TrainingSystemService : ITrainingSystemService
    {
        private readonly IMapper _mapper;
        private readonly IUnitOfWork _unitOfWork;
        public TrainingSystemService(IMapper mapper, IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task<ServiceResponse<GetTrainingSystemDto>> AddTrainingSystem(AddTrainingSystemDto createTrainingSystem)
        {
            try
            {
                var listFromDb = await _unitOfWork.TrainingSystems.FindAllAsync();
                var length = listFromDb.Count;

                var trainingSystem = new TrainingSystem()
                {
                    Name = createTrainingSystem.Name,
                    CreatedDate = DateTime.Now,
                    NumberOfLearningUnit = createTrainingSystem.NumberOfLearningUnit,
                    Description = createTrainingSystem.Description,
                    Status = DTOS.Modules.Enums.Status.IsActive
                };

                if (length != 0)
                {
                    trainingSystem.Id = GenerateUniqueStringId.GenrateNewStringId(prefix: listFromDb[length - 1].Id, textFormatPrefix: 2, numberFormatPrefix: 2);
                }
                else
                {
                    trainingSystem.Id = "TS01";
                }

                await _unitOfWork.TrainingSystems.Create(trainingSystem);
                if (await SaveChange())
                {
                    return new ServiceResponse<GetTrainingSystemDto> { Success = true, Message = "Add Training System Success" };
                }
                else
                {
                    return new ServiceResponse<GetTrainingSystemDto> { Success = false, Message = "Error when create new Training System" };
                }
            }
            catch (Exception ex)
            {
                return new ServiceResponse<GetTrainingSystemDto> { Success = false, Message = ex.StackTrace };
            }
        }

        public async Task<ServiceResponse<TrainingSystem>> Delete(Expression<Func<TrainingSystem, bool>> expression = null)
        {
            try
            {
                var trainingSystemFromDb = await _unitOfWork.TrainingSystems.FindByConditionAsync(expression);
                _unitOfWork.TrainingSystems.Delete(trainingSystemFromDb);
                if (!await SaveChange())
                {
                    return new ServiceResponse<TrainingSystem> { Success = false, Message = "Error when delete Training System" };
                }
                return new ServiceResponse<TrainingSystem> { Success = true, Message = "Delete Training System Success" };
            }
            catch (Exception ex)
            {
                return new ServiceResponse<TrainingSystem> { Success = false, Message = ex.StackTrace };
            }
        }

        public async Task<ServiceResponse<GetTrainingSystemDto>> DeleteTrainingSystem(Expression<Func<TrainingSystem, bool>> expression = null)
        {
            try
            {
                var trainingSystemFromDb = await _unitOfWork.TrainingSystems.FindByConditionAsync(expression);
                _unitOfWork.TrainingSystems.Delete(trainingSystemFromDb);
                if (!await SaveChange())
                {
                    return new ServiceResponse<GetTrainingSystemDto> { Success = false, Message = "Error when delete Training System" };
                }
                return new ServiceResponse<GetTrainingSystemDto> { Success = true, Message = "Delete Training System Success" };

            }
            catch (Exception ex)
            {
                return new ServiceResponse<GetTrainingSystemDto> { Success = false, Message = ex.StackTrace };
            }
        }

        public async Task<ServiceResponse<ICollection<GetTrainingSystemDto>>> GetAllTrainingSystem(Expression<Func<TrainingSystem, bool>> expression = null, Func<IQueryable<TrainingSystem>, IOrderedQueryable<TrainingSystem>> orderBy = null, List<string> includes = null)
        {
            var listTrainingFromDb = _mapper.Map<ICollection<GetTrainingSystemDto>>(await _unitOfWork.TrainingSystems.FindAllAsync(expression, orderBy, includes));
            if (listTrainingFromDb != null)
            {
                return new() { Success = true, Message = "Get list Training System Success", Data = listTrainingFromDb };
            }
            return new() { Message = "List Training System is not exist", Success = false };
        }

        public async Task<ServiceResponse<GetTrainingSystemDto>> GetTrainingSystemByCondition(Expression<Func<TrainingSystem, bool>> expression = null, List<string> includes = null)
        {
            var trainingFromDb = _mapper.Map<GetTrainingSystemDto>(await _unitOfWork.TrainingSystems.FindByConditionAsync(expression, includes));
            if (trainingFromDb != null)
            {
                return new() { Success = true, Message = "Get Training System Success", Data = trainingFromDb };
            }
            return new() { Message = "Training System is not exist", Success = false };
        }

        public async Task<bool> IsExisted(Expression<Func<TrainingSystem, bool>> expression = null)
        {
            var isExist = await _unitOfWork.TrainingSystems.FindByConditionAsync(expression);
            if (isExist == null)
            {
                return false;
            }
            return true;
        }

        public async Task<bool> SaveChange()
        => await _unitOfWork.TrainingSystems.Save();


        public async Task<ServiceResponse<GetTrainingSystemDto>> UpdateTrainingSystem(UpdateTrainingSystemDto updateTrainingSystem, Expression<Func<TrainingSystem, bool>> expression = null)
        {
            try
            {
                var trainingSystemFromDb = await _unitOfWork.TrainingSystems.FindByConditionAsync(expression);
                trainingSystemFromDb.ModifiedDate = DateTime.Now;
                trainingSystemFromDb.Name ??= updateTrainingSystem.Name;
                trainingSystemFromDb.NumberOfLearningUnit = updateTrainingSystem.NumberOfLearningUnit;
                trainingSystemFromDb.Description ??= updateTrainingSystem.Description;

                _unitOfWork.TrainingSystems.Update(trainingSystemFromDb);
                if (!await SaveChange())
                {
                    return new ServiceResponse<GetTrainingSystemDto> { Success = false, Message = "Error when update Training System" };
                }
                return new ServiceResponse<GetTrainingSystemDto> { Success = true, Message = "Update Training System Success", Data = _mapper.Map<GetTrainingSystemDto>(trainingSystemFromDb) };

            }
            catch (Exception ex)
            {
                return new ServiceResponse<GetTrainingSystemDto> { Success = false, Message = ex.StackTrace };
            }
        }


    }
}
