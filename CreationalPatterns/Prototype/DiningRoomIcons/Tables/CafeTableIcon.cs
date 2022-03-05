using CreationalPatterns.Prototype.Interfaces;

namespace CreationalPatterns.Prototype.DiningRoomIcons.Tables {
    public class CafeTableIcon : ITableIcon
    {
        public IDeepClonable DeepClone()
        {
            return this.CloneJson();
        }

        public int GetTableNumberOfLegs() => 3;

        public string GetTableTopShape() => "round";
    }
}