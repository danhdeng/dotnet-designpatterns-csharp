
namespace StructuralPatterns.Facade.Interfaces;

public interface IFinanceCalculator
{
    Task CalculateMonthTotalRevenue();
    Task CalculateMonthTotalRevenueForVendor(string vendor);

}
