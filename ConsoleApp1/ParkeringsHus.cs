using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ParkeringsHuset
{
    public class ParkeringsHus
    {
        public static IVehicle GenerateRandomVehicle(List<IVehicle> vehicles)
        {
            Random rnd = new Random();

            int randomNumber = rnd.Next(1, 4);

            switch (randomNumber)
            {
                case 1:
                    Car car = new Car();
                    vehicles.Add(car);
                    return car;
                case 2:
                    Motorbike motorbike = new Motorbike();
                    vehicles.Add(motorbike);
                    return motorbike;
                case 3:
                    Bus bus = new Bus();
                    vehicles.Add(bus);
                    return bus;
                default:
                    return null;
            }
        }

        public static void ParkCar(IVehicle[] ParkingGarage, Car car)
        {
            for (int i = 0; i < ParkingGarage.Length - 1; i++)
            {
                if (ParkingGarage[i] == null && ParkingGarage[i + 1] == null)
                {
                    ParkingGarage[i] = car;
                    ParkingGarage[i + 1] = car;
                    Console.WriteLine("Bilen parkerad.");
                    return;
                }
            }
            Console.WriteLine("Ingen plats för bilen.");
        }

        public static void ParkMotorbike(IVehicle[] ParkingGarage, Motorbike motorbike)
        {
            for (int i = 0; i < ParkingGarage.Length; i++)
            {
                if (ParkingGarage[i] == null)
                {
                    ParkingGarage[i] = motorbike;
                    Console.WriteLine("Motorcykel parkerad.");
                    return;
                }
            }
            Console.WriteLine("Ingen plats för motorcykel.");
        }

        public static void ParkBus(IVehicle[] ParkingGarage, Bus bus)
        {
            for (int i = 0; i < ParkingGarage.Length - 3; i++)
            {
                if (ParkingGarage[i] == null && ParkingGarage[i + 1] == null && ParkingGarage[i + 2] == null && ParkingGarage[i + 3] == null)
                {
                    ParkingGarage[i] = bus;
                    ParkingGarage[i + 1] = bus;
                    ParkingGarage[i + 2] = bus;
                    ParkingGarage[i + 3] = bus;
                    Console.WriteLine("Buss parkerad.");
                    return;
                }
            }
            Console.WriteLine("Ingen plats för buss.");
        }

        public static void CheckOutVehicle(IVehicle[] ParkingGarage)
        {
            string answer = "";
              
            do
            {
                Console.Write("Ange registreringsnummer för att checka ut: ");
                string regNumberToRemove = Console.ReadLine();
                for (int i = 0; i < ParkingGarage.Length; i++)
                {
                    if (ParkingGarage[i]?.regNumber == regNumberToRemove)
                    {
                        IVehicle vehicle = ParkingGarage[i];

                        for (int j = i; j < ParkingGarage.Length; j++) //leta efter alla cells där fordonet finns
                        {
                            if (ParkingGarage[j] == vehicle)
                            {
                                ParkingGarage[j] = null;
                            }
                        }
                        Console.WriteLine();
                        Console.WriteLine("=======================================");
                        Console.WriteLine($"Fordon {regNumberToRemove} har checkats ut.");
                        Console.WriteLine("=======================================");
                        return;
                    }
                }
                Console.WriteLine("Fordonet hittades inte.");
                Console.Write("Vill du söka efter ett annat registreringsnummer? (ja/nej) : ");
                answer = Console.ReadLine();
            }
            while (answer == "ja".ToLower());
        }

        public static void PrintOutParkingGarage(List<IVehicle> vehicles, IVehicle[] ParkingGarage)
        {
            for (int i = 0; i < vehicles.Count; i++)
            {
                var vehicle = vehicles[i];
                string typeName = vehicle.GetType().Name;
                string details = vehicle switch
                {
                    Car car => $" Plats {i + 1}: {car.regNumber},  {car.color}, Elbil: {(car.electric ? "Ja" : "Nej")}",
                    Motorbike motorbike => $"Plats {i + 1}: {motorbike.regNumber},  {motorbike.color},  {motorbike.make}",
                    Bus bus => $"Plats {i + 1}: {bus.regNumber},  {bus.color},  {bus.passengers}",
                    _ => "Okänt fordon"
                };

                //RESUME HERE    Skriv ut alla fordon från (förmodligen) ParkingGarage-arrayen, Kanske använda annan datatyp än List för hanteringen av fordon
                Console.WriteLine($"{typeName}, {details}");
                
            }           
        }
    }
}
