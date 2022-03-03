using LecturerManagement.Core.Models;
using LecturerManagement.Core.Repositories.AuthenRepo;
using LecturerManagement.DTOS.Account;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace LecturerManagement.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        private readonly IAuthRepository _authRepo;
        public AuthController(IAuthRepository authRepo)
        {
            _authRepo = authRepo;
        }

        /// <summary>
        /// Đăng Ký Tài Khoản
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        [HttpPost("Register")]
        public async Task<IActionResult> Register(AccountResgisterDto request)
        {
            var response = await _authRepo.Register(request);

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
            var response = await _authRepo.Login(
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
            var response = await _authRepo.ChangePassword(userName, newPassword);

            if (!response.Success)
            {
                return BadRequest(response);
            }

            return Ok(response);
        }
    }
}
