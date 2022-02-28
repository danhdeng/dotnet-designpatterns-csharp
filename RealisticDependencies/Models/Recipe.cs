
namespace RealisticDependencies.Models;
public struct Recipe
{
    public Recipe(string name, int prepTimeInMinutes) {
        Name = name;
        PrepTimeInMinutes = prepTimeInMinutes;
    }

    public object Name { get;set; }
    public int PrepTimeInMinutes { get; private set; }
}

