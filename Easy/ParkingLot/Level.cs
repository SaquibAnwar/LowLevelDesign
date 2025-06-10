namespace LowLevelDesign.Easy.ParkingLot;

public class Level
{
    private readonly int floor;
    private readonly List<ParkingSpot> parkingSpots;

    public Level(int floor, int numberOfSpots)
    {
        this.floor = floor;
        parkingSpots = new List<ParkingSpot>(numberOfSpots);

        InitialiseParkingLot(parkingSpots, numberOfSpots);
    }

    public bool ParkVehicle(Vehicle vehicle)
    {
        lock (parkingSpots)
        {
            foreach (var spot in parkingSpots)
            {
                if (spot.IsAvailable && spot.GetVehicleType() == vehicle.GetVehicleType())
                {
                    spot.Park(vehicle);
                    return true;
                }
            }
        }

        return false;
    }

    public bool UnparkVehicle(Vehicle vehicle)
    {
        lock (parkingSpots)
        {
            foreach (var spot in parkingSpots)
            {
                if (!spot.IsAvailable && spot.GetParkedVehicle().Equals(vehicle))
                {
                    spot.Unpark();
                    return true;
                }
            }
        }

        return false;
    }

    public void DisplayAvailability()
    {
        Console.WriteLine($"Level {floor} Availability");
        foreach (var spot in parkingSpots)
        {
            Console.WriteLine($"Spot {spot.GetSpotNumber()}: {(spot.IsAvailable ? "Available For " : "Occupied By ")} {spot.GetVehicleType()}");
        }
    }

    private void InitialiseParkingLot(List<ParkingSpot> parkingSpots, int numberOfSpots)
    {
        double spotsForBikes = .5;
        double spotsForCars = .4;

        int totalBikes = (int)(spotsForBikes * numberOfSpots);
        int totalCars = (int)(spotsForCars * numberOfSpots);

        for (int i = 1; i <= totalBikes; i++)
        {
            parkingSpots.Add(new ParkingSpot(i, VehicleType.MOTOTRCYCLE));
        }
        
        for (int i = totalBikes + 1; i <= totalBikes + totalCars; i++)
        {
            parkingSpots.Add(new ParkingSpot(i, VehicleType.CAR));
        }
        
        for (int i = totalBikes + totalCars + 1; i <= numberOfSpots; i++)
        {
            parkingSpots.Add(new ParkingSpot(i, VehicleType.TRUCK));
        }
    }
}