using RealisticDependencies.Logger;
using RealisticDependencies.Provider;
using StructualPatterns.Decorator;
using StructuralPatterns.Decorator.Decorators;

namespace ExamplePrograms.StructuralExamples.FrontOfHouseService;

internal class Program {

    /// <summary>
    /// use a Decorator Design Pater to stack the behavior of different notification agents.
    /// 
    ///The restraurant notifies its pattrons when a table is ready for them. In addition to the 
    ///in-house intercom system, patrons have the option to be notified by Text SMS or Email.
    ///we inherited this system from legacy codebase, and we need an easy way to add new
    ///behavior as new modes of communication arise. The decorator allows us to create a stack of 
    /// modes of communication without affecting the behavior of existing objects. in a way that is easy
    /// to compose when multiple options of combining communicating methods are desired.
    /// </summary>
    /// <returns></returns>
    private static async Task Main() {
        var logger = new ConsoleLogger();

        logger.LogInfo("-- Welcome to the Front-of-House Service!");

        bool isEmailCustomer;
        bool isSmsCustomer;


        logger.LogInfo("------------------------------------------------------------------");
        logger.LogInfo("Do you want to be notified by email when your table is ready? (y/n)");

        var emailOption=Console.ReadLine();

        if (emailOption != null)
        {
            switch (emailOption.ToLower())
            {
                case "y":
                    logger.LogInfo("OK, we'll send you an email");
                    isEmailCustomer = true;
                    break;
                case "n":
                    isEmailCustomer = false;
                    break;
                default:
                    logger.LogInfo("Invalid option. please try again");
                    return;
            }
        }
        else {
            logger.LogInfo("Invalid option, please try again");
            return;
        }

        logger.LogInfo("-------------------------------------------------------------");
        logger.LogInfo("Do you want to be notfied by text when your table is ready? (y/n)");

        var smsOption = Console.ReadLine();

        if (smsOption != null)
        {
            switch (emailOption.ToLower())
            {
                case "y":
                    logger.LogInfo("OK, we'll send you text");
                    isSmsCustomer = true;
                    break;
                case "n":
                    isSmsCustomer = false;
                    break;
                default:
                    logger.LogInfo("Invalid option. please try again");
                    return;
            }
        }
        else
        {
            logger.LogInfo("Invalid option, please try again");
            return;
        }

        logger.LogInfo("--------------------------------------------------------");

        logger.LogInfo("Please wait while we arrange a table for you....");

        Thread.Sleep(3000);

        Notifier notifier = new RestraurantIntercomNotifier();
        if (isSmsCustomer) {
            logger.LogInfo("Adding SMS Decorator");
            notifier = new SmsMessageDecorator(notifier, new CloudQueue(logger));
        }
        if (isEmailCustomer)
        {
            logger.LogInfo("Adding Email Decorator");
            notifier = new EmailMessageDecorator(notifier, new Emailer(logger));
        }

        await notifier.HandleTableReadyMessage();
    }
}