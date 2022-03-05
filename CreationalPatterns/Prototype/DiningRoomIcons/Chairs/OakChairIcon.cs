using CreationalPatterns.Prototype.Interfaces;

namespace CreationalPatterns.Prototype.DiningRoomIcons.Chairs;

public class OakChairIcon : IChairIcon
{
    public bool HasSeatCushions => false;
    public IDeepClonable DeepClone()
    {
        return this.CloneJson();
    }
}