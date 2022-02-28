using FluentAssertions;
using Xunit;
using RealisticDependencies;

namespace Tests;

public class ConfigurationTests {
    [Fact]
    public void Connection_String_Is_Not_Null_Or_Empty() {
        var csString = Configuration.ConnectionString;
        csString.Should().NotBeNullOrEmpty();
    }
    [Fact]
    public void MaxConections_Is_Greater_Than_Zero() {
        var max = Configuration.MaxConnections;
        max.Should().BeGreaterThan(0);
    }
    
}