using BehavioralPatterns.Command;
using BehavioralPatterns.Command.Commands;
using RealisticDependencies.Logger;
using RealisticDependencies.Provider;

namespace ExamplePrograms.BehavioralPrograms.NeighborhoodComposterSignUpForm;

internal class Program {
    /// <summary>
    /// we have a form where users can sign up to have a compost truck
    /// come and collect organiz food waste from their homes. The application needs
    /// to do some complex logic behind the scenes when a user signs up, 
    /// like send emails and queue up messages to an AWS SQS queue,
    /// where  route planning services subscribe to comsume data. we use the command
    /// pattern to encapsulate request for these emails and queuing operations,
    /// allowing us to set different commands to be executed at the start
    /// and end of any particular business process, and to decouple
    /// the objects that encapsulate the data needed to perform an operation
    /// from the executtors. here we set commmands to be executed during 
    /// the process of signing up our new user for the service.
    /// </summary>
    private static void Main() {
        var logger = new ConsoleLogger();
        var cloudQueue = new CloudQueue(logger);
        var emailer = new Emailer(logger);
        logger.LogInfo("🌱 Welcome to the Neighborhood Composter Sign Up Application");
        logger.LogInfo("------------------------------------------------------------");

        logger.LogInfo("What is your name?");
        var name = Console.ReadLine();

        logger.LogInfo("What is your email address?");
        var emailAddress = Console.ReadLine();

        logger.LogInfo("What is home address?");
        var address = Console.ReadLine();

        logger.LogInfo($"Thanks, {name}! A Composet vehicle will stop to pick up your compost every Saturday", ConsoleColor.Green);

        var newUserHandler = new NewUserHandler(logger);

        //Our SetOnStart and SetOnFinish methods prepare the hooks in the business
        //process of signing a user up for service.
        newUserHandler.SetOnStart(new NewCustomerEmailCommand(logger, emailer, name, emailAddress));
        newUserHandler.SetOnFinish(new AddressQueueCommand(logger, cloudQueue, address));
        newUserHandler.SignUpUser();
    }
}