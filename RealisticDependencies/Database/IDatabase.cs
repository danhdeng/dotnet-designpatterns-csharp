namespace RealisticDependencies.Database;

public interface IDatabase {
    Task Connect();
    Task Disconnect();

    Task<string> ReadData(string id);

    Task WriteData(string id, string data);

    Task<List<string>> GetAllData();
}