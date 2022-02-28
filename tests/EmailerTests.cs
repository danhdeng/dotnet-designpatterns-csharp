using Xunit;
using FluentAssertions;
using System.Threading.Tasks;
using RealisticDependencies.Logger;
using RealisticDependencies.Provider;
using Moq;
using RealisticDependencies.Models;
using System;

namespace Tests;

public class EmailerTests {
    [Fact]
    public async Task SendMessage_Logs_Email_Connect() {
        //Arrange
        var mockLogger = new Mock<IApplicationLogger>();
        var emailer = new Emailer(mockLogger.Object);
        var email = new EmailMessage("foo", "bar");

        //Act
        await emailer.SendMessage(email);
        
        //Assert
        mockLogger.Verify(mock =>mock.LogInfo(
            It.Is<string>(s=>s.Contains(email.Content)),
            It.IsAny<ConsoleColor>()),
            Times.Once());
    }
}