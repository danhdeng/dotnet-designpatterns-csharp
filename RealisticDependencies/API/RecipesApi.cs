using RealisticDependencies.Logger;
using RealisticDependencies.Models;
using System.Xml;
using System.Xml.Serialization;

namespace RealisticDependencies.API;

public class RecipesApi : IRecipesApi {
    private readonly Dictionary<string, Recipe> _database;
    private readonly object _logger;

    public RecipesApi(IApplicationLogger logger) {
        _database = GenerateDatabase();
        _logger = logger;

    }

    public async Task<string> MakeHttpRequestForRecipe(string recipe)
    {
        _logger.logInfo($"Making HTTP request returning XML for: {recipe}", ConsoleColor.Magenta);

        await Task.Delay(2000);

        var databaseResponse = _database[recipe];
        var xmlSerializer = new XmlSerializer(databaseResponse.GetType());
        await using var stringWriter = new StringWriter();
        await using var writer = XmlWriter.Create(stringWriter, new XmlWriterSettings { Async = true });
        xmlSerializer.Serialize(writer, databaseResponse);
        return stringWriter.ToString();
    }

    private static Dictionary<string, Recipe> GenerateDatabase()
    {
        return new()
        {
            { "mashed_potatoes", new Recipe("mashed_potatoes", 30) },
            { "green_beans", new Recipe("green_beans", 10) },
            { "red_curry", new Recipe("red_curry", 60) },

        };
    }
}