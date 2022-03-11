using BehavioralPatterns.Visitor.DataProcessors;
using BehavioralPatterns.Visitor.Interfaces;
using RealisticDependencies.Logger;

namespace BehavioralPatterns.Visitor.Visitors;

public class SaleDataVisitor : IVisitor<SaleReport> {
    private readonly IApplicationLogger _logger;

    public SaleDataVisitor(IApplicationLogger logger) {
        _logger = logger;
    }

    public SaleReport Visit(FloristDataProcessor processor) {
        _logger.LogInfo("Visiting Florist for Sales Report", ConsoleColor.Magenta);
        var sales = processor.GetDailyOrderAmounts();
        return new SaleReport(_logger, DateTime.UtcNow, sales.Sum());
    }

    public SaleReport Visit(BakeryDataProcessor processor)
    {
        _logger.LogInfo("Visiting Bakery for Sales Report", ConsoleColor.Magenta);
        var sales = processor.GetDailyOrderAmounts();
        return new SaleReport(_logger, DateTime.UtcNow, sales.Sum());
    }

    public SaleReport Visit(FarmerDataProcessor processor)
    {
        _logger.LogInfo("Visiting Farmer for Sales Report", ConsoleColor.Magenta);
        var sales = processor.GetDailyOrderAmounts();
        return new SaleReport(_logger, DateTime.UtcNow, sales.Sum());
    }
}