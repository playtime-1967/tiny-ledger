using Microsoft.AspNetCore.Mvc;
using TinyLedger.Domain;
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

    [HttpPost("deposit")]
    public void Deposit([FromBody] DepositRequest request)
    {
        _accountService.Deposit(request.ToAccountId, request.Amount);
    }

    [HttpPost("transfer-money")]
    public void TransferMoney([FromBody] TransferMoneyRequest request)
    {
        _accountService.TransferMoney(request.FromAccountId, request.ToAccountId, request.Amount);
    }
    
}
