using TinyLedger.Domain.Entities;

namespace TinyLedger.Application;

public class AccountService
{
    private readonly Dictionary<Guid, Account> _accounts = new();

    public Account CreateAccount(string owner)
    {
        var account = new Account(owner);
        _accounts[account.AccountId] = account;

        return account;
    }

    public decimal Balance(Guid accountId)
    {
        return GetAccount(accountId).Balnace;
    }

    private Account GetAccount(Guid accountId)
    {
        if (!_accounts.TryGetValue(accountId, out var account))
        {
            throw new KeyNotFoundException("Account not found.");
        }

        return account;
    }

}
