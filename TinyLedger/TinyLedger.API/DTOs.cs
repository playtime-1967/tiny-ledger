﻿namespace TinyLedger.API;

public class CreateAccountRequest
{
    public required string Owner { get; set; }
}

public class TransferMoneyRequest
{
    public Guid FromAccountId { get; set; }
    public Guid ToAccountId { get; set; }
    public decimal Amount { get; set; }
}

public class DepositRequest
{
    public Guid ToAccountId { get; set; }
    public decimal Amount { get; set; }
}

public class WithdrawRequest
{
    public Guid FromAccountId { get; set; }
    public decimal Amount { get; set; }
}
