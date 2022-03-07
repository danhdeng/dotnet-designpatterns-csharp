

using RealisticDependencies.Logger;
using RealisticDependencies.PaymentProcessing;

namespace StructualPatterns.Bridge.Vendors;

public class Florist : FarmersMarketVendor
{
    private readonly IProcessesPayments _paymentProcessor;
    private readonly IApplicationLogger _logger;

    public Florist(IProcessesPayments paymentProcessor, IApplicationLogger logger) : base(paymentProcessor)
    {
        _paymentProcessor = paymentProcessor;
        _logger = logger;
    }

    public override string ProcessCustomerPayment(decimal payment, string vendorName)
    {
        _logger.LogInfo($"Florist: {vendorName} is processing" + $"a ${payment} payment for a vial of laveder oil");
        return _paymentProcessor.HandlePayment(payment);
    }
}