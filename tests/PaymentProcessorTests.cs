using FluentAssertions;
using Xunit;
using RealisticDependencies.PaymentProcessing;

namespace Tests;

public class PaymentProcessingTests {
    [Theory]
    [InlineData(1d)]
    [InlineData(-23d)]
    [InlineData(3498d)]
    public void GiftCardProcess_HandlePayment_Returns_Amount_In_Some_String(decimal amount) {
        var gcProcessor = new GiftCardPrcoessor();
        var response = gcProcessor.HandlePayment(amount);
        response.Should().Contain(amount.ToString());
        response.ToLower().Should().Contain("gift card");
    }

    public void CreditCardProcess_HandlePayment_Returns_Amount_In_Some_String(decimal amount)
    {
        var ccProcessor = new GiftCardPrcoessor();
        var response = ccProcessor.HandlePayment(amount);
        response.Should().Contain(amount.ToString());
        response.ToLower().Should().Contain("credit card");
    }


}