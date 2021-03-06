
using RealisticDependencies.Logger;

namespace BehavioralPatterns.Visitor;

public class MarketResearchReport:Report
{
    public MarketResearchReport(IApplicationLogger logger):base(logger) {
        CreatedBy = "MarketResearchBot";
        CreatedOn = DateTime.Now;
    }

    public int NumberOfSamples { get; set; }
    public decimal AverageAge { get; private set; }
    public object OldestCustomer { get; private set; }
    public int YoungestCustomer { get; private set; }

    public void SetData(int sampleCount, decimal averageAge, int oldest, int youngest) { 
        NumberOfSamples = sampleCount;
        AverageAge = averageAge;
        OldestCustomer = oldest;
        YoungestCustomer = youngest;
    }

    public override void Print() {
        _logger.LogInfo($"=== 📊 Market Research for {CreatedOn} 📊 ===", ConsoleColor.Cyan);
        _logger.LogInfo($"=== Generated By: {CreatedBy} ===", ConsoleColor.Cyan);
        _logger.LogInfo($"- Number of Samples Today: {NumberOfSamples}", ConsoleColor.Cyan);
        _logger.LogInfo($"- Average Customer Age: {AverageAge}", ConsoleColor.Cyan);
        _logger.LogInfo($"- Oldest Customer: {OldestCustomer}", ConsoleColor.Cyan);
        _logger.LogInfo($"- Youngest Customer: {YoungestCustomer}", ConsoleColor.DarkCyan);
        _logger.LogInfo("\n");
    }

}
