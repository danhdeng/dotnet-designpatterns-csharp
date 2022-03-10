﻿using BehavioralPatterns.Mediator.Models;
using RealisticDependencies.Database;
using RealisticDependencies.Logger;

namespace BehavioralPatterns.Mediator.Vehicles;

public class PopUpShop : FleetMember
{
    private readonly IDatabase _database;

    public PopUpShop(
        string handle,
        int lat,
        int lon,
        IApplicationLogger logger,
        IDatabase database) : base(logger, handle, lat, lon)
    {
        _database = database;
        _database.Connect().Wait();
    }

    public override async Task Receive(NetworkMessage message)
    {
        await Task.Delay(500);
        var payload = message.Read();
        var sendTime = message.GetTimeStamp();
        Logger.LogInfo($"[{Handle}] <--- Received Message {payload} at ({sendTime})", ConsoleColor.DarkCyan);
        if (payload.Contains("thanks pop-up"))
        {
            var returnMessage = new NetworkMessage("All Good! 🌿");
            returnMessage.Sign(this);
            await Mediator.Broadcast(returnMessage);
        }
        if (payload.Contains("where are you"))
        {
            await SignalLocation();
        }
    }

    public override async Task Send(ICommunicates receiver, NetworkMessage message)
    {
        await Task.Delay(500);
        message.Sign(this);
        await Mediator.DeliverPayload(receiver.Handle, message);
    }

    public override void SendMediator(IMediator mediator)
    {
        Logger.LogInfo($"[{Handle}] Registration with Fleet", ConsoleColor.DarkCyan);
        Mediator = mediator;
    }
}