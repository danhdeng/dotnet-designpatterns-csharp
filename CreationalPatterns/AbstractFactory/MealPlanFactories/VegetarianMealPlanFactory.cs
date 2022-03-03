

using CreationalPatterns.AbstractFactory.Interfaces;
using CreationalPatterns.AbstractFactory.MealPlans.Vegetarian;
using RealisticDependencies.Logger;

namespace CreationalPatterns.AbstractFactory.MealPlanFactory;

public class VegetarianMealPlanFactory : IMealPlanFactory
{
    private readonly IApplicationLogger _logger;

    public VegetarianMealPlanFactory(IApplicationLogger logger)
    {
        _logger = logger;
    }

    public IMenu GenerateDessertsMenu()
    {
        _logger.LogInfo("== 🥭  Generating a Vegetarian Dessert Menu... == ");
        return new VegetarianDessertMenu();
    }

    public IMenu GenerateLunchesMenu()
    {
        _logger.LogInfo("== 🥕 Generating a Vegetarian Lunch Menu... == ");
        return new VegetarianLunchMenu();
    }

    public IShoppingList GenerateShoppingList()
    {
        _logger.LogInfo("== 🥕 Generating a Vegetarian Shopping List... == ");
        return new VegetarianShoppingList();
    }


}