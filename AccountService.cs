using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Newtonsoft.Json;
using SimpleBankingApplication.Models;

namespace SimpleBankingApplication.Services
{
    public class AccountService
    {
         private readonly string FilePath = Path.Combine(Directory.GetCurrentDirectory(),@"AccountData.Json");

        private List<Customer> customers = new List<Customer>();

        private int nextIdForCustomer = 1;
        private int nextIdAccount = 1;

        public AccountService()
        {
            LoadDataFromJson();
        }


        public void CreateNewCustomer(string firstName, string lastName,  DateTime dob, string address, string phoneNumber, string gender, string accountType)
        {
            var newCustomer = new Customer
            {
                CustomerId = nextIdForCustomer++,
                FirstName = firstName,
                LastName = lastName,
                DOS = dob, 
                Address = address,
                PhoneNumber = phoneNumber,
                Gender = gender,
                AccountType = accountType,
            };
            Console.WriteLine("Wait, account details are generating in progress .......");
            newCustomer.Account = GenerateAccountDetails(accountType, firstName);
            customers.Add(newCustomer);
            Console.WriteLine("Registered successfully");
            Console.WriteLine("Data saved succesfully");

        }

        public bool GetCustomer(string userName, string password)
        {
            var customer = customers.FirstOrDefault(x => x.Account.UserName == userName && x.Account.Password == password);
            if (customer != null)
            {
                return true;
            }
            else 
            {
                Console.WriteLine("Customer not found, please try again");
                return false;
            }
        }

    
        //it will create automatic account details 
        private Account GenerateAccountDetails(string accType, string firstName)
        {
            var accountDetails = new Account
            {
                AccountId = nextIdAccount++,
                Balance = GetMinimumBalance(accType),
                UserName = GenerateUserName(firstName),
                Password = GeneratePassword(),
                AccountNumber = GenerateAccountNumber()
            };
            return accountDetails;
        }

        private string GenerateAccountNumber()
        {
            return "ACCC" + "1001" + new Random().Next(10000, 99999).ToString();
        }


        private string GeneratePassword()
        {
            return "P@ssw0rd123";
        }
        private string GenerateUserName(string name)
        {
            return name.ToLower() + "_user";
        }
        private decimal GetMinimumBalance(string accType)
        {
            return 1000m;
        }

        private void LoadDataFromJson()
        {
            if (File.Exists(FilePath))
            {
                var json = File.ReadAllText(FilePath);
                customers = JsonConvert.DeserializeObject<List<Customer>>(json);
                Console.WriteLine("Data loaded successfully.");

            }
        }
    }
}