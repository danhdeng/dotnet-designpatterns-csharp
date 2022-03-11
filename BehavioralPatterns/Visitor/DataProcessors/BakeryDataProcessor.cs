using BehavioralPatterns.Visitor.Interfaces;
using Newtonsoft.Json;
using RealisticDependencies.Database;
using RealisticDependencies.Models;
using RealisticDependencies.Provider;

namespace BehavioralPatterns.Visitor.DataProcessors;

public class BakerDataProcessor : IVisitable<Report> {
    private readonly ISendMails _emailer;
    private readonly Database _database;

    public BakerDataProcessor(ISendMails emailer,
        Database database
        ) {
        _emailer=emailer;
        _database = database;    
    }

    public async Task EmailReceipt(Person customer) {
        var email = new EmailMessage(customer.Email, "Thank you for your Bakery order. Here is your receipt.");
        await _emailer.SendMessage(email);
    }

    public async Task IngestDailyOrders() {
        var serializedOrders = new List<string>();

        var rng=new Random();

        for (var i = 0; i < 1000; i++) {
            var order = new Order()
            {
                TimeOfPurchase = DateTime.UtcNow,
                LineItems = new List<string>(),
                TotalPrice = (decimal)Math.Round(rng.NextDouble() * 10, 2),
            };

            var payload = await Task.Factory.StartNew(() => JsonConvert.SerializeObject(order));
            serializedOrders.Add(payload);
        }

        foreach (var order in serializedOrders) { 
            await _database.WriteData(Guid.NewGuid().ToString(), order);    
        }
    }

    public List<decimal> GetDailyOrderAmounts() { 
        var rng=new Random();
        var dailyOrders=new List<decimal>();
        for (var i = 0; i < 1000; i++) { 
            var orderAmont=(decimal)Math.Round(rng.NextDouble() * 100, 2);
            dailyOrders.Add(orderAmont);
        }
        return dailyOrders;
    }

    public List<Person> GetMonthlyGustomerProfiles() { 
        var rng=new Random();
        var customers=new List<Person>();
        for (var i = 0; i < 1000; i++) {
            var age = rng.Next(18, 100);
            var person = new Person
            {
                Age = age,
                Name = "Bakery Customer",
                Email = "foo@example.com"
            };
            customers.Add(person);
        }
        return customers;   
    }

    public Report Accept(IVisitor<Report> visitor)
    {
        return visitor.Visit(this);
    }
}