using AutoMapper;
using LecturerManagermentCodeFirst.API.Data;
using LecturerManagermentCodeFirst.API.Entities;
using LecturerManagermentCodeFirst.DTO.DTOS.AdvancedLearning;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LecturerManagermentCodeFirst.API.Services.AdvancedLearningService
{
    public class AdvancedLearningService : IAdvancedLearningService
    {
        private readonly LecturerManagermentSystemDbContext _context;
        private readonly IMapper _mapper;

        public AdvancedLearningService(LecturerManagermentSystemDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }
        public async Task<ServiceResponse<IEnumerable<GetAdvancedLearningDto>>> AddAdvancedLearning(AddAdvancedLearningDto add)
        {
            var response = new ServiceResponse<IEnumerable<GetAdvancedLearningDto>>();
            try
            {
                var advancedLearning = _mapper.Map<AdvancedLearning>(add);
                _context.AdvancedLearnings.Add(advancedLearning);
                await _context.SaveChangesAsync();
                response.Data = await _context.AdvancedLearnings.Select(x => _mapper.Map<GetAdvancedLearningDto>(x)).ToListAsync();
            }
            catch(Exception ex)
            {
                response.Success = false;
                response.Message = ex.Message;
            }
            
            return response;
        }

        public async Task<ServiceResponse<IEnumerable<GetAdvancedLearningDto>>> DeleteAdvancedLearning(int id)
        {
            var response = new ServiceResponse<IEnumerable<GetAdvancedLearningDto>>();
            try
            {
                var advancedLearning = await _context.AdvancedLearnings.FirstOrDefaultAsync(x => x.ID == id);
                _context.AdvancedLearnings.Remove(advancedLearning);
                await _context.SaveChangesAsync();
                response.Data = response.Data = await _context.AdvancedLearnings.Select(x => _mapper.Map<GetAdvancedLearningDto>(x)).ToListAsync();
            }
            catch(Exception ex)
            {
                response.Success = false;
                response.Message = ex.Message;
            }
            return response;
        }

        public async Task<ServiceResponse<GetAdvancedLearningDto>> GetAdvancedLearningById(int id)
        {
            var response = new ServiceResponse<GetAdvancedLearningDto>();
            try
            {
                var advancedLearning = await _context.AdvancedLearnings.FirstOrDefaultAsync(x => x.ID == id);
                response.Data = _mapper.Map<GetAdvancedLearningDto>(advancedLearning);
            }
            catch (Exception ex)
            {
                response.Success = false;
                response.Message = ex.Message;
            }
            return response;
        }

        public async Task<ServiceResponse<IEnumerable<GetAdvancedLearningDto>>> GetAdvancedLearnings()
        {
            var response = new ServiceResponse<IEnumerable<GetAdvancedLearningDto>>();
            try
            {
                response.Data = response.Data = await _context.AdvancedLearnings.Select(x => _mapper.Map<GetAdvancedLearningDto>(x)).ToListAsync();
            }
            catch (Exception ex)
            {
                response.Success = false;
                response.Message = ex.Message;
            }
            return response;
        }

        public async Task<ServiceResponse<GetAdvancedLearningDto>> UpdateAdvancedLearning(UpdateAdvancedLearningDto update)
        {
            var response = new ServiceResponse<GetAdvancedLearningDto>();
            try
            {
                var advancedLearning = _mapper.Map<AdvancedLearning>(update);
                _context.AdvancedLearnings.Update(advancedLearning);
                await _context.SaveChangesAsync();
                response.Data = _mapper.Map<GetAdvancedLearningDto>(advancedLearning);
            }
            catch (Exception ex)
            {
                response.Success = false;
                response.Message = ex.Message;
            }
            return response;
        }
    }
}
