

using RealisticDependencies.Logger;
using RealisticDependencies.PaymentProcessing;

namespace StructualPatterns.Bridge.Vendors;

public class VegetableFarmer : FarmersMarketVendor
{
    private readonly IProcessesPayments _paymentProcessor;
    private readonly IApplicationLogger _logger;

    public VegetableFarmer(IProcessesPayments paymentProcessor, IApplicationLogger logger) : base(paymentProcessor)
    {
        _paymentProcessor = paymentProcessor;
        _logger = logger;
    }

    public override string ProcessCustomerPayment(decimal payment, string vendorName)
    {
        _logger.LogInfo($"Vegetalbe Farmer: {vendorName} is processing" + $"a ${payment} payment for a bag fo organic carrots");
        return _paymentProcessor.HandlePayment(payment);
    }
}