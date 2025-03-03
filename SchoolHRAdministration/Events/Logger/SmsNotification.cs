using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SchoolHRAdministration.Events.Logger
{
    public class SmsNotification
    {
        public void Subcribe(AtmMachine machine)
        {
            machine.OnWithdraw += SendSms;
        }

        private void SendSms(object? sender, TransactionEventArgs e)
        {
            Console.WriteLine($"[SMS] Alert: ${e.Amount} withdrawn from account {e.AccountNumber}.");
        }
    }
}
