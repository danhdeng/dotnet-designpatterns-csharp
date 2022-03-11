using BehavioralPatterns.Visitor.DataProcessors;

namespace BehavioralPatterns.Visitor.Interfaces;

public interface IVisitor<out T> where T : class {
    public T Visit(FloristDataProcessor processor);
    public T Visit(BakerDataProcessor processor);
    public T Visit(FarmerDataProcessor processor);

}
