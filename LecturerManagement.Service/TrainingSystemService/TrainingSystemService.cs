using AutoMapper;
using LecturerManagement.Core.Contracts;
using LecturerManagement.Core.Models;
using LecturerManagement.Core.Models.Entities;
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

        public async Task<ServiceResponse<AddTrainingSystemDto>> Create(AddTrainingSystemDto createTrainingSystem)
        {
            try
            {
                await _unitOfWork.TrainingSystems.Create(_mapper.Map<TrainingSystem>(createTrainingSystem));
                if (await SaveChange())
                {
                    return new ServiceResponse<AddTrainingSystemDto> { Success = true, Message = "Add Training System Success" };
                }
                else
                {
                    return new ServiceResponse<AddTrainingSystemDto> { Success = false, Message = "Error when create new Training System" };
                }
            }
            catch (Exception ex)
            {
                return new ServiceResponse<AddTrainingSystemDto> { Success = false, Message = ex.Message };
            }
        }

        public async Task<ServiceResponse<TrainingSystem>> Delete(TrainingSystem deleteTrainingSystem)
        {
            try
            {
                var trainingSystemFromDB = await Find(x => x.Id == 1.ToString());
                if (trainingSystemFromDB != null)
                {
                    _unitOfWork.TrainingSystems.Delete(deleteTrainingSystem);
                    if (!await SaveChange())
                    {
                        return new ServiceResponse<TrainingSystem> { Success = false, Message = "Error when delete Training System" };
                    }
                    return new ServiceResponse<TrainingSystem> { Success = true, Message = "Delete Training System Success" };
                }
                else
                {
                    return new ServiceResponse<TrainingSystem> { Success = false, Message = "Not Found Training System" };
                }
            }
            catch (Exception ex)
            {
                return new ServiceResponse<TrainingSystem> { Success = false, Message = ex.Message };
            }
        }

        public async Task<GetTrainingSystemDto> Find(Expression<Func<TrainingSystem, bool>> expression = null, List<string> includes = null)
        => _mapper.Map<GetTrainingSystemDto>(await _unitOfWork.TrainingSystems.FindByConditionAsync(expression, includes));


        public async Task<ICollection<GetTrainingSystemDto>> FindAll(Expression<Func<TrainingSystem, bool>> expression = null, Func<IQueryable<TrainingSystem>, IOrderedQueryable<TrainingSystem>> orderBy = null, List<string> includes = null)
         => _mapper.Map<ICollection<GetTrainingSystemDto>>(await _unitOfWork.TrainingSystems.FindAllAsync(expression, orderBy, includes));

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

        public async Task<ServiceResponse<UpdateTrainingSystemDto>> Update(UpdateTrainingSystemDto updateTrainingSystem)
        {
            try
            {
                var trainingSystemFromDB = await Find(x => x.Id == 1.ToString());
                if (trainingSystemFromDB != null)
                {
                    var task = _mapper.Map<TrainingSystem>(updateTrainingSystem);
                    _unitOfWork.TrainingSystems.Update(task);
                    if (!await SaveChange())
                    {
                        return new ServiceResponse<UpdateTrainingSystemDto> { Success = false, Message = "Error when update Training System" };
                    }
                    return new ServiceResponse<UpdateTrainingSystemDto> { Success = true, Message = "Update Training System Success" };
                }
                else
                {
                    return new ServiceResponse<UpdateTrainingSystemDto> { Success = false, Message = "Not Found Training System" };
                }
            }
            catch (Exception ex)
            {
                return new ServiceResponse<UpdateTrainingSystemDto> { Success = false, Message = ex.Message };
            }
        }
    }
}
