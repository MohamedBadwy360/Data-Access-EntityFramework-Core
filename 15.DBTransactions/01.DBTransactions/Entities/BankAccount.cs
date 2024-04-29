using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _01.DBTransactions.Entities
{
    public class BankAccount
    {
        public string AccountId { get; set; }
        public string AccountHolder { get; set; }
        public decimal CurrentBalance { get; set; }

        public List<GLTransaction> GLTransactions = new List<GLTransaction>();

        public void Deposit(decimal amount)
        {
            if (amount > 0)
            {
                CurrentBalance += amount;
                GLTransactions.Add(new GLTransaction(amount, "Deposit", DateTime.Now));
            }
        }

        public void Withdraw(decimal amount)
        {
            if (amount > 0 && amount < CurrentBalance)
            {
                CurrentBalance -= amount;
                GLTransactions.Add(new GLTransaction(amount * -1, "Withdraw", DateTime.Now));
            }
        }
    }
}
