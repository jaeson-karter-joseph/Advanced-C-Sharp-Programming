using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SchoolHRAdministration.Events.Logger
{
    public class BankLogger
    {
        public void Subcribe(AtmMachine machine)
        {
            machine.OnWithdraw += LogTransaction;
        }

        private void LogTransaction(object? sender, TransactionEventArgs e)
        {
            Console.WriteLine($"[BANK LOG] Transaction: Account {e.AccountNumber}, Amount: ${e.Amount}");
        }
    }
}
