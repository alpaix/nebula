using System.IO;
using Microsoft.Azure.WebJobs;

namespace SampleWebJob1
{
    public class Order
    {
        public string Name { get; set; }

        public string OrderId { get; set; }
    }

    public class Functions
    {
        public static void QueueTriggerMethod([QueueTrigger("orders")] Order order, int dequeueCount, TextWriter log)
        {
            log.WriteLine("New order from: {0}", order.Name);
            log.WriteLine("Message dequeued {0} times", dequeueCount);
        }
    }
}
