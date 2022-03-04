using CreationalPatterns.FactoryMethod;
using RealisticDependencies.Logger;
using RealisticDependencies.Provider;

namespace FoodDeliveryService;

/// <summary>
/// this example uses a factory method creational pattern to fullfill a food 
/// Delivery order by bicycle or car depending on the input given to the console 
/// application. 
/// 
/// one of the benefit of this pattern is that it is easier to extend the
/// delivery type construction
/// 
/// code independently form the main service method here which invokes it.
/// we could introduce new deliveryTypes into the prorject without modifying/ breaking our client
/// code - in this case, the main method.
/// 
/// we have separated the concern of the creating a DeliveryCreator from the client code that uses it.
/// All of the static data could be extracted from the code into the environment or another configuration source.
/// 
/// </summary>
internal class Program {

    private static int Main(string[] args) {
        var logger = new ConsoleLogger();

        IAmqpQueue deliveryQueue = new CloudQueue(logger);

        logger.LogInfo("... Welcome to the Food Delivery Service!");

        logger.LogInfo("------------------------------------------------");

        logger.LogInfo("Please enter a delivery type");

        //Collect data at runtime which ultimately determine the chosen
        //implementation of IDeliversFood
        var deliveryType=Console.ReadLine();

        if (string.IsNullOrWhiteSpace(deliveryType)) {
            logger.LogInfo("Error reading delivery type.");
            return 1;
        }

        try
        {
            DeliveryCreateor deliveryCreator = BuildDeliveryCreator(deliveryType, deliveryQueue);
            deliveryCreator.QueueVehicleForDelivery();
        }
        catch (Exception ex) {
            logger.LogError($"There was an error processing the delivery: {ex.Message}, {ex.StackTrace}");
            return 1;
        }
        return 0;

    }

    public static DeliveryCreateor BuildDeliveryCreator(string deliveryType, IAmqpQueue deliveryQueue)
    {
        var logger = new ConsoleLogger();

        List<string> validateDeliveryOptions = new() {"bicycle","car" };

        if (!validateDeliveryOptions.Contains(deliveryType)) {
            logger.LogInfo("Please enter a type of delivery [bicycle, car]");
            throw new InvalidOperationException("Cannot set up delivery without valid deliveryType");
        }

        return deliveryType switch
        {
            "bicycle" => new BicycleDeliveryCreator(deliveryQueue, logger),
            "car" => new CarDeliveryCreator(deliveryQueue, logger),
            _ => throw new InvalidOperationException("Cannot set up delivery without valid deliveryType"),
        };
    }
}