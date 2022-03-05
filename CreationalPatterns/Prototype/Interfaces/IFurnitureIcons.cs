namespace CreationalPatterns.Prototype.Interfaces;

public interface IFurnitureIcons: IDeepClonable {
    public string GetDescription();
    public int GetWeightLbs();
    public string GetColor();

}