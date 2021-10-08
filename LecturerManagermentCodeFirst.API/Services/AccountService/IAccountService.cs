using System.Threading.Tasks;
using LecturerManagermentCodeFirst.DTO.DTOS.Account;

namespace LecturerManagermentCodeFirst.API.Services.AccountService
{
    public interface IAccountService
    {

        //RUD
        Task<ServiceResponse<GetAccountDto>> GetAccountByID(int id);
        Task<ServiceResponse<GetAccountDto>> UpdateAccount(UpdateAccountDto updateAccount);
        Task<ServiceResponse<string>> DeleteAccount(int id);
    }
}