using BehavioralPatterns.Memento.Interfaces;
using RealisticDependencies.Logger;

namespace BehavioralPatterns.Memento;

public class CartClient {
    private readonly IShoppingCart _cart;
    private readonly IMementoCache _caretaker;
    private readonly IApplicationLogger _logger;

    public CartClient(
        IShoppingCart cart,
        IMementoCache caretaker,
        IApplicationLogger logger
        ) {

        _cart = cart;
        _caretaker = caretaker;
        _logger = logger;
    }

    public void Add(string doughnut) {
        //we persist the current state before updating the cart with a new doughnut
        var memento = _cart.Save();
        _caretaker.SafeKeepState(memento);
        _cart.AddDoughnut(doughnut);
        _logger.LogInfo($"(Cart Client) Added doughnut and persisted this event to memory: [{doughnut}]");
    }

    public void Undo() {
        var memento = _caretaker.GetPreviousStateAndUpdateMemory();
        if (memento == null) {
            _logger.LogError("(Cart Client) The Cart is empty");
            return;
        }
        _cart.Restore(memento);
        _logger.LogInfo("(Cart Client) Restored Cart to previous state");
    }

    public void Print() => _cart.PrintState();

    public void GetMemoryDump() {
        var memoryDump = _caretaker.PeekMemory();
        _logger.LogInfo(string.Join("\n", 
            memoryDump.Select(
                mem=> $"{mem.GetSnapshotDate()} | { mem.GetState()}")), 
        ConsoleColor.DarkBlue);
    }
}