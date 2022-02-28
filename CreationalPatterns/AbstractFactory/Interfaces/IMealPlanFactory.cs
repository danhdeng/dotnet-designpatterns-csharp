namespace CreationalPatterns.AbstractFactory.Interfaces;

public interface IMealPlanFactory {
    public IMenu GenerateLunchesMenu();
    public IMenu GenerateDessertsMenu();

    public IShoppingList GenerateShoppingList();
}