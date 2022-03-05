using CreationalPatterns.Prototype.Interfaces;

namespace CreationalPatterns.Prototype;

public interface ITableIcon : IDeepClonable {
    public string GetTableTopShape();

    public int GetTableNumberOfLegs();
}