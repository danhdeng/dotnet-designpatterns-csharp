using RealisticDependencies.API;
using RealisticDependencies.Logger;
using StructualPatterns.Adapter;

namespace ExamplePrograms.StructuralExamples.RecipeSearch;

internal class Program {
    /// <summary>
    /// We use the Adapter Patter to adapt the XML result we receive from the RecipesApi
    /// to work with our client-side code, which "only works" with JSON. Here we gain the
    /// benefit fo allowing the API dependency to just continue working as it needs to which
    /// changing the interface of our Adapter to match what's needed here in the client.
    /// 
    /// If the interface of the RecipesApi changes, or if its return type or structure get 
    /// updated. The client code here will likely remain unchanged, as we can then write a 
    /// new Adapter or update our existing Adapter code.
    /// </summary>
    /// <param name="args"></param>
    private static async Task Main(string[] args) {
        var logger = new ConsoleLogger();

        logger.LogInfo("   Aggregating Recipes from the API......");

        //The RecipesAPI Produces XML results
        var recipesApi = new RecipesApi(logger);

        //let 's adapt it with our RecipeFinder adapter to produce JSON instead
        var recipeFinder = new RecipeFinder(recipesApi);

        var mashedPotatosResult = recipeFinder.GetRecipeAsJson("mashed_potatoes");
        var greenBeanResult = recipeFinder.GetRecipeAsJson("green_beans");
        var redCurryResult = recipeFinder.GetRecipeAsJson("red_curry");

        var tasks=new List<Task<string>>{ 
            mashedPotatosResult,
            greenBeanResult,
            redCurryResult
        };
        await Task.WhenAll(tasks);

        // We only want to work with JSON in this client
        PrintJsonRecipes(tasks);
    }

    private static void PrintJsonRecipes(IEnumerable<Task<string>> recipes)
    {
        var logger=new ConsoleLogger();
        foreach (var recipe in recipes) {
            logger.LogInfo(recipe.Result);
        }
    }
}