using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SchoolHRAdministration.Events
{
    public class OrderEvents(string orderId, double amount) : EventArgs
    {
        public string OrderId { get; set; } = orderId;
        public double Amount { get; set; } = amount;
    }

    public class OrderProcessor
    {
        public event EventHandler<OrderEvents> OrderEvents = null!;
        public void ProcessOrder(OrderEvents orderEvents)
        {
            Console.WriteLine($"Processing Order {orderEvents.OrderId} for Rs.{orderEvents.Amount}");
            OrderEvents?.Invoke(this, orderEvents);
        }
    }

    public class EmailService
    {
        public void Subcribe(OrderProcessor orderProcessor)
        {
            orderProcessor.OrderEvents += SendEmail;
        }

        public void SendEmail(object? sender, OrderEvents orderEvents)
        {
            Console.WriteLine($"Email Sent: Order {orderEvents.OrderId} processed for ${orderEvents.Amount}");
        }
    }
}
