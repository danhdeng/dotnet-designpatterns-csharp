using RealisticDependencies.Logger;

namespace StructualPatterns.Proxy;

public class FoodBankService: IAcceptFoodBankDonations
{
    public FoodBankService(List<string> foodBankCache, IApplicationLogger logger) {
        FoodBankCache = foodBankCache;
        _logger = logger;
    }

    public List<string> FoodBankCache { get; }

    private readonly IApplicationLogger _logger;

    public void DonateFood(string food) { 
        _logger.LogInfo($"FoodBank handling request to donate: {food}");
        FoodBankCache.Add(food);
        _logger.LogInfo("Thank you for your donation.");
    }
}