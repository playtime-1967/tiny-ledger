namespace TinyLedger.Domain.Entities;

public class Account
{
    public Guid AccountId { get; private set; }
    public string Owner { get; private set; }
    public decimal Balance { get; private set; }
    public DateTime CreatedAt { get; private set; }

    private Account()
    {
        AccountId = Guid.NewGuid();
        CreatedAt = DateTime.UtcNow;
    }

    public Account(string owner) : this()
    {
        if (string.IsNullOrWhiteSpace(owner))
            throw new ArgumentException("Owner is required.");

        Owner = owner;
    }

    public void Deposit(decimal amount)
    {
        if (amount <= 0)
            throw new ArgumentException("Amount must be positive.");

        Balance += amount;
    }

    public void Withdraw(decimal amount)
    {
        if (amount <= 0)
            throw new ArgumentException("Amount must be positive.");

        if (Balance < amount)
            throw new InvalidOperationException("Insufficient balance.");

        Balance -= amount;
    }

}
