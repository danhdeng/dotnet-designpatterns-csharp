using RealisticDependencies;
using FluentAssertions;
using Moq;
using Xunit;
using System.Threading.Tasks;
using System.Xml.Serialization;
using RealisticDependencies.Models;
using RealisticDependencies.Logger;
using RealisticDependencies.API;
using System.IO;
using System;

namespace Tests;

public class RecipeApiTests {
    private readonly XmlSerializer xml = new XmlSerializer(typeof(Recipe));

    [Fact]
    public async Task MakeHttpRequestForRecipe_Gets_Value_From_Database_Give_Recipe() {

        var logger = new Mock<IApplicationLogger>();
        var api = new RecipesApi(logger.Object);
        var result = await api.MakeHttpRequestForRecipe("mashed_potatoes");
        using var reader = new StringReader(result);
        var recipe = (Recipe)xml.Deserialize(reader);
        recipe.Should().NotBeNull();
        recipe.Name.Should().Be("Mashed Potatoes");
    }
    [Fact]
    public async Task MakeHttpRequestForRecipe_Logs_Recipe() {
        var mockLogger = new Mock<IApplicationLogger>();
        var api = new RecipesApi(mockLogger.Object);
        var result = await api.MakeHttpRequestForRecipe("mashed_potatoes");
        mockLogger.Verify(mock
            =>mock.LogInfo(
                It.IsAny<string>(),
                It.IsAny<ConsoleColor>()),
                Times.AtLeastOnce());
    }

}