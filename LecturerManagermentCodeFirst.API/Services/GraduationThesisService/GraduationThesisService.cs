using AutoMapper;
using LecturerManagermentCodeFirst.API.Data;
using LecturerManagermentCodeFirst.API.Entities;
using LecturerManagermentCodeFirst.DTO.DTOS.GraduationThesis;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LecturerManagermentCodeFirst.API.Services.GraduationThesisService
{
    public class GraduationThesisService : IGraduationThesisService
    {
        private readonly LecturerManagermentSystemDbContext _context;
        private readonly IMapper _mapper;

        public GraduationThesisService(LecturerManagermentSystemDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }
        public async Task<ServiceResponse<IEnumerable<GetGraduationThesisDto>>> AddGraduationThesis(AddGraduationThesisDto add)
        {
            var response = new ServiceResponse<IEnumerable<GetGraduationThesisDto>>();
            try
            {
                var graduationThesis = _mapper.Map<GraduationThesis>(add);
                _context.GraduationTheses.Add(graduationThesis);
                await _context.SaveChangesAsync();
                response.Data = _context.GraduationTheses.Select(x => _mapper.Map<GetGraduationThesisDto>(x));
            }    
            catch(Exception ex)
            {
                response.Success = false;
                response.Message = ex.Message;
            }
            return response;
        }

        public async Task<ServiceResponse<IEnumerable<GetGraduationThesisDto>>> DeleteGraduationThesis(int id)
        {
            var response = new ServiceResponse<IEnumerable<GetGraduationThesisDto>>();
            try
            {
                var graduationThesis = await _context.GraduationTheses.FirstOrDefaultAsync(x => x.ID.Equals(id));
                _context.GraduationTheses.Remove(graduationThesis);
                await _context.SaveChangesAsync();
                response.Data = _context.GraduationTheses.Select(x => _mapper.Map<GetGraduationThesisDto>(x));
            }
            catch (Exception ex)
            {
                response.Success = false;
                response.Message = ex.Message;
            }
            return response;
        }

        public async Task<ServiceResponse<GetGraduationThesisDto>> GetGraduationThesisById(int id)
        {
            var response = new ServiceResponse<GetGraduationThesisDto>();
            try
            {
                var graduationThesis = await _context.GraduationTheses.FirstOrDefaultAsync(x => x.ID.Equals(id));
                response.Data = _mapper.Map<GetGraduationThesisDto>(graduationThesis);
            }
            catch (Exception ex)
            {
                response.Success = false;
                response.Message = ex.Message;
            }
            return response;
        }

        public async Task<ServiceResponse<IEnumerable<GetGraduationThesisDto>>> GetGraduationThesises()
        {
            var response = new ServiceResponse<IEnumerable<GetGraduationThesisDto>>();
            try
            {
                response.Data = await _context.GraduationTheses.Select(x => _mapper.Map<GetGraduationThesisDto>(x)).ToListAsync();
            }
            catch (Exception ex)
            {
                response.Success = false;
                response.Message = ex.Message;
            }
            return response;
        }

        public async Task<ServiceResponse<GetGraduationThesisDto>> UpdateGraduationThesis(UpdateGraduationThesisDto update)
        {
            var response = new ServiceResponse<GetGraduationThesisDto>();
            try
            {
                var graduationThesis = _mapper.Map<GraduationThesis>(update);
                _context.GraduationTheses.Update(graduationThesis);
                await _context.SaveChangesAsync();
                response.Data = _mapper.Map<GetGraduationThesisDto>(graduationThesis);
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
