namespace TinyLedger.Domain.Entities;

public enum TransactionType
{
    Deposit,      // From: null, To: Account
    Withdrawal,   // From: Account, To: null
    Transfer      // From: Account A, To: Account B
}