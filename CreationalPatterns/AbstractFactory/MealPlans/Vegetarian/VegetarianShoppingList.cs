using System;
using CreationalPatterns.AbstractFactory;

namespace CreationalPatterns.AbstractFactory.MealPlans.Vegetarian;

public class VegetarianShoppingList : IShoppingList
{
    public List<string> MakeShoppingList() => 
        new() {"black beans, spices, kale, cucumber", "mangoes", "apples", "pears"};

}