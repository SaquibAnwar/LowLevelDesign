namespace LowLevelDesign.Easy.ParkingLot;

public abstract class Vehicle
{
    public string Id { get; init; }
    public VehicleType Type { get; init; }

    public Vehicle(string id, VehicleType type)
    {
        Id = id;
        Type = type;
    }

    public VehicleType GetVehicleType() => Type;
}