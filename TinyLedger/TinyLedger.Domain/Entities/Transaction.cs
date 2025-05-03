namespace TinyLedger.Domain.Entities;

public class Transaction
{
    public Guid TransactionId { get; private set; }
    public Guid? FromAccountId { get; private set; }
    public Guid? ToAccountId { get; private set; }
    public decimal Amount { get; private set; }
    public TransactionType TransactionType { get; private set; }
    public DateTime Timestamp { get; private set; }

    private Transaction()
    {
        TransactionId = Guid.NewGuid();
        Timestamp = DateTime.UtcNow;
    }

    public Transaction(Guid? fromAccountId, Guid? toAccountId, decimal amount, TransactionType transactionType) : this()
    {
        if (amount <= 0)
            throw new ArgumentException("Amount must be positive.");

        ValidateTransactionType(fromAccountId, toAccountId, transactionType);
        FromAccountId = fromAccountId;
        ToAccountId = toAccountId;
        Amount = amount;
        TransactionType = transactionType;
    }

    private void ValidateTransactionType(Guid? from, Guid? to, TransactionType transactionType)
    {
        switch (transactionType)
        {
            case TransactionType.Deposit:
                if (to == null)
                    throw new ArgumentException("Deposit must have a destination account.");
                break;

            case TransactionType.Withdrawal:
                if (from == null)
                    throw new ArgumentException("Withdrawal must have a source account.");
                break;

            case TransactionType.Transfer:
                if (from == null || to == null)
                    throw new ArgumentException("Transfer must have both source and destination accounts.");
                if (from == to)
                    throw new ArgumentException("Cannot transfer to the same account.");
                break;

            default:
                throw new ArgumentOutOfRangeException(nameof(transactionType), "Unsupported transaction type.");
        }
    }
}
