using TinyLedger.Domain.Entities;

namespace TinyLedger.Domain;

public class AccountService
{
    private readonly Dictionary<Guid, Account> _accounts = new();
    private readonly List<Transaction> _transactions = new();

    public Account CreateAccount(string owner)
    {
        var account = new Account(owner);
        _accounts[account.AccountId] = account;

        return account;
    }

    public decimal Balance(Guid accountId)
    {
        return GetAccount(accountId).Balance;
    }

    public void TransferMoney(Guid fromAccountId, Guid toAccountId, decimal amount)
    {
        var from = GetAccount(fromAccountId);
        var to = GetAccount(toAccountId);

        from.Withdraw(amount);
        to.Deposit(amount);

        var transaction = new Transaction(from.AccountId, to.AccountId, amount, TransactionType.Transfer);
        _transactions.Add(transaction);
    }

    public void Deposit(Guid toAccountId, decimal amount)
    {
        var account = GetAccount(toAccountId);
        account.Deposit(amount);

        var tx = new Transaction(null, toAccountId, amount, TransactionType.Deposit);
        _transactions.Add(tx);
    }

    public void Withdraw(Guid fromAccountId, decimal amount)
    {
        var account = GetAccount(fromAccountId);
        account.Withdraw(amount);

        var tx = new Transaction(fromAccountId, null, amount, TransactionType.Withdrawal);
        _transactions.Add(tx);
    }

    public IReadOnlyList<Transaction> GetTransactions(Guid accountId)
    {
        return _transactions.Where(tx => tx.FromAccountId == accountId || tx.ToAccountId == accountId).ToList();
    }

    private Account GetAccount(Guid accountId)
    {
        if (!_accounts.TryGetValue(accountId, out var account))
            throw new KeyNotFoundException("Account not found.");

        return account;
    }

}
