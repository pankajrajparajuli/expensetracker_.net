using expensetracker.Models;

namespace expensetracker.Services
{
    public interface IDataService
    {
        Task<UserSettings?> LoadUserSettingsAsync();
        Task SaveUserSettingsAsync(UserSettings settings);
        Task<List<Transaction>> LoadTransactionsAsync();
        Task SaveTransactionsAsync(List<Transaction> transactions);
    }
}