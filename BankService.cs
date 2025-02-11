using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Newtonsoft.Json;
using SimpleBankingApplication.Models;

namespace SimpleBankingApplication.Services
{
    public class BankService
    {
         private readonly string FilePath = Path.Combine(Directory.GetCurrentDirectory(),@"AccountData.Json");
         private readonly string FilePathPassBook = Path.Combine(Directory.GetCurrentDirectory(),@"PassBookData.Json");
        private List<Customer> Accounts = new List<Customer>();
        private int newId = 1;
        public List<Passbook>? Passbooks { get; private set; }
        public decimal Balance { get; private set; }

        public BankService()
        {
            LoadDataFromJson();
            LoadDataFromJsonPassBook();
        }

        public void DepositAmount(string userName, decimal amount)
        {
            var account = Accounts.FirstOrDefault(x => x.Account.UserName == userName);
            if(account != null)
            {
                account.Account.Balance += amount;
                Balance += amount;
                var balance = account.Account.Balance;

                var passbookData = new Passbook
                {
                    PassbookId =  newId++,
                    AccountId = (int)account.Account.AccountId,
                    Date = DateTime.UtcNow,
                    TransactionType = "Deposit",
                    Amount = amount,
                    Balance = balance

                };
                Console.WriteLine("Amount deposited successfully.");
                Console.WriteLine($"{amount:C} deposited. New balance: {balance:C}");
                SaveDataFromJson();
                SaveDataFromJsonPassBook();
            }

        }
         private void SaveDataFromJson()
        {
            var json = JsonConvert.SerializeObject(Accounts , Formatting.Indented);
            File.WriteAllText(FilePath, json);
            Console.WriteLine("Data saved successfully.");
        }

        private void SaveDataFromJsonPassBook()
        {
            var json = JsonConvert.SerializeObject(Accounts , Formatting.Indented);
            File.WriteAllText(FilePathPassBook, json);
            Console.WriteLine("Data saved successfully.");
        }

        private void LoadDataFromJson()
        {
            if (File.Exists(FilePath))
            {
                var json = File.ReadAllText(FilePath);
                Accounts = JsonConvert.DeserializeObject<List<Customer>>(json);
                Console.WriteLine("Data loaded successfully.");

            }

        }

         private void LoadDataFromJsonPassBook()
        {
            if (File.Exists( FilePathPassBook))
            {
                var json = File.ReadAllText( FilePathPassBook);
                Passbooks = JsonConvert.DeserializeObject<List<Passbook>>(json);
                Console.WriteLine("Data loaded successfully.");

            }

        }

    }
}