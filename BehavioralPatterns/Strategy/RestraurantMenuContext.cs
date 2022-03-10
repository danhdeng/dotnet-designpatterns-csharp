using BehavioralPatterns.Strategy.Interfaces;
using BehavioralPatterns.Strategy.Models;
using Newtonsoft.Json;
using RealisticDependencies.Database;
using RealisticDependencies.Logger;

namespace BehavioralPatterns.Strategy;

public class RestraurantMenuContext : IAsyncDisposable {
    /// <summary>
    /// this context works with an obejct instance that implements IStrategy.
    /// It always works with the interface.
    /// </summary>
    private IMenuGenatrationStrategy _strategy;
    private readonly IApplicationLogger _logger;
    private readonly IDatabase _menuDatabase;

    /// <summary>
    /// this constructor variation presets the context with a strategy.
    /// we can also mutate the strategy at runtime by exposing setter method.
    /// </summary>
    /// <param name="strategy"></param>
    /// <param name="logger"></param>
    /// <param name="menuDatabase"></param>
    public RestraurantMenuContext(
        IMenuGenatrationStrategy strategy,
        IApplicationLogger logger,
        IDatabase menuDatabase)
    { 
        _strategy = strategy;
        _logger = logger;
        _menuDatabase = menuDatabase;

        //Connect and see the database with all possible menu items
        //we can provide we close the connection when we dispose of this context.
        InitializeDatabase().Wait();
    }

    public RestraurantMenuContext(
        IApplicationLogger logger, IDatabase menuDatabase)
    { 
        _logger = logger;
        _menuDatabase = menuDatabase;

        //Connect and see the database with all possible menu items
        //we can provide we close the connection when we dispose of this context.
        InitializeDatabase().Wait();
    }

    public void SetStrategy(IMenuGenatrationStrategy strategy) {
        _strategy = strategy;
    }

    /// <summary>
    /// the context delegates some work to the strategy object instead of 
    /// implementing multiple versions fo the algorithm on its own.
    /// </summary>
    /// <returns></returns>
    public async Task PublishMenu() {
        _logger.LogInfo("Generating the Menu");
        var currentMenu=await _strategy.GenerateMenu();
        foreach (var item in currentMenu.MenuItems) {
            _logger.LogInfo(
                    $"- {item.Name} | {item.Description} | {item.Price}", ConsoleColor.Cyan);
        }
    }

    private async Task InitializeDatabase()
    {
        await _menuDatabase.Connect();
        var semaphore = new SemaphoreSlim(1);
        await semaphore.WaitAsync();

        _logger.LogInfo("Seeding full menu into the database", ConsoleColor.Green);
        var allMenuItems = GetAllMenuItems();
        var listOfInserts = new List<Task>();

        try
        {
            foreach (var item in allMenuItems)
            {
                var jsonItem = SerializeMenuItemAsJson(item);
                var task = _menuDatabase.WriteData(item.Name, jsonItem);
                listOfInserts.Add(task);
            }
            await Task.WhenAll(listOfInserts);
        }
        finally {
           //await _menuDatabase.Disconnect();
            semaphore.Release();
        }
    }

    private string SerializeMenuItemAsJson(MenuItem item) => JsonConvert.SerializeObject(item);
   

    private static List<MenuItem> GetAllMenuItems() => new()
    {
        new("scrambled eggs", "2 scrambled eggs with coffee", 1.20m),
        new("french toast", "3 pieces of french toast with maple syrup", 3.25m),
        new("bagel with lox", "wheat bagel with cream cheese and lox", 2.10m),
        new("black bean burrito", "black beans, lettuce, cheese", 3.80m),
        new("chips and salsa", "corn chips and fresh salsa", 2.40m),
        new("curry rice", "peanut curry sauce with white rice", 3.20m),
        new("wild rice soup", "wild rice with carrots, celery, peppers", 5.20m),
    };

    public async ValueTask DisposeAsync()
    {
        await _menuDatabase.Disconnect();
    }

}