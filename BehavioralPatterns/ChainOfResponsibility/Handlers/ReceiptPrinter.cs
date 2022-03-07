using BehavioralPatterns.ChainOfResponsibility.Constants;
using BehavioralPatterns.ChainOfResponsibility.Models;
using RealisticDependencies.Logger;
using RealisticDependencies.Models;
using RealisticDependencies.Provider;

namespace BehavioralPatterns.ChainOfResponsibility.Handlers;

public class ReceiptPrinter : AbstractStep
{
    private readonly ISendMails _emailer;
    private readonly IApplicationLogger _logger;

    public ReceiptPrinter(ISendMails emailer,IApplicationLogger logger)
    {
        _emailer = emailer;
        _logger = logger;
    }

    public override KombuchaSale? Handle(KombuchaSale request)
    {
        if (request.SaleType == SaleType.InHouse)
        {
            _logger.LogInfo("Printing receipt for in-house order.", ConsoleColor.Green);
            return base.Handle(request);
        }
        if (request.SaleType != SaleType.Online)
        {
            return base.Handle(request);
        }
        _logger.LogInfo("Emailing receipt for online order.", ConsoleColor.Green);
        var emailReceipt = new EmailMessage("customer@example.com", "Here is your receipt");
        if (request.SpecialMessages != null && request.SpecialMessages.Any()) {
            foreach (var message in request.SpecialMessages) {
                emailReceipt.Content += $"| {message}";
            }
        }
        var emailTask = _emailer.SendMessage(emailReceipt);
        emailTask.Wait();
        return base.Handle(request);
    }
}
