using RealisticDependencies.Logger;

namespace BehavioralPatterns.TemplateMethod;


public abstract class CookBookRecipe
{
    protected readonly IApplicationLogger _logger;

    public CookBookRecipe(IApplicationLogger logger)
    {
        _logger = logger;
    }

    /// <summary>
    /// the template method defines the skeleton of an algorithm.
    /// steps are either implemented in the base class (here),
    /// Forcibly overridden in derived classes via inheritance(abstract),
    /// or Optionally overridden via inheritance (virtual)
    /// </summary>
    public void PrintSteps()
    {
        //Required Overridden - Book Title goes at the top of every recipe
        PrintTitle();

        //Base implementation - Equipment heading goes at the top of every recipe
        PrintEquipmentHeading();

        //Base implementation
        PrintIngredientHeading();

        //Required overridden
        PrintRequiredIngredients();

        //Required overridden (Hook)
        PrintPossibleSubstitutions();

        //Base Implementation
        PrintStepsHeading();
        PrintCookingSteps();

        //Required overridden
        PrintOptionalServingSuggestions();
    }

    private void PrintStepsHeading()
    {
        _logger.LogInfo("~ Cooking Steps  ~", ConsoleColor.Blue);

    }

    private void PrintIngredientHeading()
    {
        _logger.LogInfo("~ Ingredients List ~", ConsoleColor.Blue);

    }

    private void PrintEquipmentHeading()
    {
        _logger.LogInfo("~ Required Equipment ~", ConsoleColor.Blue);
    }

    protected abstract void PrintTitle();
    protected abstract void PrintRequiredEquipment();
    protected abstract void PrintRequiredIngredients();
    protected abstract void PrintCookingSteps();

    //Hooks can be optionally overridden by subclass. By Default,
    //they are empty.
    protected virtual void PrintPossibleSubstitutions() { }
    protected virtual void PrintOptionalServingSuggestions() { }


}