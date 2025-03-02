namespace SchoolHRAdministration.DelegateFunction
{
    public delegate void GreetDelegate(string name);
    public delegate void NotifyDelegate();
    public delegate int MathOperation(int a, int b);

    public delegate void ThresholdReachedEventHandler(object sender, ThresholdReachedEventArgs e);

    public class ThresholdReachedEventArgs : EventArgs
    {
        public int Threshold { get; set; }
        public DateTime TimeReached { get; set; }
    }

    public static class DelegateBasics
    {
        public static void SayHello(string name)
        {
            Console.WriteLine($"Hello, {name}");
        }

        public static void MethodOne()
        {
            Console.WriteLine("Method One executed.");
        }

        public static void MethodTwo()
        {
            Console.WriteLine("Method Two executed.");
        }

        public static void DelegateFunction()
        {
            #region BasicDelegate
            GreetDelegate greetDelegate = new(SayHello);
            greetDelegate("Jaeson");

            NotifyDelegate notify = MethodOne;
            notify += MethodTwo;

            notify?.Invoke();

            GreetDelegate greet = delegate (string msg)
            {
                Console.WriteLine($"Hello {msg}");
            };
            greet("Joseph");


            MathOperation add = (a, b) => a + b;
            Console.WriteLine($"Addition :{add(10, 10)}");

            Func<int, int, int> multiply = (x, y) => x * y;
            Console.WriteLine($"Multiplication: {multiply(6, 7)}");

            Action<string> greetMsg = name => Console.WriteLine($"Hello, {name}!");
            greetMsg("Alice");

            Predicate<int> isEven = num => num % 2 == 0;
            Console.WriteLine($"Is Even: {isEven(6)}");
            #endregion

            Counter counter = new(10);
            counter.ThresholdReached += Counter_ThresholdReached;

            Console.WriteLine("Adding numbers...");
            counter.Add(3);
            counter.Add(4);
            counter.Add(5);  // This addition should trigger the event
        }

        private static void Counter_ThresholdReached(object sender, ThresholdReachedEventArgs e)
        {
            Console.WriteLine($"Threshold of {e.Threshold} was reached at {e.TimeReached}");
        }

        public class Counter(int Threshold)
        {
            private readonly int threshold = Threshold;
            private int total;

            public event ThresholdReachedEventHandler? ThresholdReached;

            public void Add(int x)
            {
                total += x;
                Console.WriteLine($"Added {x}, total is now {total}.");

                if (total >= threshold)
                {
                    ThresholdReachedEventArgs args = new()
                    {
                        Threshold = threshold,
                        TimeReached = DateTime.Now
                    };

                    OnThresholdReached(args);

                }
            }

            protected virtual void OnThresholdReached(ThresholdReachedEventArgs e)
            {
                // Use the null-conditional operator to avoid NullReferenceException
                ThresholdReached?.Invoke(this, e);
            }

        }
    }
}
