
using RealisticDependencies.Logger;
using RealisticDependencies.PaymentProcessing;
using StructualPatterns.Bridge.Vendors;

namespace ExamplePrograms.StructuralExamples.FarmersMarketSimulatr;

internal class Program {
    /// <summary>
    /// this example uses the Bridge Pattern to separate high-level abstractions from implementation details
    /// we have a farmer market, where different types of vendors process payments using different
    /// types of Payment Processing Services, including credit cards and gift cards.
    /// 
    /// The "Bridge" is the has-a relationship between vendors and their payment processors.
    /// Any FarmersMarketVendor has an object that implements the IProcessesPayments interface.
    /// Because every concrete FarmersMarketVendor is programmed to work
    /// with the high-level IProcessesPayment interface,
    /// 
    /// The Vendor logic can be extended  independently of the implementations of the payment processors. Likewise,
    /// the implementators of IProcessesPayments know nothing about the context in which they are used, and can be treated like a 
    /// plugin, in fact, they can be used in many other contexts, so they have been extracted to the RealisticDependencies 
    /// class library.
    /// By using object composition in this way, we avoid creating 
    /// ano exponential explosion in a potential subclass hierarchy for 
    /// specific vendor-processor combinations
    /// </summary>
    /// <param name="args"></param>
    private static void Main(string[] args) {
        var logger = new ConsoleLogger();

        logger.LogInfo("  Welcome to the Farmer's Market!");

        const string organicGardens= "Organic Gardens";
        const string olsenFarm= "Olsen Farm";
        const string andersenFarm= "Anderson Farm";
        const string pleasantValley= "Pleasant Valley";
        const string hillsideRanch= "Hillside Ranch";

        var creditCardProcessor = new CreditCardPrcoessor();
        var giftCardProcessor = new GiftCardPrcoessor();

        var booth1 = new VegetableFarmer(creditCardProcessor, logger);
        var booth2 = new VegetableFarmer(giftCardProcessor, logger);
        var booth3 = new CattleFarmer(creditCardProcessor, logger);
        var booth4 = new Florist(creditCardProcessor, logger);
        var booth5 = new Florist(giftCardProcessor, logger);

        booth1.ProcessCustomerPayment(10.00m, organicGardens);
        booth1.ProcessCustomerPayment(12.00m, organicGardens);
        booth1.ProcessCustomerPayment(1.50m, organicGardens);

        booth2.ProcessCustomerPayment(15.50m, olsenFarm);

        booth3.ProcessCustomerPayment(5.00m, andersenFarm);
        booth3.ProcessCustomerPayment(5.00m, andersenFarm);
        booth3.ProcessCustomerPayment(5.00m, andersenFarm);


        booth4.ProcessCustomerPayment(12.00m, pleasantValley);
        booth4.ProcessCustomerPayment(11.00m, pleasantValley);

        booth5.ProcessCustomerPayment(5.00m, hillsideRanch);
    }
}