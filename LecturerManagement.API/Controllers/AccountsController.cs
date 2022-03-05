using LecturerManagement.Core.Models;
using LecturerManagement.DTOS.Account;
using LecturerManagement.Services.AccountService;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace LecturerManagement.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AccountsController : ControllerBase
    {
        private readonly IAccountService _accountService;

        public AccountsController(IAccountService accountService)
        {
            _accountService = accountService;
        }

        /// <summary>
        /// Đăng Ký Tài Khoản
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        [HttpPost("Register")]
        public async Task<IActionResult> Register(AccountResgisterDto request)
        {
            var response = await _accountService.Register(request);

            if (!response.Success)
            {
                return BadRequest(response);
            }

            return Ok(response);
        }

        /// <summary>
        /// Đăng Nhập
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        [HttpPost("Login")]
        public async Task<ActionResult<ServiceResponse<string>>> Login(AccountLoginDto request)
        {
            var response = await _accountService.Login(
                request.Username, request.Password
            );

            if (!response.Success)
            {
                return BadRequest(response);
            }

            return Ok(response);
        }

        /// <summary>
        /// Đổi Mật Khẩu
        /// </summary>
        /// <param name="userName"></param>
        /// <param name="newPassword"></param>
        /// <returns></returns>
        [Authorize]
        [HttpPut("ChangePassword")]
        public async Task<ActionResult<ServiceResponse<string>>> ChangePassword(string userName, string newPassword)
        {
            var response = await _accountService.ChangePassword(userName, newPassword);

            if (!response.Success)
            {
                return BadRequest(response);
            }

            return Ok(response);
        }


        /// <summary>
        /// Controller Lấy Account theo username
        /// </summary>
        /// <param name="username">Username dùng để lấy ra account</param>
        /// <returns></returns>
        [Authorize(Roles = "Admin")]
        [HttpGet("{username}")]
        public async Task<ActionResult<ServiceResponse<GetAccountDto>>> GetAccountByUsername(string username)
        {
            var response = await _accountService.GetAccountByUsername(username);
            if (!response.Success)
            {
                return BadRequest(response);
            }
            return Ok(response);
        }

        /// <summary>
        /// Controller Xoá Account theo username
        /// </summary>
        /// <param name="username">Username dùng để xoá account</param>
        /// <returns></returns>
        [Authorize(Roles = "Admin")]
        [HttpDelete("{username}")]
        public async Task<IActionResult> DeleteAccount(string username)
        {
            var response = await _accountService.DeleteAccount(username);
            if (!response.Success)
            {
                return BadRequest(response);
            }
            return Ok(response);
        }
        /// <summary>
        /// Controller sửa thông tin tài khoản theo username
        /// </summary>
        /// <param name="username"></param>
        /// <param name="updateAccountDto"></param>
        /// <returns></returns>
        [Authorize]
        [HttpPut("{username}")]
        public async Task<IActionResult> UpdateAccount(string username, UpdateAccountDto updateAccountDto)
        {
            var response = await _accountService.UpdateAccount(username, updateAccountDto);
            if (!response.Success)
            {
                return BadRequest(response);
            }
            return Ok(response);
        }
    }
}