using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SimpleBankingApplication.Models
{
    public class Customer
    {
        public int CustomerId {get; set; }
        public required string FirstName { get; set; }
        public required string LastName { get; set; }
        public DateTime DOS { get; set; }
        public required string Address { get; set; }
        public required string PhoneNumber { get; set; }
        public required string Gender { get; set; }
        public required string AccountType{ get; set; }
        public required Account Account{ get; set; }
    
    }
}