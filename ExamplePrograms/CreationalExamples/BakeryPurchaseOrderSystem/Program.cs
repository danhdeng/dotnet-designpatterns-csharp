using CreationalPatterns.Builder;
using CreationalPatterns.Builder.Builders;
using CreationalPatterns.Builder.Models;
using RealisticDependencies;
using RealisticDependencies.Database;
using RealisticDependencies.Logger;

namespace BakeryPurchaseOrderSystem {
    /// <summary>
    /// one of the benefits of the builder pattern is that the algorithms for constructing
    /// an object are independent of the parts that make up the object and hwo they are assembled.
    /// 
    /// we can demonstrated two parts of the builder pattern approaches:
    /// - Builder and Director collaboration,
    /// where depending on the concrete type of Builder provided to the Director,
    /// a difference Purchase Order will be generated.
    /// We can encaposulate the building of a Purchase Order for particular vendors in their own builder types.
    /// 
    /// -- Fluent Builder Pattern,
    /// 
    /// we allow the creation of custome purchase orders using a fluent syntax to set custom properties on
    /// instances of the same PurchaseOrder type. In C#, we can also make it very easy to cast our Builder
    /// (where the construction logic is defined) into the Type of object it builds using an implicit operator.
    /// </summary>
    internal class Program {
        private async static Task Main() {
            //First Approach -- Typical Gang of Four Builder Pattern (Director <-- Builder)
            
            //Variables
            var logger = new ConsoleLogger();
            var database = new Database(Configuration.ConnectionString, logger);


            //Concrete Builders
            var bakeryPurchaseOrderBuilder = new BakeryPurchaseOrderBuilder();
            var coffeePurchaseOrderBuilder = new CoffeePurchaseOrderBuilder();

            //Director
            var purchaseOrderProcessor = new PurchaseOrderProcessor(logger, database);

            //Generating purchase order
            await purchaseOrderProcessor.GenerateWeeklyPurchaseOrder(bakeryPurchaseOrderBuilder);
            await purchaseOrderProcessor.GenerateWeeklyPurchaseOrder(coffeePurchaseOrderBuilder);


            //Second Approach - "Custom" builder using a fluent syntax
            var customOrder = new FluentPurchaseOrderBuilder();
            var items = new List<LineItem> {
                new ("cups",100, 1.0m),
                new ("napkins",250, 0.3m),
            };

            var supplier = new Supplier("Dan", "contact@danvansolutioninc.com", "dan h deng");

            customOrder
                .WithId("Custom Order")
                .AtAddress("123 Scarborough Golfclub")
                .ForCompany("Danvan Solution Inc")
                .FromSupplier(supplier)
                .RequestDate(DateTime.UtcNow.AddDays(2))
                .ForItems(items);

            await purchaseOrderProcessor.SavePurchaseOrderToDatabase(customOrder);
            purchaseOrderProcessor.PrintPurchaseOrder(customOrder);
        }
    }
}