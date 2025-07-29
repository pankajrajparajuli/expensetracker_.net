using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace expensetracker.Models
{
    public class Session
    {
        public string Username { get; set; } = string.Empty;
        public bool IsLoggedIn { get; set; } = false;
    }
}
