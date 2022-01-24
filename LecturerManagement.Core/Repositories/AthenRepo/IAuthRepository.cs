using LecturerManagement.Core.Models;
using LecturerManagement.DTOS.Account;
using System;
using System.Threading.Tasks;

namespace LecturerManagement.Core.Repositories.AuthenRepo
{
    public interface IAuthRepository
    {
        Task<ServiceResponse<Tuple<string, string>>> Register(AccountResgisterDto accountRegisterDto);
        Task<ServiceResponse<string>> Login(string username, string password);
    }
}