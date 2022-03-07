

using BehavioralPatterns.ChainOfResponsibility.Constants;
using BehavioralPatterns.ChainOfResponsibility.Handlers;
using BehavioralPatterns.ChainOfResponsibility.Models;
using RealisticDependencies.Logger;
using RealisticDependencies.Provider;

namespace KombuchaOrderProcessor;

internal class Program {
    private static void Main() {
        var logger =new ConsoleLogger();

        logger.LogInfo(" Welcome to the Kombucha Checkout System!");

        var emailer = new Emailer(logger);

        var cartonizer = new Cartonizer(logger);
        var customerLoyalty =new CustomerLoyaltyHandler(logger);
        var receiptPrinter = new ReceiptPrinter(emailer,logger);
        var shippingLabeler = new ShippingLabelPrinter(logger);

        cartonizer
            .SetNext(customerLoyalty)
            .SetNext(receiptPrinter)
            .SetNext(shippingLabeler);

        logger.LogInfo("Process: Cartonize > Loyalty Program > Shipping Labels > Receipt", ConsoleColor.Blue);

        logger.LogInfo("-----------------------------------------------------------------", ConsoleColor.DarkBlue);

        var request = new KombuchaSale();

        logger.LogInfo("Are you a reward member? (y/n)", ConsoleColor.Blue);

        var isRewardsMember = Console.ReadLine();
        if (isRewardsMember != null && isRewardsMember.ToLower() == "y")
        {
            request.CustomerType = CustomerType.RewardsMember;
        }
        else {
            request.CustomerType = CustomerType.WalkIn;
        }

        logger.LogInfo("Is this an online order? (y/n)", ConsoleColor.Blue);
        var isOnlineOrder=Console.ReadLine();
        if (isOnlineOrder != null && isOnlineOrder.ToLower() == "y")
        {
            request.SaleType = SaleType.Online;
        }
        else {
            request.SaleType = SaleType.InHouse;
        }

        cartonizer.Handle(request);


    }
}