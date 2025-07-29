using expensetracker.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace expensetracker.Services
{
    public interface IDataService
    {
        // User session management
        Task<List<UserSettings>> LoadUsersAsync();
        Task SaveUsersAsync(List<UserSettings> users);
        Task<UserSettings?> GetUserByUsernameAsync(string username);
        Task<bool> RegisterUserAsync(UserSettings newUser);
        Task<bool> LoginAsync(string username, string password);
        Task LogoutAsync();
        Task<Session?> GetSessionAsync();
        Task SaveSessionAsync(Session session);
        Task AddTransactionAsync(Transaction transaction);
        Task<List<Transaction>> GetCurrentUserTransactionsAsync();


        // Transactions
        Task<List<Transaction>> LoadTransactionsAsync();
        Task SaveTransactionsAsync(List<Transaction> transactions);
    }
}
