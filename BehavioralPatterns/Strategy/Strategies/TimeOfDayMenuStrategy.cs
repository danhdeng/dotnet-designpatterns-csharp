using BehavioralPatterns.Strategy.Interfaces;
using BehavioralPatterns.Strategy.Models;
using Newtonsoft.Json;
using RealisticDependencies.Database;
using RealisticDependencies.Provider;

namespace BehavioralPatterns.Strategy.Strategies;

public class TimeOfDayMenuStrategy : IMenuGenatrationStrategy
{
    private readonly IDatabase _menuDatabase;
    private readonly IDateTimeProvider _date;
    private List<MenuItem> _allMenuItems;

    /// <summary>
    /// here we have a menu building strategy that accounts for the time
    /// of day - we return a menu items containing only items specific to
    /// breakfast, lunch or dinner, depending on the time of reported
    /// by our IDateTimeProvider
    /// </summary>
    /// <param name="menuDatabase"></param>
    /// <param name="date"></param>
    public TimeOfDayMenuStrategy(
        IDatabase menuDatabase,
        IDateTimeProvider date
        ) {
        _menuDatabase = menuDatabase;
        _date = date;
    }


    /// <summary>
    /// the method required by the interface to implement this strategy
    /// </summary>
    /// <returns></returns>
    public async Task<Menu> GenerateMenu() {
        var serializeMenuItems = await _menuDatabase.GetAllData();

        _allMenuItems=serializeMenuItems
            .Select(item=>JsonConvert.DeserializeObject<MenuItem>(item))
            .ToList();

        var isBreakfastItem = _date.IsMorning();
        var isLunchItem = _date.IsAfternoon();
        var isDinnerItem = _date.IsEvening();

        if (isBreakfastItem) { return GenerateBreakfastMenu(); }
        if (isLunchItem) { return GenerateLunchMenu(); }
        return GenerateDinnerMenu();


    }

    private Menu GenerateDinnerMenu()
    {
        var options = new List<string> { "curry rice", "wild rice soup" };
        var dinnerItems=_allMenuItems.Where(item=>options.Contains(item.Name)).ToList();
        return new Menu(dinnerItems);
    }

    private Menu GenerateLunchMenu()
    {
        var options = new List<string> { "black bean burrito", "chips and salsa" };
        var lunchItems = _allMenuItems.Where(item => options.Contains(item.Name)).ToList();
        return new Menu(lunchItems);
    }

    private Menu GenerateBreakfastMenu()
    {
        var options = new List<string> { "scramble eggs", "french toast", "bagel with lox" };
        var breakfastItems = _allMenuItems.Where(item => options.Contains(item.Name)).ToList();
        return new Menu(breakfastItems);
    }
}
