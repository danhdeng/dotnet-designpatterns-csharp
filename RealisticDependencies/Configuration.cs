namespace RealisticDependencies;

public static class Configuration {
    public static string ConnectionString => "tcp://dan.test:1999";
    public static int MaxConnections => 3;
    public static int MinPremiumPointsBalance => 3;

}