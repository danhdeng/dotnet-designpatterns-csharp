
namespace StructuralPatterns.Facade.Interfaces;

public struct Report
{
    public string Title;
    public string Description;
}

public interface IReportGenerator
{
    string GenerateReportLog(Report report);
}

