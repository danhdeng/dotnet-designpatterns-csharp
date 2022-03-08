using RealisticDependencies.Logger;
using StructuralPatterns.Facade.Interfaces;

namespace StructualPatterns.Facade.GroceryStoreManager;

public class FinanceCalculator : IFinanceCalculator {
    private readonly IApplicationLogger _logger;

    public FinanceCalculator(IApplicationLogger logger) {
        _logger = logger;
    }
    public Task CalculateMonthTotalRevenue() {
        _logger.LogInfo("Calculate revenue for the month");
        return Task.CompletedTask;
    }

    public Task CalculateMonthTotalRevenueForVendor(string vendor)
    {
        _logger.LogInfo($"Calculate revenue for the month for vendor: {vendor} $100 ");
        return Task.CompletedTask;
    }
}