using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.Azure.WebJobs;

namespace HostTest
{
    class Program
    {
        static void Main(string[] vargStrings)
        {
            var configuration = new JobHostConfiguration();
            configuration.Queues.MaxPollingInterval = TimeSpan.FromSeconds(30);
            configuration.Queues.MaxDequeueCount = 10;
            configuration.Queues.BatchSize = 1;

            var host = new JobHost(configuration);
            host.Start();

            // Stop the host if Ctrl + C/Ctrl + Break is pressed
            Console.CancelKeyPress += (sender, args) =>
            {
                host.Stop();
            };

            while (true)
            {
                Thread.Sleep(500);
            }
        }
    }
}
