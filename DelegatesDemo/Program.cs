using System;
using System.Collections.Generic;
using static DelegatesDemo.DataProcessor;

namespace DelegatesDemo
{
    class Program
    {
        static void Main(string[] args)
        {
            //
            // Connect Event Handlers to delegates in different ways
            //
            var worker = new Worker();
            worker.WorkPerformed += new EventHandler<WorkPerformedEventArgs>(WorkProgressEventHandler1);
            // Delegate inference
            worker.WorkPerformed += WorkProgressEventHandler2;
            // With anonymous method
            worker.WorkPerformed += delegate (object sender, WorkPerformedEventArgs e)
            {
                Console.WriteLine("In anonymous method, progress: " + e.Progress);
            };
            // with lambda expression
            worker.WorkPerformed += (sender, e) => Console.WriteLine("In lambda inline method, progress: " + e.Progress);
            worker.DoWork(5);

            //
            // Action<T>
            //
            Action hello = () => Console.WriteLine("Hello");
            hello();
            hello();

            //
            // Inline temporary variable
            //
            ((Action)(() => Console.WriteLine("Hello2")))();

            //
            // Local function
            //
            static void hello3() => Console.WriteLine("Hello3");
            hello3();
            hello3();

            //
            // Delegate as argument
            //
            var processor = new DataProcessor();
            // Using explicit delagate definition
            BusinessRuleDelegate add = (x, y) => x + y;
            BusinessRuleDelegate subtract = (x, y) => x - y;
            Console.WriteLine("Add 2 and 3: " + processor.ProcessData(2, 3, add));
            Console.WriteLine("Subtract 3 from 2: " + processor.ProcessData(2, 3, subtract));
            // Using Func<T>
            Func<int, int, int> funcAdd = (x, y) => x + y;
            Console.WriteLine("funcAdd 2 and 3: " + processor.ProcessDataWithFunc(2, 3, funcAdd));
            Func<int, int, int> funcSub = (x, y) => x - y;
            Console.WriteLine("funcSub 3 from 2: " + processor.ProcessDataWithFunc(2, 3, funcSub));
        }

        static void WorkProgressEventHandler1(object sender, WorkPerformedEventArgs e)
        {
            Console.WriteLine("Progress handler1: " + e.Progress);
        }

        static void WorkProgressEventHandler2(object sender, WorkPerformedEventArgs e)
        {
            Console.WriteLine("Progress handler2: " + e.Progress);
        }
    }
}
