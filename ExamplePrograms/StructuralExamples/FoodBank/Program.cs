using RealisticDependencies.Logger;
using StructualPatterns.Proxy;

namespace ExamplePrograms.StructuralExamples.FoodBank;

internal class Program {
   
    /// <summary>
    /// FoodBank Donation system that enables patrons to donate food to our Bank.
    /// It's built on pre-existing software called FoodBankService that we would like
    /// to restrict access to accept only the types of foods we need at this food bank.
    /// we'd also like to the ability to log before and perhaps after donations are made.
    /// We also want to control access to things like the current inventory managed by the
    /// underlying FoodBank Service.
    /// Here we use the proxy design pattern to create a level of indirection between this client
    /// and the underlying FoodBankService Instance. THis is similiar to the implementation of the 
    /// Decorator Pattern - However, the Decorator Pattern is used to add behavior to an existing object,
    /// where the motivation for the Proxy is to control access to an underlying object.
    /// </summary>
    private static void Main() { 
        Console.OutputEncoding = System.Text.Encoding.UTF8;
        Console.WriteLine("💗 Welcome to the East Side Food Bank");
        var logger = new ConsoleLogger();
        var initialFoodBank=new List<string>();
        var foodBankService=new FoodBankService(initialFoodBank, logger);
        var acceptableDonationHandler = new EastSideFoodBank(foodBankService, logger);
        while (true) {
            logger.LogInfo("Please specify what you would like to donate.");
            var donation=Console.ReadLine();
            acceptableDonationHandler.DonateFood(donation);

            logger.LogInfo("Have you completed your total donation? (y/n)");
            var isComplete=Console.ReadLine();
            if (string.IsNullOrWhiteSpace(isComplete) || isComplete.ToLower() != "y") {
                continue;
            }

            var bankCache = acceptableDonationHandler.GetBankCache();
            if (bankCache.Count > 0) {
                logger.LogInfo("Thank you for your donation(s).", ConsoleColor.Cyan);
                logger.LogInfo("The Bank now contains the following items:", ConsoleColor.Cyan);
                foreach (var foodItem in bankCache) {
                    logger.LogInfo($" {foodItem} ", ConsoleColor.Cyan);
                }
            }
            logger.LogInfo("Have a nice day.");
            break;
        }
        
    }
}