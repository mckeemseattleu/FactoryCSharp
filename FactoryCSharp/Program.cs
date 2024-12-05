using System;
// Enum defining vehicle types
public enum VehicleType
{
    TwoWheeler,
    ThreeWheeler,
    FourWheeler
}

// Abstract class for Vehicle
public abstract class Vehicle
{
    public abstract void PrintVehicleInfo();
}

// Concrete classes for each type of vehicle
public class TwoWheeler : Vehicle
{
    public override void PrintVehicleInfo()
    {
        Console.WriteLine("I am two wheeler");
    }
}

public class ThreeWheeler : Vehicle
{
    public override void PrintVehicleInfo()
    {
        Console.WriteLine("I am three wheeler");
    }
}

public class FourWheeler : Vehicle
{
    public override void PrintVehicleInfo()
    {
        Console.WriteLine("I am four wheeler");
    }
}

// Interface for the VehicleFactory
public interface IVehicleFactory
{
    Vehicle Build(VehicleType vehicleType);
}

// Concrete class implementing the VehicleFactory
public class VehicleFactory : IVehicleFactory
{
    public Vehicle Build(VehicleType vehicleType)
    {
        switch (vehicleType)
        {
            case VehicleType.TwoWheeler:
                return new TwoWheeler();
            case VehicleType.ThreeWheeler:
                return new ThreeWheeler();
            case VehicleType.FourWheeler:
                return new FourWheeler();
            default:
                return null;
        }
    }
}

// Client class
public class Client
{
    private Vehicle _pVehicle;

    public Client()
    {
        _pVehicle = null;
    }

    public void BuildVehicle(VehicleType vehicleType)
    {
        IVehicleFactory vf = new VehicleFactory();
        _pVehicle = vf.Build(vehicleType);
    }

    public Vehicle GetVehicle()
    {
        return _pVehicle;
    }
}

// Driver Program
class Program
{
    static void Main(string[] args)
    {
        Client client = new Client();

        client.BuildVehicle(VehicleType.TwoWheeler);
        client.GetVehicle().PrintVehicleInfo();

        client.BuildVehicle(VehicleType.ThreeWheeler);
        client.GetVehicle().PrintVehicleInfo();

        client.BuildVehicle(VehicleType.FourWheeler);
        client.GetVehicle().PrintVehicleInfo();
    }
}