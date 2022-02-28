using FluentAssertions;
using RealisticDependencies;
using RealisticDependencies.Logger;
using RealisticDependencies.Provider;
using Xunit;
using Moq;
using RealisticDependencies.Models;
using System;

namespace Tests;

public class QueueTests {
    [Fact]
    public void Add_Invokes_Log_Message() {
        //Arrange
        var mockLogger = new Mock<IApplicationLogger>();
        var queue = new CloudQueue(mockLogger.Object);
        var payload = new QueueMessage("hello");

        //Act
        queue.Add(payload);

        //Assert
        mockLogger.Verify(mock
            => mock.LogInfo(
                It.Is<string>(s => s.Contains(payload.Content)),
                It.IsAny<ConsoleColor>()),
                Times.Once());
    }
}