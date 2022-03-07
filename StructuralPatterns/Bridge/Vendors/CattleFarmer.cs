

using RealisticDependencies.Logger;
using RealisticDependencies.PaymentProcessing;

namespace StructualPatterns.Bridge.Vendors;

public class CattleFarmer : FarmersMarketVendor {
    private readonly IProcessesPayments _paymentProcessor;
    private readonly IApplicationLogger _logger;

    public CattleFarmer(IProcessesPayments paymentProcessor, IApplicationLogger logger):base(paymentProcessor) {
        _paymentProcessor = paymentProcessor;
        _logger = logger;
    }

    public override string ProcessCustomerPayment(decimal payment, string vendorName) {
        _logger.LogInfo($"Cattle Farmer: {vendorName} is processing" + $"a ${payment} payment for grass-fed short ribs");
        return _paymentProcessor.HandlePayment(payment);  
    } 
}