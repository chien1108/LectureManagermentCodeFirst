using System.Threading.Tasks;
using LecturerManagermentCodeFirst.DTO.DTOS.Account;

namespace LecturerManagermentCodeFirst.API.Services.AccountService
{
    public interface IAccountService
    {

        //RUD
        Task<ServiceResponse<GetAccountDto>> GetAccountByUsername(string username);
        Task<ServiceResponse<GetAccountDto>> UpdateAccount(UpdateAccountDto updateAccount);
        Task<ServiceResponse<string>> DeleteAccount(string username);
    }
}