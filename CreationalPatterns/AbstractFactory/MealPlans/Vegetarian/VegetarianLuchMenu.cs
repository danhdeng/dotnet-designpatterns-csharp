using System;
using CreationalPatterns.AbstractFactory;

namespace CreationalPatterns.AbstractFactory.MealPlans.Vegetarian;

public class VegetarianLunchMenu : IMenu
{
    public void PrintDescription() => Console.WriteLine("The vegetarian menu features plant-based options without new products");

    public void PrintMenu() => Console.WriteLine("Black Bean Soup, Green Curry, Salary");
}