

using CreationalPatterns.AbstractFactory.Interfaces;
using CreationalPatterns.AbstractFactory.MealPlans.Keto;
using RealisticDependencies.Logger;

namespace CreationalPatterns.AbstractFactory.MealPlanFactory;

public class KetoMealPlanFactory : IMealPlanFactory {
    private readonly IApplicationLogger _logger;

    public KetoMealPlanFactory(IApplicationLogger logger) {
        _logger = logger;
    }

    public IMenu GenerateDessertsMenu() {
        _logger.LogInfo("== 🍨 Generating a Keto Dessert Menu... == ");
        return new KetoDessertMenu();
    }

    public IMenu GenerateLunchesMenu()
    {
        _logger.LogInfo("== 🍨 Generating a Keto Lunch Menu... == ");
        return new KetoLunchMenu();
    }

    public IShoppingList GenerateShoppingList()
    {
        _logger.LogInfo("== 🍨 Generating a Keto Shopping List... == ");
        return new KetoShoppingList();
    }


}