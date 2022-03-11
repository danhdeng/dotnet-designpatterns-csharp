using BehavioralPatterns.Strategy;
using BehavioralPatterns.Strategy.Strategies;
using RealisticDependencies;
using RealisticDependencies.Database;
using RealisticDependencies.Logger;
using RealisticDependencies.Provider;

namespace ExamplePrograms.BehavioralPrograms.MenuChanger;

internal class Program {
    /// <summary>
    /// we have our client code that pass the specific IMenuGenerationStrategy
    /// to the RestraurantContext for building a menu.
    /// 
    /// The Client provides a layer of abstraction where the appropriate
    /// strategy can be chosen, while the Context contains logic for 
    /// carrying out any given strategy.
    /// 
    /// Each Strategy can vary in implementations as long as it fulfills
    /// the IMenuGenerationStrategy interface.
    /// </summary>
    /// <returns></returns>
    private static async Task Main() {
        var logger = new ConsoleLogger();
        logger.LogInfo("🌶️ Welcome to the Strategic Menu Changer");
        logger.LogInfo("----------------------------------------");

        var dateTimeProvider = new DateTimeProvider();
        var menuDatabase = new Database(Configuration.ConnectionString, logger);

        await using (var context = new RestraurantMenuContext(logger, menuDatabase)) {
            logger.LogInfo("Here is the Current Menu! (Using Time of Day Menu Strategy)");
            context.SetStrategy(new TimeOfDayMenuStrategy(menuDatabase, dateTimeProvider));
            await context.PublishMenu();

            //we can use another stratgy at run tim without using a different context object.
            logger.LogInfo("here is the Current Menu! (Using  Price Range Menu Strategy $$$$$)");
            context.SetStrategy(new PriceRangeMenuStrategy(menuDatabase));
            await context.PublishMenu();
        };
        logger.LogInfo("Visit us again soon!");
    }
}