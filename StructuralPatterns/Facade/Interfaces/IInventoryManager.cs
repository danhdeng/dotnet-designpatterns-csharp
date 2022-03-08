

namespace StructuralPatterns.Facade.Interfaces;

public interface IInventoryManager
{
    Task ProcessCurrentInventoryReport();
    Task UpdateInventory();
}

