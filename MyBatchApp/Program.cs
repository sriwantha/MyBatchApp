using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace MyBatchApplication
{
    class Program
    {
        static void Main(string[] args)
        {
            List<Task> jobs = new List<Task>();
            //start 20 background tasks that will keep the CPU bussy
            for (int i = 0; i < 1; i++)
            {
                string id = "worker " + i;
                jobs.Add(Task.Factory.StartNew(new Action<object>(Run), id));
            }
            //do not exit, continue forever
            Task.WaitAll(jobs.ToArray());
        }

        public static void Run(Object param)
        {
            while (true)
            {
                System.Threading.Thread.Sleep(500);
                string stamp = DateTime.Now.ToString("HH:mm:ss") + "-->" + Math.Sqrt(DateTime.Now.Millisecond);
                Console.WriteLine($"{param}:{stamp}");
            }
        }
    }
}
