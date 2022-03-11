using BehavioralPatterns.Visitor.Interfaces;
using RealisticDependencies.Logger;

namespace BehavioralPatterns.Visitor;

public class ReportRunner {
    private readonly IApplicationLogger _logger;

    public ReportRunner(IApplicationLogger logger) {
        _logger = logger;
    }

    public void RunReports(List<IVisitable<Report>> visitables, IVisitor<Report> visitor) 
    {
        _logger.LogInfo($"Running Report on {visitables.Count} Data Provider", ConsoleColor.Cyan);

        foreach (var component in visitables) { 
            var report = component.Accept(visitor);
            report?.Print();
        }
    }
}