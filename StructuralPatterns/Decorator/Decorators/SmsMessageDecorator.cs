using Newtonsoft.Json;
using RealisticDependencies.Models;
using RealisticDependencies.Provider;
using StructualPatterns.Decorator;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StructuralPatterns.Decorator.Decorators
{
    public class SmsMessageDecorator:NotificationDecorator
    {
        private readonly IAmqpQueue _queue;

        public SmsMessageDecorator(Notifier component, IAmqpQueue queue) : base(component) {
            _queue = queue;
        }

        public override Task HandleTableReadyMessage()
        {
            Task.FromResult(base.HandleTableReadyMessage());
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine(":: SMS Queueing up a text message");
            Console.ResetColor();
            var message = new { customerName = "Dan", message = "Your table is ready" };
            var jsonMessage = JsonConvert.SerializeObject(message);
            var queueMessage = new QueueMessage(jsonMessage);
            _queue.Add(queueMessage);   
            return Task.CompletedTask;
        }
    }
}
