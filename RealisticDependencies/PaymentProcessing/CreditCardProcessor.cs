namespace RealisticDependencies.PaymentProcessing;

public class CreditCardPrcoessor : IProcessesPayments {
    public string HandlePayment(decimal paymentAmount) {
        Thread.Sleep(5000);
        return $"Handling Credit Card Payment for amount: {paymentAmount}";
    }
}