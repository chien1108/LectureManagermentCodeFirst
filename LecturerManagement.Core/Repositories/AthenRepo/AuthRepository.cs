using LecturerManagement.Core.Contracts;
using LecturerManagement.Core.Models;
using LecturerManagement.Core.Models.Entities;
using LecturerManagement.DTOS.Account;
using LecturerManagement.DTOS.Modules.Enums;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace LecturerManagement.Core.Repositories.AuthenRepo
{
    public class AuthRepository : IAuthRepository
    {
        private readonly IConfiguration _configuration;
        private readonly IUnitOfWork _unitOfWork;

        public AuthRepository(IConfiguration configuration, IUnitOfWork unitOfWork)
        {
            _configuration = configuration;
            _unitOfWork = unitOfWork;
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
