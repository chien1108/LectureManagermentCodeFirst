using AutoMapper;
using LecturerManagermentCodeFirst.API.Entities;
using LecturerManagermentCodeFirst.API.Services;
using LecturerManagermentCodeFirst.DTO.DTOS.Account;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;

namespace LecturerManagermentCodeFirst.API.Data
{
    public class AuthRepository : IAuthRepository
    {
        private readonly LecturerManagermentSystemDbContext _context;
        private readonly IConfiguration _configuration;
        private readonly IMapper _mapper;

        public AuthRepository(LecturerManagermentSystemDbContext context, IConfiguration configuration, IMapper mapper)
        {
            _configuration = configuration;
            _mapper = mapper;
            _context = context;
        }

        public async Task<ServiceResponse<string>> Login(string username, string password)
        {
            var response = new ServiceResponse<string>();
            var user = await _context.Accounts.FirstOrDefaultAsync(x => x.UserName.ToLower().Equals(username.ToLower()));
            if (user == null)
            {
                response.Success = false;
                response.Message = "User not found.";
            }
            else if (!VerifyPasswordHash(password, user.PasswordHash, user.PasswordSalt))
            {
                response.Success = false;
                response.Message = "Wrong password.";
            }
            else
            {
                response.Data = CreateToken(user);
            }

            return response;
        }

        public async Task<ServiceResponse<string>> Register(AccountResgisterDto accountRegisterDto)
        {
            ServiceResponse<string> response = new ServiceResponse<string>();
            try
            {
                Account account = new Account();
                Lecturer lecturer = _mapper.Map<Lecturer>(accountRegisterDto);
                account.UserName = CreateUserName(accountRegisterDto.FullName);

                var password = CreateRandomPasswordWithRandomLength();

                CreatePasswordHash(password, out byte[] passwordHash, out byte[] passwordSalt);

                account.PasswordHash = passwordHash;
                account.PasswordSalt = passwordSalt;
                account.Lecturer = lecturer;
                account.Permission = DTO.Enum.Permission.Lecturer;

                _context.Accounts.Add(account);
                _context.Lecturers.Add(lecturer);
                await _context.SaveChangesAsync();
                response.Data = password;

            }
            catch(Exception ex)
            {
                response.Success = false;
                response.Message = ex.Message;
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
                new Claim(ClaimTypes.NameIdentifier, user.ID.ToString()),
                new Claim(ClaimTypes.Name, user.UserName)
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

        private static string CreateRandomPasswordWithRandomLength()
        {
            // Create a string of characters, numbers, special characters that allowed in the password  
            string validChars = "ABCDEFGHJKLMNOPQRSTUVWXYZabcdefghijklmnopqrstuvwxyz0123456789!@#$%^&*?_-";
            Random random = new Random();

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
        private string CreateUserName(string Fullname)
        {
            string[] name = Fullname.Split(' ');
            var usernames = _context.Accounts.Select(x => x.UserName).ToList();
            string username = name[name.Length - 1].ToLower();
            for(int i = 0; i < name.Length - 1; i++)
            {
                username += name[i].Substring(0, 1).ToLower();
            }
            int checkToIncrease = usernames.Count(x => x.Contains(username));
            if (checkToIncrease != 0)
            {
                username += checkToIncrease;
            }    
            return username;
        }
    }
}
