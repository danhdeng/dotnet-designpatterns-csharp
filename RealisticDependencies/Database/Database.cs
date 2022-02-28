using RealisticDependencies.Logger;

namespace RealisticDependencies.Database;

public class Database : IDatabase
{
    private readonly string _connectionString;
    private readonly IApplicationLogger _logger;
    private bool _isConnected;

    private readonly Dictionary<string, string> _data = new();
    public Database(string connectionString, IApplicationLogger logger)
    {
        _connectionString = connectionString;
        _logger = logger;
    }

    public async Task Connect()
    {
        await Task.Delay(1000);
        _isConnected = true;
        _logger.LogInfo($"{DateTime.UtcNow} - Connected to Database.", ConsoleColor.Magenta);
    }

    public async Task Connect(string client)
    {
        await Task.Delay(3000);
        _isConnected = true;
        _logger.LogInfo($"{DateTime.UtcNow} - {client} Connected to Database.", ConsoleColor.Magenta);
    }

    public async Task Disconnect()
    {
        await Task.Delay(3000);
        _isConnected = false;
        _logger.LogInfo($"{DateTime.UtcNow} - Disconnected to Database.", ConsoleColor.Magenta);
    }

    public async Task<string> ReadData(string id)
    {
        if (!_isConnected)
        {
            throw new NotSupportedException("Cannot read from database without open the connection");

        }

        if (string.IsNullOrWhiteSpace(id))
        {
            return "";
        }

        await Task.Delay(1500);
        try
        {
            return _data[id];
        }
        catch (KeyNotFoundException)
        {
            return "";
        }
    }

    public async Task WriteData(string key, string data)
    {
        if (!_isConnected)
        {
            throw new NotSupportedException("Cannot read from database without open the connection");
        }

        if (string.IsNullOrWhiteSpace(key) || string.IsNullOrWhiteSpace(data))
        {
            return;
        }

        await Task.Delay(1500);
        _data[key] = data;
    }

    public async Task<List<string>> GetAllData()
    {
        if (!_isConnected)
        {
            throw new NotSupportedException("Cannot read from database without open the connection");

        }
        await Task.Delay(2000);

        try
        {
            return _data.Values.Select(x => x).ToList();
        }
        catch (KeyNotFoundException) {
            return new();
        }
    }
}