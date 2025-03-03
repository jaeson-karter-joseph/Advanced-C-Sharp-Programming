using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SchoolHRAdministration.Events
{
    public class TransactionEventArgs(string accountNumber, double amount) : EventArgs
    {
        public string AccountNumber { get; } = accountNumber;
        public double Amount { get; } = amount;
    }
    public class AtmMachine
    {
        public event EventHandler<TransactionEventArgs> OnWithdraw = null!;
        public void WithdrawMoney(string accountNumber, double amount)
        {
            Console.WriteLine($"ATM: Processing withdrawal of ${amount} from account {accountNumber}...");
            OnWithdraw?.Invoke(this, new TransactionEventArgs(accountNumber, amount));
        }
    }
}
