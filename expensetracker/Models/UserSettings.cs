using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace expensetracker.Models
{
    public class UserSettings
    {
        public string Username { get; set; } = string.Empty;
        public string Password { get; set; } = string.Empty;  // You can hash this for security
        public string Currency { get; set; } = "USD";
        public bool IsLoggedIn { get; set; } = false;
    }
}
