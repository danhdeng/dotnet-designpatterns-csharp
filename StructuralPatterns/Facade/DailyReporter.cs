using RealisticDependencies;
using RealisticDependencies.API;
using RealisticDependencies.Database;
using RealisticDependencies.Logger;
using RealisticDependencies.Provider;
using StructualPatterns.Facade.GroceryStoreManager;
using StructuralPatterns.Facade.Interfaces;

namespace StructualPatterns.Facade;


/// <summary>
/// Facade Example
/// 
/// We are not using dependency injection here to simply the exmaple,
/// The Daily Reporter provide a facade over the complex interactions
/// required to work with the GroceryStoreManager functionality.
/// 
/// the Clients have a very simple interface to complete more
/// complex busines logic hidden by the facade.
/// </summary>
public class DailyReporter {
    private readonly IApplicationLogger _logger;
    private readonly IFinanceCalculator _finance;
    private readonly IInventoryManager _inventory;
    private readonly IReportGenerator _report;
    private readonly IVendorNotifier _vendors;
    private readonly ISendMails _emailer=new Emailer(new ConsoleLogger());
    private readonly IAmqpQueue _queue=new CloudQueue(new ConsoleLogger());
    private readonly IDatabase _database=new Database(Configuration.ConnectionString, new ConsoleLogger());
    private readonly IRecipesApi _api=new RecipesApi(new ConsoleLogger());

    public DailyReporter() {
        _finance = new FinanceCalculator(new ConsoleLogger());
        _inventory = new InventoryManager(_emailer, _queue, _database, _api, new ConsoleLogger());
        _report = new ReportGenerator(new ConsoleLogger());
        _vendors = new VenderNotifier(_database, _emailer, new ConsoleLogger());
        _logger =new ConsoleLogger();
    }

    public void KickOffProduceReport() { 
        _finance.CalculateMonthTotalRevenue();
        _inventory.ProcessCurrentInventoryReport();
        var vendors = _vendors.GetVendorsForDepartment("Produce");
        foreach (var vendor in vendors) { 
            _vendors.NotifyVendorOfCurrentStock(vendor);
            _finance.CalculateMonthTotalRevenueForVendor(vendor);
        }

        var report = new Report {
            Title = "Daily Produce Report",
            Description = "The Daily produce report details..."
        };

        var reportLog = _report.GenerateReportLog(report);

        _logger.LogInfo(reportLog);
    }
}