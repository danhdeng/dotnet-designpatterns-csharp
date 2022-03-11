using BehavioralPatterns.Visitor.Interfaces;
using Newtonsoft.Json;
using RealisticDependencies.Database;
using RealisticDependencies.Models;

namespace BehavioralPatterns.Visitor.DataProcessors;

public class FarmerDataProcessor : IVisitable<Report>
{
    private readonly Database _database;

    public FarmerDataProcessor(Database database)
    {
        _database = database;
        Task.Run(_database.Connect).Wait();
    }

    public async Task IngestDailyOrders()
    {
        var serializedOrders = new List<string>();
        var rng = new Random();
        for (var i = 0; i < 1000; i++)
        {
            var order = new Order
            {
                TimeOfPurchase = DateTime.UtcNow,
                LineItems = new List<string>(),
                TotalPrice = (decimal)Math.Round(rng.NextDouble() * 10, 2)
            };
            var payload=await Task.Factory.StartNew(() =>JsonConvert.SerializeObject(order));       
            serializedOrders.Add(payload);
        }
        foreach (var order in serializedOrders) { 
            await _database.WriteData(Guid.NewGuid().ToString(), order);
        }
    }

    public List<decimal> GetDailyOrderAmount() { 
        var rng=new Random();
        var dailyOrders=new List<decimal>();
        for(var i = 0; i < 1000; i++)
        {

            var orderAmount=(decimal)Math.Round(rng.NextDouble() * 100, 2);
            dailyOrders.Add(orderAmount);
        }
        return dailyOrders;
    }

    public Report Accept(IVisitor<Report> visitor) {
        return visitor.Visit(this);
    }
}