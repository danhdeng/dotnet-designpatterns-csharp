using System;
using CreationalPatterns.AbstractFactory;

namespace CreationalPatterns.AbstractFactory.MealPlans.Vegetarian;

public class VegetarianDessertMenu : IMenu {
    public void PrintDescription() => Console.WriteLine("The vegetarian dessert menu features plant based baked goods and fresh fruit");

    public void PrintMenu() => Console.WriteLine("Brownie, Orange shebert, Blackberry Crisp");
}