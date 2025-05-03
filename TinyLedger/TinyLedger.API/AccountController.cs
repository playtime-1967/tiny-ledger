using Microsoft.AspNetCore.Mvc;
using TinyLedger.Application;
using TinyLedger.Domain.Entities;

namespace TinyLedger.API;

[ApiController]
[Route("api/account")]
public class AccountController : ControllerBase
{

    private readonly AccountService _accountService;

    public AccountController(AccountService accountService)
    {
        _accountService = accountService;
    }

    [HttpPost("create")]
    public Account CreateAccount([FromBody] CreateAccountRequest request)
    {
        return _accountService.CreateAccount(request.Owner);
    }

    [HttpGet("balance/{accountId}")]
    public decimal Balance(Guid accountId)
    {
        return _accountService.Balance(accountId);
    }
}
