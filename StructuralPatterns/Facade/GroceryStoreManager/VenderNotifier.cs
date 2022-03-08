using RealisticDependencies.Database;
using RealisticDependencies.Logger;
using RealisticDependencies.Provider;
using StructuralPatterns.Facade.Interfaces;

namespace StructualPatterns.Facade.GroceryStoreManager;

public class VenderNotifier : IVendorNotifier {
    private readonly IDatabase _database;
    private readonly ISendMails _emailer;
    private readonly IApplicationLogger _logger;

    public VenderNotifier(
        IDatabase database,
        ISendMails emailer,
        IApplicationLogger logger
        ) {
        _database = database;
        _emailer = emailer;
        _logger = logger;
    }

    public Task NotifyVendorOfCurrentStock(string vendor) {
        _logger.LogInfo($"Notifying Vendor: {vendor}");
        return Task.CompletedTask;
    }

    public List<string> GetVendorsForDepartment(string department) {
        //Cound use its own dependencies like the database
        if (department == "produce")
        {
            return new List<string> {
                "Organic Orchards",
                "McKinnon Farm",
                "Pleasant Valley Farms"
            };
        }
        return new();
    }
}