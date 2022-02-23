namespace CreationalPatterns.AbstractFactory;

public interface IMenuPlanFactory {
    public IMenu GenerateLunchesMenu();
    public IMenu GenerateDessertsMenu();

    public IShoppingList GenerateShoppingList();
}