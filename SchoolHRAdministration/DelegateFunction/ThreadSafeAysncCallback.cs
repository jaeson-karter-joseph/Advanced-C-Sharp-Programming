using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace SchoolHRAdministration.DelegateFunction
{
    public delegate void CallBackDelegate(string message);
    public static class ThreadSafeAysncCallback
    {
        private static readonly object lockObject = new();
        private static int processedCount = 0;

        public static async Task RunWork()
        {
            Console.WriteLine("Main thread started...");
            CallBackDelegate callBackDelegate = CallbackMethod1;
            callBackDelegate += CallbackMethod2;

            await Task.WhenAll(
                ProcessDataAsync("Employee Data A", callBackDelegate),
                ProcessDataAsync("Employee Data B", callBackDelegate),
                ProcessDataAsync("Employee Data C", callBackDelegate)
            );

            Console.WriteLine($"Total processed items: {processedCount}");
            Console.WriteLine("Main thread continues...");
        }

        public static async Task ProcessDataAsync(string data, CallBackDelegate callBackDelegate)
        {
            try
            {
                Console.WriteLine($"Processing {data}...");
                await Task.Delay(3000);
                lock(lockObject)
                {
                    Console.WriteLine($"{data} processed successfully.");
                }
                Interlocked.Increment(ref processedCount);
                callBackDelegate?.Invoke($"Callback: {data} processed successfully!");
            }
            catch (Exception ex)
            {
                lock (lockObject)
                {
                    Console.WriteLine($"Error: {ex.Message}");
                }

                // Still invoke the callback to notify about the error
                callBackDelegate?.Invoke($"Callback: Error occurred while processing {data}. {ex.Message}");
            }
        }

        static void CallbackMethod1(string message)
        {
            lock (lockObject)
            {
                Console.WriteLine($"[Logger] {message}");
            }
        }

        static void CallbackMethod2(string message)
        {
            lock (lockObject)
            {
                Console.WriteLine($"[Notifier] Sending notification: {message}");
            }
        }
    }
}
