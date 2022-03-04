

using CreationalPatterns.Singleton;

namespace IngredientsDatabaseClient;

internal class Program {
    private const string EastClientId = "US-East";
    private const string WestClientId = "US-West";
    private const string NorthClientId = "US-Noth";
    private const string SouthClientId = "US-South";

    private static async Task Main(string[] args) {
        Console.OutputEncoding = System.Text.Encoding.UTF8;
        Console.WriteLine("...Connecting to ingredients database....");
        var eastClient = IngredientsDbConnectionPool.Instance;
        var westClient = IngredientsDbConnectionPool.Instance;
        var southClient = IngredientsDbConnectionPool.Instance;
        var northClient = IngredientsDbConnectionPool.Instance;

        //open and close connections against the ConnectinPool

        await eastClient.Connect(EastClientId);
        await westClient.Connect(WestClientId);
        await southClient.Connect(SouthClientId);
        await northClient.Connect(NorthClientId);

        await northClient.Disconnect();
        await southClient.Connect(SouthClientId);

        await eastClient.Disconnect();
        await westClient.Disconnect();
        await southClient.Disconnect();
        await northClient.Disconnect();

        Console.WriteLine("...... Sesesion complete!");
    }
}