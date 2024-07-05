using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using ValeRegistration.interfaces.accountInterface;

namespace ValeRegistration.controllers.account
{
    [ApiController]
    [Route("api/[controller]")]
    public class AccountController : ControllerBase
    {
        private readonly IAccountRepository _accountRepository;
        public AccountController(IAccountRepository accountRepository)
        {
            _accountRepository = accountRepository;
        }

        [HttpPost("Create Account")]
        public async Task<IActionResult> CreateAccount([FromRoute] Guid customerId)
        {
            try
            {
                var account = await _accountRepository.CreateAccountAsync(customerId);
                return Ok(account);
            }
            
            catch (System.Exception)
            {
                
                throw new Exception("Account could not be created");
            }
        }

        [HttpGet("retrieve all accounts")]
        public async Task<IActionResult> GetAccounts()
        {
            try
            {
                var accounts = await _accountRepository.GetAccounts();
                return Ok(accounts);
            }
            catch (System.Exception)
            {
                
                return BadRequest(new{status ="failed", message ="could not retrieve accounts"});
            }
        }
    }
}