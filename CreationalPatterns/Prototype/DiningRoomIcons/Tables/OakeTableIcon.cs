using CreationalPatterns.Prototype.Interfaces;

namespace CreationalPatterns.Prototype.DiningRoomIcons.Tables
{
    public class OakTableIcon : ITableIcon
    {
        public IDeepClonable DeepClone()
        {
            return this.CloneJson();
        }

        public int GetTableNumberOfLegs() => 4;

        public string GetTableTopShape() => "retangle";
    }
}