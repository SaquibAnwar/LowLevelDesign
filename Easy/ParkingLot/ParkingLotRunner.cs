namespace LowLevelDesign.Easy.ParkingLot;

public class ParkingLotRunner
{
    public static void Run()
    {
        ParkingLot parkingLot = ParkingLot.GetInstance();
        parkingLot.AddLevel(new Level(1, 6));
        // parkingLot.AddLevel(new Level(2, 80));

        var car = new Car("ABCD");
        var bike = new Bike("XYZ");
        var truck = new Truck("123CV");
        
        parkingLot.ParkVehicle(car);
        parkingLot.ParkVehicle(bike);
        parkingLot.ParkVehicle(truck);
        
        parkingLot.DisplayAvailability();

        parkingLot.UnparkVehicle(car);
        
        parkingLot.DisplayAvailability();
    }
}