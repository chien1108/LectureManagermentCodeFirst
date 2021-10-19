using AutoMapper;
using LecturerManagermentCodeFirst.API.Data;
using LecturerManagermentCodeFirst.API.Entities;
using LecturerManagermentCodeFirst.DTO.DTOS.StandardTime;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LecturerManagermentCodeFirst.API.Services.StandardTimeService
{
    public class StandardTimeService : IStandardTimeService
    {
        private readonly IMapper _mapper;
        private readonly LecturerManagermentSystemDbContext _context;

        public StandardTimeService(IMapper mapper, LecturerManagermentSystemDbContext context)
        {
            _mapper = mapper;
            _context = context;
        }
        public async Task<ServiceResponse<IEnumerable<GetStandardTimeDto>>> AddStandardTime(AddStandardTimeDto add)
        {
            var response = new ServiceResponse<IEnumerable<GetStandardTimeDto>>();
            var standardTime = _mapper.Map<StandardTime>(add);
            _context.StandardTimes.Add(standardTime);
            await _context.SaveChangesAsync();
            response.Data = _context.StandardTimes.Select(x => _mapper.Map<GetStandardTimeDto>(x));
            return response;
        }

        public async Task<ServiceResponse<IEnumerable<GetStandardTimeDto>>> DeleteStandardTime(string name)
        {
            var response = new ServiceResponse<IEnumerable<GetStandardTimeDto>>();
            var standardTime = await _context.StandardTimes.FirstOrDefaultAsync(x => x.Name.ToLower().Equals(name.ToLower()));
            _context.StandardTimes.Remove(standardTime);
            await _context.SaveChangesAsync();
            response.Data = _context.StandardTimes.Select(x => _mapper.Map<GetStandardTimeDto>(x));
            return response;
        }

        public async Task<ServiceResponse<GetStandardTimeDto>> GetStandardTimeByName(string name)
        {
            var response = new ServiceResponse<GetStandardTimeDto>();
            var standardTime = await _context.StandardTimes.FirstOrDefaultAsync(x => x.Name.ToLower().Equals(name.ToLower()));
            response.Data = _mapper.Map<GetStandardTimeDto>(standardTime);
            return response;
        }

        public async Task<ServiceResponse<IEnumerable<GetStandardTimeDto>>> GetStandardTimes()
        {
            var response = new ServiceResponse<IEnumerable<GetStandardTimeDto>>();
            response.Data = await _context.StandardTimes.Select(x => _mapper.Map<GetStandardTimeDto>(x)).ToListAsync();
            return response;
        }

        public async Task<ServiceResponse<GetStandardTimeDto>> UpdateStandardTime(UpdateStandardTimeDto update)
        {
            var response = new ServiceResponse<GetStandardTimeDto>();
            var standardTime = _mapper.Map<StandardTime>(update);
            _context.StandardTimes.Update(standardTime);
            await _context.SaveChangesAsync();
            response.Data = _mapper.Map<GetStandardTimeDto>(standardTime);
            return response;
        }
    }
}
