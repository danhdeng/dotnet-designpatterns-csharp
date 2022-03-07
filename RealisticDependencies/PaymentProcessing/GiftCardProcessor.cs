namespace RealisticDependencies.PaymentProcessing;

public class GiftCardPrcoessor : IProcessesPayments
{
    public string HandlePayment(decimal paymentAmount)
    {
        Thread.Sleep(5000);
        return $"Handling Gift Card Payment for amount: {paymentAmount}";
    }
}