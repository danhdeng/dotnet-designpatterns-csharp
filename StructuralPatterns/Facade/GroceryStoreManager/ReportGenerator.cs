using RealisticDependencies.Logger;
using StructuralPatterns.Facade.Interfaces;

namespace StructualPatterns.Facade.GroceryStoreManager;

public class ReportGenerator : IReportGenerator {
    private readonly IApplicationLogger _logger;

    public ReportGenerator(IApplicationLogger logger) {
        _logger = logger;
    }
    public string GenerateReportLog(Report report) {
        _logger.LogInfo($"Generating Report | {report.Title}");
        return $"{report.Description}_{DateTime.UtcNow}";
    }
}