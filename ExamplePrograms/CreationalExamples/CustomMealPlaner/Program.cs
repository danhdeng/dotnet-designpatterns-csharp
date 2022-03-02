
using RealisticDependencies.Logger;

namespace CustomMealPlaner;

internal class Program { 
    private static async Task Main(string[] vs) { 
        var logger=new ConsoleLogger();
        logger.LogInfo("Please enter customer email.");
        var customerEmail = Console.ReadLine();
        if (string.IsNullOrWhiteSpace(customerEmail)) {
            logger.LogInfo("error reading customer email");
            return;
        }
    }        
    
}