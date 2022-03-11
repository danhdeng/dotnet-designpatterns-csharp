using BehavioralPatterns.Visitor.DataProcessors;
using BehavioralPatterns.Visitor.Interfaces;
using RealisticDependencies.Logger;

namespace BehavioralPatterns.Visitor.Visitors;

public class MarketResearchReportVisitor : IVisitor<MarketResearchReport> {
    private readonly IApplicationLogger _logger;

    public MarketResearchReportVisitor(IApplicationLogger logger) {
        _logger = logger;
    }

    public MarketResearchReport Visit(FloristDataProcessor processor) { 
        var customerProfiles=processor.GetMonthlyCustomerProfiles();
        var customerAges=customerProfiles.Select(customer=>customer.Age).ToList();  
        var averageAge=(decimal) Math.Round(customerAges.Average(),2);
        var youngestAge = customerAges.Min();
        var oldestAge =customerAges.Max();
        _logger.LogInfo("Visiting Florist for Generating Market Report", ConsoleColor.Green);
        var report = new MarketResearchReport(_logger);
        report.SetData(customerProfiles.Count, averageAge, oldestAge, youngestAge);
        return report;
    }

    public MarketResearchReport Visit(BakeryDataProcessor processor)
    {
         var customerProfiles=processor.GetMonthlyCustomerProfiles();
        var customerAges=customerProfiles.Select(customer=>customer.Age).ToList();  
        var averageAge=(decimal) Math.Round(customerAges.Average(),2);
        var youngestAge = customerAges.Min();
        var oldestAge =customerAges.Max();
        _logger.LogInfo("Visiting Bakery for Generating Market Report", ConsoleColor.Green);
        var report = new MarketResearchReport(_logger);
        report.SetData(customerProfiles.Count, averageAge, oldestAge, youngestAge);
        return report;
    }

    public MarketResearchReport Visit(FarmerDataProcessor processor)
    {
        _logger.LogDebug("Market research is not yet available for Farm Data");
        return null;
    }
}