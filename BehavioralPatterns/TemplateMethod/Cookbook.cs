using RealisticDependencies.Logger;

namespace BehavioralPatterns.TemplateMethod;

public class Cookbook {
    private readonly IApplicationLogger _logger;
    private readonly List<CookBookRecipe> _recipes;

    public Cookbook(IApplicationLogger logger, List<CookBookRecipe> recipes) {
        _logger = logger;
        _recipes = recipes;
    }

    public void Print() {
        foreach (var recipe in _recipes) { 
            recipe.PrintSteps();
            _logger.LogInfo("----------------------------------", ConsoleColor.DarkMagenta);
        }
    }
}

