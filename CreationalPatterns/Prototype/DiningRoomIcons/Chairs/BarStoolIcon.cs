using CreationalPatterns.Prototype.Interfaces;

namespace CreationalPatterns.Prototype.DiningRoomIcons.Chairs;

public class BarStoolIcon : IChairIcon {
    public bool HasSeatCushions => true;
    public IDeepClonable DeepClone() {
        return this.CloneJson();
    }
}