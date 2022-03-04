using CreationalPatterns.FactoryMethod.VehicleTypes;
using RealisticDependencies.Logger;
using RealisticDependencies.Provider;

namespace CreationalPatterns.FactoryMethod;

public class CarDeliveryCreator : DeliveryCreateor
{
    public CarDeliveryCreator(IAmqpQueue deliveryQueue, IApplicationLogger logger) : base(deliveryQueue, logger) { }

    protected override IDeliversFood RegisterVehicle()
    {
        var car = new Car()
        {
            Year = 2014,
            Color = "black",
            Make = "Toyota",
            Model = "Corola",
            LicensePlate="123456"
        };
        _logger.LogInfo("Registering a Car to deliver food", ConsoleColor.Green);
        return car;
    }
}