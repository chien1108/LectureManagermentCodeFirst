using LecturerManagermentCodeFirst.API.Services.AccountService;
using LecturerManagermentCodeFirst.DTO.DTOS.Account;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LecturerManagermentCodeFirst.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AccountController : ControllerBase
    {
        private readonly IAccountService _accountService;

        public AccountController(IAccountService accountService)
        {
            _accountService = accountService;
        }

        [HttpGet("{username}")]
        public async Task<IActionResult> GetAccountByUsername(string username)
        {
            var response = await _accountService.GetAccountByUsername(username);
            if(!response.Success)
            {
                return BadRequest(response);
            }    
            return Ok(response);
        }

        [HttpDelete("{username}")]
        public async Task<IActionResult> DeleteAccount(string username)
        {
            var response = await _accountService.DeleteAccount(username);
            if(!response.Success)
            {
                return BadRequest(response);
            }    
            return Ok(response);
        }

        [HttpPut]
        public async Task<IActionResult> UpdateAccount(UpdateAccountDto updateAccountDto)
        {
            var response = await _accountService.UpdateAccount(updateAccountDto);
            if(!response.Success)
            {
                return BadRequest(response);
            }    
            return Ok(response);
        }


    }
}
