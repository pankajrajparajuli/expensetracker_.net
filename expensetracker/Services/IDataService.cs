using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
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

