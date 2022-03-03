
using CreationalPatterns.AbstractFactory;
using CreationalPatterns.AbstractFactory.Interfaces;
using CreationalPatterns.AbstractFactory.MealPlanFactory;
using RealisticDependencies.Logger;
using RealisticDependencies.Provider;

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
        try
        {
            var dietType = GetCustomerDietFromDatabase(customerEmail);
            var mealPlanFactory = GetFactoryForDietType(dietType, logger);
            ISendMails sendMails = new Emailer(logger);
            IMealPlanService mealPlanService = new MealPlanService(mealPlanFactory, sendMails, logger);
            await mealPlanService.SendMealPlanToSubscriber(customerEmail);
        }
        catch (Exception ex) {
            logger.LogError($"{$"Error processing the meal plan:{ex.Message} {ex.StackTrace}"}");
            return;
        }
        return;
    }

    public static string GetCustomerDietFromDatabase(string customerEmail) {
        return customerEmail == "jane.doe@example.com" ? "keto" : "vegetarian";
    }

    public static IMealPlanFactory GetFactoryForDietType(string dietType, IApplicationLogger logger)
        => dietType switch
        {
            "keto" => new KetoMealPlanFactory(logger),
            "vegetarian" => new VegetarianMealPlanFactory(logger)
        };
    
    
    
}