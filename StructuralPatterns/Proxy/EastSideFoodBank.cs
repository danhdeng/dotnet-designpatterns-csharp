using RealisticDependencies.Logger;

namespace StructualPatterns.Proxy;

public class EastSideFoodBank : IAcceptFoodBankDonations {
    private readonly FoodBankService _foodBank;
    private readonly IApplicationLogger _logger;
    private readonly List<string> _unacceptableItems = new()
    {
        "candy",
        "alcohol",
        "tobacco",
        "dairy"
    };


    public EastSideFoodBank(FoodBankService foodBank, IApplicationLogger logger) {
        _foodBank = foodBank;
        _logger = logger;
    }

    public void DonateFood(string food) {
        if (!CheckDonationAcceptable(food)) {
            LogUnAcceptableItem(food);
            return;
        }
        LogAcceptableDonation(food);
        _foodBank.DonateFood(food);
    }

    public List<string> GetBankCache() {
        LogCacheReadRequest();
        return _foodBank.FoodBankCache;
    }

    private void LogCacheReadRequest()
    {
        _logger.LogInfo($"{DateTime.UtcNow} | EastSideFoodBank Reporting Access to Cache Read", ConsoleColor.Green);
    }

    private void LogAcceptableDonation(string food)
    {
        _logger.LogInfo($"{DateTime.UtcNow} | EastSideFoodBank Reporting Request to Donate: {food}", ConsoleColor.Green);
    }

    private void LogUnAcceptableItem(string invalidItem)
    {
        _logger.LogInfo($"{DateTime.UtcNow} | EastSideFoodBank Reporting Request to Donate: {invalidItem}", ConsoleColor.Red);
        _logger.LogError($"Sorry, we cannot accept donations of {invalidItem} at this time.");

    }

    private bool CheckDonationAcceptable(string food)
    {
       return !_unacceptableItems.Contains(food);
    }
}