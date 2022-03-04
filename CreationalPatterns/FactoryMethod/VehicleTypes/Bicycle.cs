namespace CreationalPatterns.FactoryMethod.VehicleTypes;

public class Bicycle : IDeliversFood { 
    public string Color { get; set; }
    public string Make { get; set; }
    public string Model { get; set; }
    public string Style { get; set; }

    public async Task Deliver(int orderId) {
        await Task.FromResult($"Delivered Order: {orderId} via Bicycle");
    }

}