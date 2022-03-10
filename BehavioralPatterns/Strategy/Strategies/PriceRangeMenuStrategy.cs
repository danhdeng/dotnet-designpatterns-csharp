using BehavioralPatterns.Strategy.Interfaces;
using BehavioralPatterns.Strategy.Models;
using Newtonsoft.Json;
using RealisticDependencies.Database;

namespace BehavioralPatterns.Strategy.Strategies;

public class PriceRangeMenuStrategy : IMenuGenatrationStrategy {
    private readonly IDatabase _menuDatabase;

    private const decimal PriceThreshold = 3m;
    public PriceRangeMenuStrategy(IDatabase menuDatabase) {
        _menuDatabase = menuDatabase;
    }

    /// <summary>
    /// The method required by the interface to implement this strategy
    /// 
    /// </summary>
    /// <returns></returns>
    public async Task<Menu> GenerateMenu()
    {
        var allMenuItems = await _menuDatabase.GetAllData();
        var allMenuItemsDeserialized = allMenuItems.Select(item => JsonConvert.DeserializeObject<MenuItem>(item));
        var filterItems=new List<MenuItem>(allMenuItemsDeserialized)
                        .Where(item=>item.Price>PriceThreshold)
                        .ToList();
        return new Menu(filterItems);

        
    }
}
