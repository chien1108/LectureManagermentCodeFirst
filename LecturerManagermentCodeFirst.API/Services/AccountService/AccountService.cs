using AutoMapper;
using LecturerManagermentCodeFirst.API.Data;
using LecturerManagermentCodeFirst.DTO.DTOS.Account;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Security.Cryptography;
using System.Text;
using Microsoft.AspNetCore.Http;
using System.Security.Claims;
using LecturerManagermentCodeFirst.API.Entities;

namespace LecturerManagermentCodeFirst.API.Services.AccountService
{
    public class AccountService : IAccountService
    {
        private readonly LecturerManagermentSystemDbContext _context;
        private readonly IMapper _mapper;
        private readonly IHttpContextAccessor _httpContext;

        public AccountService(LecturerManagermentSystemDbContext context, IMapper mapper, IHttpContextAccessor httpContext)
        {
            _context = context;
            _mapper = mapper;
            _httpContext = httpContext;
        }
        public async Task<ServiceResponse<string>> DeleteAccount(string username)
        {
            var response = new ServiceResponse<string>();
            var account = await _context.Accounts.FirstOrDefaultAsync(x => x.UserName.ToLower().Equals(username.ToLower()));
            if (account == null)
            {
                response.Success = false;
                response.Message = "account not exist";
            }
            _context.Accounts.Remove(account);
            await _context.SaveChangesAsync();
            response.Data = "account deleted";
            return response;
        }

        public async Task<ServiceResponse<GetAccountDto>> GetAccountByUsername(string username)
        {
            var response = new ServiceResponse<GetAccountDto>();
            var account = await _context.Accounts.Include(x => x.Lecturer).FirstOrDefaultAsync(x => x.UserName.ToLower().Equals(username.ToLower()));
            if (account == null)
            {
                response.Success = false;
                response.Message = "account not exist";
            }
            response.Data = _mapper.Map<GetAccountDto>(account);
            return response;
        }

        public async Task<ServiceResponse<GetAccountDto>> UpdateAccount(UpdateAccountDto updateAccount)
        {
            var response = new ServiceResponse<GetAccountDto>();
            try
            {
                var account = await _context.Accounts.Include(x => x.Lecturer).FirstOrDefaultAsync(x => x.UserName.ToLower().Equals(updateAccount.Username.ToLower()));
                if (account == null)
                {
                    response.Success = false;
                    response.Message = "account not exist";
                }
                else
                {
                    if(_httpContext.HttpContext.User.FindFirstValue(ClaimTypes.Role).Equals("Admin"))
                    {
                        UpdateForAdmin(ref updateAccount, ref account);
                    }    
                    else
                    {
                        UpdateForLecturer(ref updateAccount, ref account);
                    }    
                }
                await _context.SaveChangesAsync();
                response.Data = _mapper.Map<GetAccountDto>(account);
            }
            catch (Exception ex)
            {
                response.Success = false;
                response.Message = ex.Message;
            }
            return response;
        }

        private void UpdateForAdmin(ref UpdateAccountDto updateAccountDto, ref Account account)
        {
            account.DateCreated = updateAccountDto.DateCreated;
            CreatePasswordHash(updateAccountDto.Password, out byte[] PasswordHash, account.PasswordSalt);
            account.PasswordHash = PasswordHash;
            account.Permission = updateAccountDto.Permission;
            account.Lecturer.YearStartWork = updateAccountDto.YearStartWork;
            account.Lecturer.Status = updateAccountDto.Status;
            account.Lecturer.Portrait = updateAccountDto.Portrait;
            account.Lecturer.PhoneNumber = updateAccountDto.PhoneNumber;
            account.Lecturer.IdentityCardNumber = updateAccountDto.IdentityCardNumber;
            account.Lecturer.Gender = updateAccountDto.Gender;
            account.Lecturer.FullName = updateAccountDto.FullName;
            account.Lecturer.Email = updateAccountDto.Email;
            account.Lecturer.Description = updateAccountDto.Description;
            account.Lecturer.BirthDate = updateAccountDto.BirthDate;
            account.Lecturer.Address = updateAccountDto.Address;
            account.Lecturer.AcademicLevel = updateAccountDto.AcademicLevel;
        }

        private void UpdateForLecturer(ref UpdateAccountDto updateAccountDto, ref Account account)
        {
            account.DateCreated = updateAccountDto.DateCreated;
            CreatePasswordHash(updateAccountDto.Password, out byte[] PasswordHash, account.PasswordSalt);
            account.PasswordHash = PasswordHash;
            account.Lecturer.YearStartWork = updateAccountDto.YearStartWork;
            account.Lecturer.Portrait = updateAccountDto.Portrait;
            account.Lecturer.PhoneNumber = updateAccountDto.PhoneNumber;
            account.Lecturer.IdentityCardNumber = updateAccountDto.IdentityCardNumber;
            account.Lecturer.Gender = updateAccountDto.Gender;
            account.Lecturer.FullName = updateAccountDto.FullName;
            account.Lecturer.Email = updateAccountDto.Email;
            account.Lecturer.Description = updateAccountDto.Description;
            account.Lecturer.BirthDate = updateAccountDto.BirthDate;
            account.Lecturer.Address = updateAccountDto.Address;
            account.Lecturer.AcademicLevel = updateAccountDto.AcademicLevel;
        }

        private void CreatePasswordHash(string password, out byte[] passwordHash, byte[] passwordSalt)
        {
            var hmac = new HMACSHA512(passwordSalt);
            passwordHash = hmac.ComputeHash(Encoding.UTF8.GetBytes(password));
        }
    }
}
