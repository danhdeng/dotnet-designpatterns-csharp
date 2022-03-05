using CreationalPatterns.Builder.Interfaces;
using CreationalPatterns.Builder.Models;
using Newtonsoft.Json;
using RealisticDependencies.Database;
using RealisticDependencies.Logger;

namespace CreationalPatterns.Builder;

/// <summary>
/// The "Director" class in this Builder Pattern example
/// </summary>
public class PurchaseOrderProcessor {
    private readonly IApplicationLogger _logger;
    private readonly IDatabase _database;

    public PurchaseOrderProcessor(IApplicationLogger logger, IDatabase database) {
        _logger = logger;
        _database = database;
    }

    public async Task GenerateWeeklyPurchaseOrder(IBuildsPurchaseOrders purchaseOrderBuilder) {
        var purchaseOrder = purchaseOrderBuilder.BuilPurchaseOrder();
        PrintPurchaseOrder(purchaseOrder);
        await SavePurchaseOrderToDatabase(purchaseOrder);
    }

    public async Task SavePurchaseOrderToDatabase(PurchaseOrder purchaseOrder)
    {
        _logger.LogInfo($"Saving Purchase Order ({purchaseOrder.Id}) to database");
        await _database.Connect();
        await _database.WriteData(purchaseOrder.Id, JsonConvert.SerializeObject(purchaseOrder));
        await _database.Disconnect();
    }



    public  void PrintPurchaseOrder(PurchaseOrder purchaseOrder)
    {
        _logger.LogInfo($"--------------------------------------------------", ConsoleColor.Blue);
        _logger.LogInfo($"== Generated Purchase Order ==", ConsoleColor.Blue);
        _logger.LogInfo($"--------------------------------------------------", ConsoleColor.Blue);
        _logger.LogInfo($"==ID: {purchaseOrder.Id}  {purchaseOrder.CreatedOn}", ConsoleColor.Blue);
        _logger.LogInfo($"== {purchaseOrder.CompanyName}", ConsoleColor.Blue);
        _logger.LogInfo($"== {purchaseOrder.CompanyAddress}", ConsoleColor.Blue);
        _logger.LogInfo($"--------------------------------------------------", ConsoleColor.Blue);
        _logger.LogInfo($"== Supplier: {purchaseOrder.Supplier.Name}", ConsoleColor.Blue);
        foreach (var item in purchaseOrder.LineItems) {
            _logger.LogInfo($"   - {item.Qty} x ({item.Name} @{Math.Round(item.UnitCost, 2)})");
        }
        _logger.LogInfo($"== Purchase Order Total: $ {Math.Round(purchaseOrder.TotalCost,2) }", ConsoleColor.Blue);
        _logger.LogInfo($"--------------------------------------------------", ConsoleColor.Blue);
        _logger.LogInfo($"== Deliver By: {purchaseOrder.RequestDate}", ConsoleColor.Blue);
        _logger.LogInfo($"--------------------------------------------------", ConsoleColor.Blue);

    }
}