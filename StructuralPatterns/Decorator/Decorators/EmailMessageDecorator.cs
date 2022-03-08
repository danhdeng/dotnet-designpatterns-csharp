using RealisticDependencies.Models;
using RealisticDependencies.Provider;
using StructualPatterns.Decorator;

namespace StructuralPatterns.Decorator.Decorators;
    public class EmailMessageDecorator:NotificationDecorator
    {
        private readonly ISendMails _mailer;

        public EmailMessageDecorator(Notifier component, ISendMails emailer):base(component) {
            _mailer = emailer;
        }

        public override async Task HandleTableReadyMessage() { 
            await base.HandleTableReadyMessage();
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine(":: Eamil - Preparing an email");
            Console.ResetColor();
            var email = new EmailMessage("customer@example.com", "Your table is ready");
            await _mailer.SendMessage(email);   
        }
    }
