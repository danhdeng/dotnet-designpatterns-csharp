namespace CreationalPatterns.FactoryMethod.VehicleTypes;

public class Car : IDeliversFood
{
    public string LicensePlate { get; set; }
    public string Make { get; set; }
    public string Model { get; set; }
    public string Color { get; set; }

    public int Year { get; set; }

    public async Task Deliver(int orderId)
    {
        await Task.FromResult($"Delivered Order: {orderId} via Car");
    }

}