
namespace StructuralPatterns.Facade.Interfaces;
public interface IVendorNotifier
{
    Task NotifyVendorOfCurrentStock(string vendor);

    List<string> GetVendorForDepartment(string dept);
}