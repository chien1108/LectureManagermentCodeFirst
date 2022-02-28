using AutoMapper;
using LecturerManagement.Core.Contracts;
using LecturerManagement.Core.Models;
using LecturerManagement.Core.Models.Entities;
using LecturerManagement.DTOS.Account;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Security.Claims;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace LecturerManagement.Services.AccountService
{
    public class AccountService : IAccountService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;
        private readonly IHttpContextAccessor _httpContext;

        public AccountService(IMapper mapper, IHttpContextAccessor httpContext, IUnitOfWork unitOfWork)
        {
            _mapper = mapper;
            _httpContext = httpContext;
            _unitOfWork = unitOfWork;
        }
        public async Task<ServiceResponse<string>> DeleteAccount(string username)
        {
            var response = new ServiceResponse<string>();
            var account = await _unitOfWork.Accounts.FindByConditionAsync(x => x.UserName.ToLower().Equals(username.ToLower()));
            if (account == null)
            {
                response.Success = false;
                response.Message = "Account is not exist";
            }
            _unitOfWork.Accounts.Delete(account);
            if (await _unitOfWork.Save())
            {
                response.Message = "Account was deleted";
            }
            else
            {
                response.Message = "Account was not deleted";
            }
            return response;
        }

        public async Task<ServiceResponse<GetAccountDto>> GetAccountByUsername(string username)
        {
            var response = new ServiceResponse<GetAccountDto>();
            ////var account = await _context.Accounts.Include(x => x.Lecturer).FirstOrDefaultAsync(x => x.UserName.ToLower().Equals(username.ToLower()));
            var account = await _unitOfWork.Accounts.FindByConditionAsync(expression: (x => x.UserName.ToLower().Equals(username.ToLower())), includes: new List<string> { "Lecturer" });
            if (account == null)
            {
                response.Success = false;
                response.Message = "Account is not exist";
            }
            response.Data = _mapper.Map<GetAccountDto>(account);
            return response;
        }

        public async Task<ServiceResponse<GetAccountDto>> UpdateAccount(string username, UpdateAccountDto updateAccount)
        {
            var response = new ServiceResponse<GetAccountDto>();
            try
            {
                var account = await _unitOfWork.Accounts.FindByConditionAsync(expression: (x => x.UserName.ToLower().Trim().Equals(username.ToLower().Trim())), includes: new List<string> { "Lecturer" });
                if (account == null)
                {
                    response.Success = false;
                    response.Message = "Account is not exist";
                }
                else
                {
                    if (_httpContext.HttpContext.User.FindFirst(ClaimTypes.Email).Value.Equals("Admin"))
                    {
                        UpdateForAdmin(ref updateAccount, ref account);
                    }
                    else
                    {
                        UpdateForLecturer(ref updateAccount, ref account);
                    }
                }
                if (await _unitOfWork.Save())
                {
                    response.Message = "Account was updated";
                }
                else
                {
                    response.Message = "Account was not updated";
                }
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

        public async Task<ServiceResponse<string>> Delete(string userName)
        {
            try
            {
                var accountFromDb = await Find(x => x.UserName.ToLower().Trim() == userName.ToLower().Trim());
                var map = _mapper.Map<Account>(accountFromDb);
                if (accountFromDb != null)
                {
                    _unitOfWork.Accounts.Delete(map);
                    if (!await SaveChange())
                    {
                        return new ServiceResponse<string> { Success = false, Message = "Error when delete Account" };
                    }
                    return new ServiceResponse<string> { Success = true, Message = "Delete Advanced Account" };
                }
                else
                {
                    return new ServiceResponse<string> { Success = false, Message = "Not Found Account" };
                }
            }
            catch (Exception ex)
            {

                return new ServiceResponse<string> { Success = false, Message = ex.Message };
            }
        }

        public async Task<ServiceResponse<UpdateAccountDto>> Update(UpdateAccountDto updateAccount)
        {
            try
            {
                var task = _mapper.Map<AdvancedLearning>(updateAccount);
                _unitOfWork.AdvancedLearnings.Update(task);
                if (!await SaveChange())
                {
                    return new ServiceResponse<UpdateAccountDto> { Success = false, Message = "Error when update Account" };
                }
                return new ServiceResponse<UpdateAccountDto> { Success = true, Message = "Update Account Success" };

            }
            catch (Exception ex)
            {
                return new ServiceResponse<UpdateAccountDto> { Success = false, Message = ex.Message };
            }
        }

        public async Task<bool> IsExisted(Expression<Func<Account, bool>> expression = null)
        {
            var isExist = await _unitOfWork.Accounts.FindByConditionAsync(expression);
            if (isExist == null)
            {
                return false;
            }
            return true;
        }

        public async Task<ICollection<GetAccountDto>> FindAll(Expression<Func<Account, bool>> expression = null, Func<IQueryable<Account>, IOrderedQueryable<Account>> orderBy = null, List<string> includes = null)
        => _mapper.Map<ICollection<GetAccountDto>>(await _unitOfWork.Accounts.FindAllAsync(expression, orderBy, includes));

        public async Task<GetAccountDto> Find(Expression<Func<Account, bool>> expression = null, List<string> includes = null)
        => _mapper.Map<GetAccountDto>(await _unitOfWork.Accounts.FindByConditionAsync(expression, includes));

        public async Task<bool> SaveChange()
        => await _unitOfWork.Accounts.Save();
    }
}
