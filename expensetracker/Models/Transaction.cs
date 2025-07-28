using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace expensetracker.Models
{
    public enum TransactionType
{
    Credit,  // Money In
    Debit,   // Money Out
    Debt     // Borrowed money
}

public class Transaction
{
    public int Id { get; set; }
    public DateTime Date { get; set; } = DateTime.Now;
    public string Title { get; set; } = string.Empty;
    public TransactionType Type { get; set; }
    public decimal Amount { get; set; }

    // Optional fields
    public string? Note { get; set; }
    public List<string> Tags { get; set; } = new();

    // For Debt type only
    public string? DebtSource { get; set; }
    public DateTime? DueDate { get; set; }
    public bool IsDebtCleared { get; set; } = false;
}
}

