using RealisticDependencies.API;
using RealisticDependencies.Database;
using RealisticDependencies.Logger;
using RealisticDependencies.Models;
using RealisticDependencies.Provider;
using StructuralPatterns.Facade.Interfaces;

namespace StructualPatterns.Facade.GroceryStoreManager;

/// <summary>
/// Mock class to stand in for a complex system for managing a 
/// grocery store. In order to hide the complexity of dealing with
/// these low-level processes, we can create a facade to work only
/// with what we need as a  client.
/// </summary>
public class InventoryManager : IInventoryManager {
    private readonly ISendMails _emailer;
    private readonly IAmqpQueue _queue;
    private readonly IDatabase _database;
    private readonly IRecipesApi _recipesApi;
    private readonly IApplicationLogger _logger;

    public InventoryManager(
         ISendMails emailer,
            IAmqpQueue queue,
            IDatabase database,
            IRecipesApi recipesApi,
            IApplicationLogger logger)
    {
        _emailer = emailer;
        _queue = queue;
        _database = database;
        _recipesApi = recipesApi;
        _logger = logger;
    }
    public async Task ProcessCurrentInventoryReport() {
        _logger.LogInfo("Processing Inventory....");
        Thread.Sleep(1_000);
        _logger.LogInfo("Sending Report to buyers....");
        Thread.Sleep(1_000);
        var emailMessage = new EmailMessage("buyers@example.com", "Inventory report ...");
        await _emailer.SendMessage(emailMessage);
        Thread.Sleep(500);
    }
    public Task UpdateInventory() {
        _logger.LogInfo("Updating Inventory....");
        Thread.Sleep(1_000);
        _logger.LogInfo("Persisting changes to Database...");
        Thread.Sleep(1_000);
        _logger.LogInfo("Database updated!");
        return Task.CompletedTask;
    }
}