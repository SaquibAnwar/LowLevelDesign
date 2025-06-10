namespace LowLevelDesign.Easy.ParkingLot;

public class ParkingSpot
{
    private Vehicle parkedVehicle;
    private int spotNumber { get; init; }
    private VehicleType vehicleType { get; set; }
    public bool IsAvailable => parkedVehicle == null;

    public ParkingSpot(int spotNumber, VehicleType type)
    {
        this.spotNumber = spotNumber;
        vehicleType = type;
    }

    public bool Park(Vehicle vehicle)
    {
        if (!IsAvailable && vehicle.GetVehicleType() != vehicleType)
        {
            throw new ArgumentException("Invalid vehicle type or spot already occupied.");
        }
        
        this.parkedVehicle = vehicle;
        return true;
    }

    public Vehicle Unpark()
    {
        Vehicle vehicle = this.parkedVehicle;
        this.parkedVehicle = null;
        return vehicle;
    }

    public VehicleType GetVehicleType() => vehicleType;

    public Vehicle GetParkedVehicle() => parkedVehicle;

    public int GetSpotNumber() => spotNumber;
}