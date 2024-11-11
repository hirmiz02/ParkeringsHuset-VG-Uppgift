using ParkeringsHuset;

namespace ConsoleApp1
{
    internal class Program
    {
        static void Main(string[] args)
        {
            List<IVehicle> vehicles = new List<IVehicle>();
            IVehicle[] ParkingGarage = new IVehicle[30];
            

            while (true)
            {
                Console.Clear();
                ParkeringsHus.PrintOutParkingGarage(vehicles, ParkingGarage);

                var vehicle = ParkeringsHus.GenerateRandomVehicle(vehicles);

                Console.WriteLine($"Fordon registrerades: {vehicle.GetType().Name}");
                Console.WriteLine($"RegNr: {vehicle.regNumber}, Färg: {vehicle.color}");

                if (vehicle is Car)
                {
                    ParkeringsHus.ParkCar(ParkingGarage, vehicle as Car);
                }
                else if (vehicle is Motorbike)
                {
                    ParkeringsHus.ParkMotorbike(ParkingGarage, vehicle as Motorbike);
                }
                else if (vehicle is Bus)
                {
                    ParkeringsHus.ParkBus(ParkingGarage, vehicle as Bus);
                }

                Console.Write("Vill du checka ut ett fordon? (ja/nej) : ");
                string checkOutChoice = Console.ReadLine();
                if (checkOutChoice.ToLower() == "ja")
                {                   
                    ParkeringsHus.CheckOutVehicle(ParkingGarage);
                }

                

                Console.WriteLine("Tryck på en tangent för att fortsätta.");
                Console.ReadKey(true);
            }
        }
    }
}

