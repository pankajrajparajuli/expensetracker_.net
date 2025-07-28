using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Text.Json;
using expensetracker.Models;

namespace expensetracker.Services
{
    public class LocalStorageService : IDataService
    {
        private readonly string userSettingsFile = Path.Combine(FileSystem.AppDataDirectory, "user_settings.json");
        private readonly string transactionsFile = Path.Combine(FileSystem.AppDataDirectory, "transactions.json");

        public async Task<UserSettings?> LoadUserSettingsAsync()
        {
            if (!File.Exists(userSettingsFile)) return null;
            var json = await File.ReadAllTextAsync(userSettingsFile);
            return JsonSerializer.Deserialize<UserSettings>(json);
        }

        public async Task SaveUserSettingsAsync(UserSettings settings)
        {
            var json = JsonSerializer.Serialize(settings, new JsonSerializerOptions { WriteIndented = true });
            await File.WriteAllTextAsync(userSettingsFile, json);
        }

        public async Task<List<Transaction>> LoadTransactionsAsync()
        {
            if (!File.Exists(transactionsFile)) return new List<Transaction>();
            var json = await File.ReadAllTextAsync(transactionsFile);
            return JsonSerializer.Deserialize<List<Transaction>>(json) ?? new List<Transaction>();
        }

        public async Task SaveTransactionsAsync(List<Transaction> transactions)
        {
            var json = JsonSerializer.Serialize(transactions, new JsonSerializerOptions { WriteIndented = true });
            await File.WriteAllTextAsync(transactionsFile, json);
        }
    }
}

