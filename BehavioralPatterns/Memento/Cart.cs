using BehavioralPatterns.Memento.Interfaces;
using RealisticDependencies.Logger;

namespace BehavioralPatterns.Memento;

public class Cart : IShoppingCart {
    private readonly IApplicationLogger _logger;
    private string _state;
    public Cart(IApplicationLogger logger) {
        _logger = logger;
    }
    public void AddDoughnut(string doughnut) {
        _state += $"_{doughnut}";
        _logger.LogInfo("(Cart) added a doughnut to the cart", ConsoleColor.DarkGray);
        Save();
    }
    public void PrintState() => _logger.LogInfo($"(Cart) {_state}", ConsoleColor.Green);
    
    /// <summary>
    /// Save the cart state in a memeto object.
    /// </summary>
    /// <returns></returns>
    public Memento Save()=>new CartMemento(_state);

    /// <summary>
    /// Restores the Cart's state from a Memeto object.
    /// </summary>
    /// <param name="memento"></param>
    public void Restore(Memento memento) {
        if (!(memento is CartMemento)) {
            throw new InvalidOperationException($"Concrete Memeto instance required.");
        }
        _state=memento.GetState();
        _logger.LogInfo($"Restored cart to a previous state:{_state}", ConsoleColor.DarkGray);
    }
}