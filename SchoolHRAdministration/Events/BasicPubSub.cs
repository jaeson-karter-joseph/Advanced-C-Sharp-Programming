using HRAdminstrationAPI.FactoryPattern;
using SchoolHRAdministration.DelegateFunction;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static SchoolHRAdministration.Events.BasicPubSub;

namespace SchoolHRAdministration.Events
{
    public class BasicPubSub
    {
        public class Publisher
        {
            public event Action OnEventTriggered = null!;

            public async void TriggerEvent(List<IEmployee> employee)
            {
                foreach (var item in employee)
                {
                    await Task.Run(() => ThreadSafeAysncCallback.Log(item.FirstName));
                    OnEventTriggered?.Invoke();

                }
            }
        }

        public class Subcriber
        {
            public void Subcribe(Publisher publisher) => publisher.OnEventTriggered += HandleEvent;

            private async void HandleEvent() => await Task.Run(() => ThreadSafeAysncCallback.Log("Event received by Subscriber."));
        }
    }

    
}
