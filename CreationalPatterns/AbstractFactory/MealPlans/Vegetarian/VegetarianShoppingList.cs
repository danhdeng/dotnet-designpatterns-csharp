using System;
using CreationalPatterns.AbstractFactory.Interfaces;

namespace CreationalPatterns.AbstractFactory.MealPlans.Vegetarian;

public class VegetarianShoppingList : IShoppingList
{
    public List<string> MakeShoppingList() => 
        new() {"black beans, spices, kale, cucumber", "mangoes", "apples", "pears"};

}