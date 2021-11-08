using AutoMapper;
using LecturerManagermentCodeFirst.API.Data;
using LecturerManagermentCodeFirst.API.Entities;
using LecturerManagermentCodeFirst.DTO.DTOS.LecturerScientificResearch;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LecturerManagermentCodeFirst.API.Services.LecturerScientificResearchService
{
    public class LecturerScientificResearchService : ILecturerScientificResearchService
    {
        private readonly LecturerManagermentSystemDbContext _context;
        private readonly IMapper _mapper;

        public LecturerScientificResearchService(LecturerManagermentSystemDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }
        public async Task<ServiceResponse<IEnumerable<GetLecturerScientificResearchDto>>> AddLecturerScientificResearch(AddLecturerScientificResearchDto add)
        {
            var response = new ServiceResponse<IEnumerable<GetLecturerScientificResearchDto>>();
            try
            {
                var lecturerScientificResearch = _mapper.Map<LecturerScientificResearch>(add);
                _context.LecturerScientificResearches.Add(lecturerScientificResearch);
                await _context.SaveChangesAsync();
                response.Data = await _context.LecturerScientificResearches.Select(x => _mapper.Map<GetLecturerScientificResearchDto>(x)).ToListAsync();
            }
            catch(Exception ex)
            {
                response.Success = false;
                response.Message = ex.Message;
            }
            return response;
        }

        public async Task<ServiceResponse<IEnumerable<GetLecturerScientificResearchDto>>> DeleteLecturerScientificResearch(int id)
        {
            var response = new ServiceResponse<IEnumerable<GetLecturerScientificResearchDto>>();
            try
            {
                var lecturerScientificResearch = await _context.LecturerScientificResearches.FirstOrDefaultAsync(x => x.ID.Equals(id));
                _context.LecturerScientificResearches.Remove(lecturerScientificResearch);
                await _context.SaveChangesAsync();
                response.Data = await _context.LecturerScientificResearches.Select(x => _mapper.Map<GetLecturerScientificResearchDto>(x)).ToListAsync();
            }
            catch (Exception ex)
            {
                response.Success = false;
                response.Message = ex.Message;
            }
            return response;
        }

        public async Task<ServiceResponse<GetLecturerScientificResearchDto>> GetLecturerScientificResearchById(int id)
        {
            var response = new ServiceResponse<GetLecturerScientificResearchDto>();
            try
            {
                response.Data = _mapper.Map<GetLecturerScientificResearchDto>(await _context.LecturerScientificResearches.FirstOrDefaultAsync(x => x.ID.Equals(id)));
            }
            catch (Exception ex)
            {
                response.Success = false;
                response.Message = ex.Message;
            }
            return response;
        }

        public async Task<ServiceResponse<IEnumerable<GetLecturerScientificResearchDto>>> GetLecturerScientificResearchs()
        {
            var response = new ServiceResponse<IEnumerable<GetLecturerScientificResearchDto>>();
            try
            {
                response.Data = await _context.LecturerScientificResearches.Select(x => _mapper.Map<GetLecturerScientificResearchDto>(x)).ToListAsync();
            }
            catch (Exception ex)
            {
                response.Success = false;
                response.Message = ex.Message;
            }
            return response;
        }

        public async Task<ServiceResponse<GetLecturerScientificResearchDto>> UpdateLecturerScientificResearch(UpdateLecturerScientificResearchDto update)
        {
            var response = new ServiceResponse<GetLecturerScientificResearchDto>();
            try
            {
                var lecturerScientificResearch = _mapper.Map<LecturerScientificResearch>(update);
                _context.LecturerScientificResearches.Update(lecturerScientificResearch);
                await _context.SaveChangesAsync();
                response.Data = _mapper.Map<GetLecturerScientificResearchDto>(lecturerScientificResearch);
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
