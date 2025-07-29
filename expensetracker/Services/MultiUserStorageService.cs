using expensetracker.Models;
using System.Text.Json;
using Microsoft.Maui.Storage;

namespace expensetracker.Services
{
    public class MultiUserStorageService : IDataService
    {
        private readonly string usersFile = Path.Combine(FileSystem.AppDataDirectory, "users.json");
        private readonly string sessionFile = Path.Combine(FileSystem.AppDataDirectory, "session.json");
        private readonly string transactionsFile = Path.Combine(FileSystem.AppDataDirectory, "transactions.json");

        private static readonly JsonSerializerOptions _jsonOptions = new JsonSerializerOptions { WriteIndented = true };

        public async Task<List<UserSettings>> LoadUsersAsync()
        {
            if (!File.Exists(usersFile)) return new List<UserSettings>();
            var json = await File.ReadAllTextAsync(usersFile);
            return JsonSerializer.Deserialize<List<UserSettings>>(json) ?? new List<UserSettings>();
        }

        public async Task SaveUsersAsync(List<UserSettings> users)
        {
            var json = JsonSerializer.Serialize(users, _jsonOptions);
            await File.WriteAllTextAsync(usersFile, json);
        }

        public async Task<UserSettings?> GetUserByUsernameAsync(string username)
        {
            var users = await LoadUsersAsync();
            return users.FirstOrDefault(u => u.Username.Equals(username, StringComparison.OrdinalIgnoreCase));
        }

        public async Task<bool> RegisterUserAsync(UserSettings newUser)
        {
            var users = await LoadUsersAsync();

            if (users.Any(u => u.Username.Equals(newUser.Username, StringComparison.OrdinalIgnoreCase)))
                return false;

            users.Add(newUser);
            await SaveUsersAsync(users);

            var session = new Session { Username = newUser.Username, IsLoggedIn = true };
            var json = JsonSerializer.Serialize(session, _jsonOptions);
            await File.WriteAllTextAsync(sessionFile, json);

            return true;
        }

        public async Task<bool> LoginAsync(string username, string password)
        {
            var users = await LoadUsersAsync();
            var user = users.FirstOrDefault(u => u.Username == username && u.Password == password);
            if (user == null) return false;

            var session = new Session { Username = username, IsLoggedIn = true };
            var json = JsonSerializer.Serialize(session, _jsonOptions);
            await File.WriteAllTextAsync(sessionFile, json);
            return true;
        }

        public async Task LogoutAsync()
        {
            if (File.Exists(sessionFile))
            {
                var json = await File.ReadAllTextAsync(sessionFile);
                var session = JsonSerializer.Deserialize<Session>(json);
                if (session != null)
                {
                    session.IsLoggedIn = false;
                    json = JsonSerializer.Serialize(session, _jsonOptions);
                    await File.WriteAllTextAsync(sessionFile, json);
                }
            }
        }

        public async Task<Session?> GetSessionAsync()
        {
            if (!File.Exists(sessionFile)) return null;
            var json = await File.ReadAllTextAsync(sessionFile);
            return JsonSerializer.Deserialize<Session>(json);
        }

        public async Task SaveSessionAsync(Session session)
        {
            var json = JsonSerializer.Serialize(session, _jsonOptions);
            await File.WriteAllTextAsync(sessionFile, json);
        }

        public async Task<List<Transaction>> LoadTransactionsAsync()
        {
            if (!File.Exists(transactionsFile)) return new List<Transaction>();
            var json = await File.ReadAllTextAsync(transactionsFile);
            return JsonSerializer.Deserialize<List<Transaction>>(json) ?? new List<Transaction>();
        }

        public async Task SaveTransactionsAsync(List<Transaction> transactions)
        {
            var json = JsonSerializer.Serialize(transactions, _jsonOptions);
            await File.WriteAllTextAsync(transactionsFile, json);
        }

        // ✅ NEW: Add a transaction for the current user
        public async Task AddTransactionAsync(Transaction transaction)
        {
            var session = await GetSessionAsync();
            if (session == null || !session.IsLoggedIn)
                throw new Exception("User is not logged in.");

            var allTransactions = await LoadTransactionsAsync();

            // ✅ Set Username before saving
            transaction.Username = session.Username;

            allTransactions.Add(transaction);
            await SaveTransactionsAsync(allTransactions);
        }


        // ✅ Optional: Load only transactions for current user
        public async Task<List<Transaction>> GetCurrentUserTransactionsAsync()
        {
            var session = await GetSessionAsync();
            if (session == null || !session.IsLoggedIn)
                return new List<Transaction>();

            var all = await LoadTransactionsAsync();
            return all
                .Where(t => t.Title.StartsWith($"[{session.Username}]"))
                .ToList();
        }
    }
}
