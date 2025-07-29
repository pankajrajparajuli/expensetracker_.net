namespace expensetracker.Models
{
    public enum TransactionType
    {
        Credit,
        Debit,
        Debt
    }

    public class Transaction
    {
        public int Id { get; set; }
        public string Username { get; set; } = string.Empty; 
        public DateTime Date { get; set; } = DateTime.Now;
        public string Title { get; set; } = string.Empty;
        public TransactionType Type { get; set; }
        public decimal Amount { get; set; }

        // Optional fields
        public string? Note { get; set; }
        public List<string> Tags { get; set; } = new();

        // For Debt
        public string? DebtSource { get; set; }
        public DateTime? DueDate { get; set; }
        public bool IsDebtCleared { get; set; } = false;
    }
}
