using AutoMapper;
using LecturerManagement.Core.Contracts;
using LecturerManagement.Core.Models;
using LecturerManagement.Core.Models.Entities;
using LecturerManagement.DTOS.Account;
using LecturerManagement.DTOS.Modules.Enums;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
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
        private readonly IConfiguration _configuration;
        private readonly IMapper _mapper;
        private readonly IHttpContextAccessor _httpContext;

        public AccountService(IMapper mapper, IHttpContextAccessor httpContext, IUnitOfWork unitOfWork, IConfiguration configuration)
        {
            _mapper = mapper;
            _httpContext = httpContext;
            _unitOfWork = unitOfWork;
            _configuration = configuration;
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
                        UpdateForAdmin(updateAccount, account);
                    }
                    else
                    {
                        UpdateForLecturer(updateAccount, account);
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

        private void UpdateForAdmin(UpdateAccountDto updateAccountDto, Account account)
        {
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

        private void UpdateForLecturer(UpdateAccountDto updateAccountDto, Account account)
        {
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

        public async Task<ServiceResponse<string>> DeleteAccountByCondition(Expression<Func<Account, bool>> expression = null)
        {
            try
            {
                var accountFromDb = await _unitOfWork.Accounts.FindByConditionAsync(expression);
                if (accountFromDb != null)
                {
                    _unitOfWork.Accounts.Delete(accountFromDb);
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

        public async Task<ServiceResponse<UpdateAccountDto>> Update(UpdateAccountDto updateAccount, Expression<Func<Account, bool>> expression = null)
        {
            try
            {
                var accountFromDb = await _unitOfWork.Accounts.FindByConditionAsync(expression);

                accountFromDb.Permission = updateAccount.Permission;
                accountFromDb.Lecturer.YearStartWork = updateAccount.YearStartWork;
                accountFromDb.Lecturer.Status = updateAccount.Status;
                accountFromDb.Lecturer.Portrait = updateAccount.Portrait;
                accountFromDb.Lecturer.PhoneNumber = updateAccount.PhoneNumber;
                accountFromDb.Lecturer.IdentityCardNumber = updateAccount.IdentityCardNumber;
                accountFromDb.Lecturer.Gender = updateAccount.Gender;
                accountFromDb.Lecturer.FullName = updateAccount.FullName;
                accountFromDb.Lecturer.Email = updateAccount.Email;
                accountFromDb.Lecturer.Description = updateAccount.Description;
                accountFromDb.Lecturer.BirthDate = updateAccount.BirthDate;
                accountFromDb.Lecturer.Address = updateAccount.Address;
                accountFromDb.Lecturer.AcademicLevel = updateAccount.AcademicLevel;

                _unitOfWork.Accounts.Update(accountFromDb);
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

        public async Task<ServiceResponse<IEnumerable<GetAccountDto>>> FindAllAccount(Expression<Func<Account, bool>> expression = null, Func<IQueryable<Account>, IOrderedQueryable<Account>> orderBy = null, List<string> includes = null)
        {
            var listAccoutnFromDb = await _unitOfWork.Accounts.FindAllAsync(expression, orderBy, includes);

            if (listAccoutnFromDb.Count() != 0)
            {
                return new() { Success = true, Message = "Get list Account Success", Data = _mapper.Map<IEnumerable<GetAccountDto>>(listAccoutnFromDb) };
            }
            return new() { Message = "lits Account is not availble", Success = false };
        }

        public async Task<ServiceResponse<GetAccountDto>> FindAccountByCondition(Expression<Func<Account, bool>> expression = null, List<string> includes = null)
        {
            var accountFromDb = await _unitOfWork.Accounts.FindByConditionAsync(expression, includes);
            if (accountFromDb != null)
            {
                return new() { Success = true, Message = "Get Account from DB Success", Data = _mapper.Map<GetAccountDto>(accountFromDb) };
            }

            return new() { Message = "Account is not exist", Success = false };
        }

        public async Task<bool> SaveChange()
        => await _unitOfWork.Accounts.Save();

        public async Task<ServiceResponse<Tuple<string, string>>> Register(AccountResgisterDto accountRegisterDto)
        {
            try
            {
                var password = CreateRandomPasswordWithRandomLength();
                CreatePasswordHash(password, out byte[] passwordHash, out byte[] passwordSalt);
                Account account = new()
                {
                    Id = GenerateUniqueID(),
                    PasswordHash = passwordHash,
                    PasswordSalt = passwordSalt,
                    Permission = Permission.Lecturer,
                    DateCreated = DateTime.Now
                };
                account.UserName = await CreateUserName(accountRegisterDto.FullName);
                Lecturer lecturer = new()
                {
                    Id = GenerateUniqueID(),
                    FullName = accountRegisterDto.FullName,
                    Gender = accountRegisterDto.Gender,
                    BirthDate = accountRegisterDto.BirthDate,
                    IdentityCardNumber = accountRegisterDto.IdentityCardNumber,
                    Portrait = accountRegisterDto.Portrait,
                    Email = account.UserName.ToString() + "@utt.edu.vn",
                    YearStartWork = DateTime.Now.Year.ToString(),
                    PhoneNumber = accountRegisterDto.PhoneNumber,
                    Address = accountRegisterDto.Address,
                    AcademicLevel = accountRegisterDto.AcademicLevel,
                };
                account.Lecturer = lecturer;

                await _unitOfWork.Accounts.Create(account);
                await _unitOfWork.Lecturers.Create(lecturer);
                if (await _unitOfWork.Save())
                {
                    return new() { Data = new Tuple<string, string>("Password: " + password.ToString(), "Account: " + account.UserName.ToString()), Success = true, Message = "Create Account Success" };
                }
                else
                {
                    return new() { Message = "Please Check The Information", Success = false };
                }
            }
            catch (Exception ex)
            {
                return new()
                {
                    Message = ex.Message,
                    Success = false
                };
            }
        }

        public async Task<ServiceResponse<string>> Login(string username, string password)
        {
            var response = new ServiceResponse<string>();
            var user = await _unitOfWork.Accounts.FindByConditionAsync(x => x.UserName.ToLower().Equals(username.ToLower()));
            if (user == null)
            {
                response = new() { Message = "User not found!", Success = false };
            }
            else if (!VerifyPasswordHash(password, user.PasswordHash, user.PasswordSalt))
            {
                response = new() { Message = "Wrong password!", Success = false };
            }
            else
            {
                response = new() { Data = CreateToken(user), Message = "Login Success", Success = true };
            }

            return response;
        }

        public async Task<ServiceResponse<string>> ChangePassword(string username, string newPassword)
        {
            var response = new ServiceResponse<string>();
            var user = await _unitOfWork.Accounts.FindByConditionAsync(x => x.UserName.ToLower().Equals(username.ToLower()));
            if (user == null)
            {
                response = new() { Message = "User not found!", Success = false };
            }
            else
            {
                CreatePasswordHash(newPassword, out byte[] passwordHash, out byte[] passwordSalt);
                user.PasswordHash = passwordHash;
                user.PasswordSalt = passwordSalt;
                user.ModifiedDate = DateTime.Now;
                if (await _unitOfWork.Save())
                {
                    response = new() { Success = true, Message = "Change Password Success" };
                }
                else
                {
                    response = new() { Message = "An error occurred. Please try again later", Success = false };
                }
            }

            return response;
        }

        private void CreatePasswordHash(string password, out byte[] passwordHash, out byte[] passwordSalt)
        {
            using (var hmac = new System.Security.Cryptography.HMACSHA512())
            {
                passwordSalt = hmac.Key;
                passwordHash = hmac.ComputeHash(System.Text.Encoding.UTF8.GetBytes(password));
            }
        }

        private bool VerifyPasswordHash(string password, byte[] passwordHash, byte[] passwordSalt)
        {
            using (var hmac = new System.Security.Cryptography.HMACSHA512(passwordSalt))
            {
                var computedHash = hmac.ComputeHash(System.Text.Encoding.UTF8.GetBytes(password));
                for (int i = 0; i < computedHash.Length; i++)
                {
                    if (computedHash[i] != passwordHash[i])
                    {
                        return false;
                    }
                }
                return true;
            }
        }

        private string CreateToken(Account user)
        {
            var claims = new List<Claim>
            {
                new Claim(ClaimTypes.NameIdentifier, user.Id.ToString()),
                new Claim(ClaimTypes.Name, user.UserName),
                new Claim(ClaimTypes.Role, user.Permission.ToString())
            };

            var key = new SymmetricSecurityKey(System.Text.Encoding.UTF8.GetBytes(_configuration.GetSection("AppSettings:Token").Value));

            var creds = new SigningCredentials(key, SecurityAlgorithms.HmacSha512Signature);

            var tokendDescriptor = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(claims),
                Expires = System.DateTime.Now.AddDays(1),
                SigningCredentials = creds
            };

            var tokenHandler = new JwtSecurityTokenHandler();
            var token = tokenHandler.CreateToken(tokendDescriptor);

            return tokenHandler.WriteToken(token);
        }

        private string CreateRandomPasswordWithRandomLength()
        {
            // Create a string of characters, numbers, special characters that allowed in the password
            string validChars = "ABCDEFGHJKLMNOPQRSTUVWXYZabcdefghijklmnopqrstuvwxyz0123456789!@#$%^&*?_-";
            Random random = new();

            // Minimum size 8. Max size is number of all allowed chars.
            int size = random.Next(8, validChars.Length);

            // Select one random character at a time from the string
            // and create an array of chars
            char[] chars = new char[size];
            for (int i = 0; i < size; i++)
            {
                chars[i] = validChars[random.Next(0, validChars.Length)];
            }
            return new string(chars);
        }

        //generate username
        private async Task<string> CreateUserName(string Fullname)
        {
            string[] name = Fullname.Split(' ');
            var usernames = await _unitOfWork.Accounts.FindAllAsync();
            var length = name.Length;
            StringBuilder username = new();
            username.Append(name[length - 1].Substring(0, 1).ToUpper() + name[length - 1].Substring(1, name[length - 1].Length - 1).ToLower());
            for (int i = 0; i < length - 1; i++)
            {
                username.Append(name[i].Substring(0, 1).ToUpper());
            }
            int checkToIncrease = usernames.Count(x => x.UserName.Trim().ToLower().Contains(username.ToString().ToLower().Trim()));
            if (checkToIncrease != 0)
            {
                username.Append(checkToIncrease);
            }
            return username.ToString();
        }

        private string GenerateUniqueID(int _characterLength = 11)
        {
            StringBuilder _builder = new();
            Enumerable
                .Range(65, 26)
                .Select(e => ((char)e).ToString())
                .Concat(Enumerable.Range(97, 26).Select(e => ((char)e).ToString()))
                .Concat(Enumerable.Range(0, 10).Select(e => e.ToString()))
                .OrderBy(e => Guid.NewGuid())
                .Take(_characterLength)
                .ToList().ForEach(e => _builder.Append(e));
            return _builder.ToString();
        }
    }
}