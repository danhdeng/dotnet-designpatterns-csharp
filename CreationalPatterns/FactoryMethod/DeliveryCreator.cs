using CreationalPatterns.FactoryMethod.VehicleTypes;
using Newtonsoft.Json;
using RealisticDependencies.Logger;
using RealisticDependencies.Models;
using RealisticDependencies.Provider;

namespace CreationalPatterns.FactoryMethod;

//Creator class. this class declares the factory method `RegisterVehicle`
//that returns an IDeliversFood object

public abstract class DeliveryCreateor {
    private readonly IAmqpQueue _deliveryQueue;
    protected readonly IApplicationLogger _logger;

    public DeliveryCreateor() { }

    public DeliveryCreateor(IAmqpQueue deliverQueue, IApplicationLogger logger) {
        _deliveryQueue = deliverQueue;
        _logger = logger;
    }

    //factoy method 

    protected abstract IDeliversFood RegisterVehicle();

    public void QueueVehicleForDelivery() { 
        var vehicle=RegisterVehicle();
        var vehiclePayload = JsonConvert.SerializeObject(vehicle);
        var queueMessage = new QueueMessage(vehiclePayload);
        _deliveryQueue.Add(queueMessage);
        _logger.LogInfo($"Queued up vehicle of type {vehicle.GetType()} for food delivery.");
    }
}