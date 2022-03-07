using RealisticDependencies.PaymentProcessing;

namespace StructualPatterns.Bridge;

public abstract class FarmersMarketVendor {
    private readonly IProcessesPayments _paymentProcessor;

    protected FarmersMarketVendor(IProcessesPayments paymentProcessor) {
        _paymentProcessor = paymentProcessor;
    }

    public virtual string ProcessCustomerPayment(decimal payment, string vendorName) { 
        throw new NotImplementedException("Please override this method in a concrete implementation");
    }
}