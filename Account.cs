using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SimpleBankingApplication.Models
{
    public class Account
    {
        public int AccountId { get; set; }
        public decimal Balance { get; set; }
        public required string UserName { get; set; }
        public required string Password { get; set; }
        public required string AccountNumber { get; set; }

    
    }
}
