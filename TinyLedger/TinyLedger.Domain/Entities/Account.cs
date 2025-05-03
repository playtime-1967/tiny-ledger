using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TinyLedger.Domain.Entities;

public class Account
{
    public Guid AccountId { get; private set; }
    public string Owner { get; private set; }
    public decimal Balnace { get; private set; }
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

}
