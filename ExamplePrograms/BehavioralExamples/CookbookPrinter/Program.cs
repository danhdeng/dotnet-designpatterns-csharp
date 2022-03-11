using BehavioralPatterns.TemplateMethod;
using BehavioralPatterns.TemplateMethod.Recipes;
using RealisticDependencies.Logger;

namespace ExamplePrograms.BehavioralPrograms.CookbookPrinter;

internal class Program
{
    /// <summary>
    /// the cookbook printing store will allow chefs send in their favorite home-made
    /// recipes to be printed in a self-published family cookbooks.
    /// 
    /// Many of the steps in our printing press operations for cookbooks are the same,
    /// except for the details of the concrete recipes send in by our clients. 
    /// we can leverage a template method to provide optional virtual hooks and 
    /// required abtract methods in a base class that defined our printing algorithm
    /// to print specific for the book.
    /// </summary>
    private static void Main()
    {
        var logger = new ConsoleLogger();
        logger.LogInfo("📘 Welcome to the Cookbook Printer");

        var clientRecipes = new List<CookBookRecipe> {
            new CakeRecipe(logger),
            new CurryRecipe(logger)
        };
        var cookbook = new Cookbook(logger, clientRecipes);

        cookbook.Print();
    }
}
