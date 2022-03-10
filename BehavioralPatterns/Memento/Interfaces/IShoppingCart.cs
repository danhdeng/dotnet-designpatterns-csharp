
namespace BehavioralPatterns.Memento.Interfaces;

public interface IShoppingCart
{
    void AddDoughnut(string doughnut);
    void PrintState();
    Memento Save();
    void Restore(Memento memento);
}


