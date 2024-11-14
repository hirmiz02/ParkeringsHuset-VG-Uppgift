using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ParkeringsHuset
{
    
    public class ParkeringsHus
    {
        private const double PricePerMinute = 1.5;
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

        public static void ParkCar(List<IVehicle>[] ParkingGarage, Car car)
        {
            for (int i = 0; i < ParkingGarage.Length; i++)
            {
                if (ParkingGarage[i].Count == 0)
                {
                    ParkingGarage[i].Add(car);
                    Console.WriteLine("Bilen parkerad på plats " + (i + 1));
                    return;
                }
            }
            Console.WriteLine("Ingen plats för bilen.");
        }


        public static void ParkMotorbike(List<IVehicle>[] ParkingGarage, Motorbike motorbike)
        {
            for (int i = 0; i < ParkingGarage.Length; i++)
            {
                int motorbikeCount = ParkingGarage[i].Where(v => v is Motorbike).Count();
                if (ParkingGarage[i].Count == 0 || motorbikeCount > 0 && ParkingGarage[i].Count < 2)   // Max 2 motorcyklar per plats
                {
                    ParkingGarage[i].Add(motorbike);
                    Console.WriteLine("Motorcykel parkerad på plats " + (i + 1));
                    return;
                }
            }
            Console.WriteLine("Ingen plats för motorcykel.");
        }


        public static void ParkBus(List<IVehicle>[] ParkingGarage, Bus bus)
        {
            for (int i = 0; i < ParkingGarage.Length - 1; i++)
            {
                if (ParkingGarage[i].Count == 0 && ParkingGarage[i + 1].Count == 0)
                {
                    ParkingGarage[i].Add(bus);
                    ParkingGarage[i + 1].Add(bus);
                    Console.WriteLine("Bussen parkerad på plats " + (i + 1) + " och " + (i + 2));
                    return;
                }
            }
            Console.WriteLine("Ingen plats för bussen.");
        }


        public static void CheckOutVehicle(List<IVehicle>[] ParkingGarage)
        {
            Console.Write("Ange registreringsnummer för att checka ut: ");
            string regNumberToRemove = Console.ReadLine();

            bool found = false;

            for (int i = 0; i < ParkingGarage.Length; i++)
            {
                // Kontrollera alla platser för det specifika indexet i parkeringsgaraget
                for (int j = 0; j < ParkingGarage[i].Count; j++)
                {
                    if (ParkingGarage[i][j].regNumber == regNumberToRemove)
                    {
                        // Om det är en buss, ta bort alla platser som fordonet är på
                        if (ParkingGarage[i][j] is Bus)
                        {
                            // Ta bort båda platserna om det är en buss   
                            ParkingGarage[i].RemoveAt(j);
                            ParkingGarage[i+1].RemoveAt(j);

                        }
                        else
                        {
                            ParkingGarage[i].RemoveAt(j);
                        }

                        found = true;
                        double parkingDuration = (DateTime.Now - ParkingGarage[i][j].ParkingTime).TotalMinutes;
                        double cost = Math.Round(parkingDuration * PricePerMinute, 2);
                        Console.WriteLine($"Fordon {regNumberToRemove} har checkats ut, Parkeringskostnad : {cost}");
                        break;
                    }
                }
                if (found) break;
            }

            if (!found)
            {
                Console.WriteLine("Fordonet hittades inte.");
            }
        }



        public static void PrintOutParkingGarage(List<IVehicle>[] ParkingGarage)
        {
            Console.WriteLine("Parkeringsstatus:");
            for (int i = 0; i < ParkingGarage.Length; i++)
            {
                if (ParkingGarage[i].Count > 0)
                {
                    foreach (var vehicle in ParkingGarage[i])
                    {
                        string details = vehicle switch
                        {
                            Car car => $"Plats {i + 1}: {car.GetType().Name}, RegNr: {car.regNumber}, Färg: {car.color}, Elbil: {(car.electric ? "Ja" : "Nej")}",
                            Motorbike motorbike => $"Plats {i + 1}: {motorbike.GetType().Name}, RegNr: {motorbike.regNumber}, Färg: {motorbike.color}, Märke: {motorbike.make}",
                            Bus bus => $"Plats {i + 1}: {bus.GetType().Name}, RegNr: {bus.regNumber}, Färg: {bus.color}, Passagerare: {bus.passengers}",
                            _ => $"Plats {i + 1}: Okänt fordon"
                        };

                        Console.WriteLine(details);
                    }
                }
                else
                {
                    Console.WriteLine($"Plats {i + 1}: [Tom plats]");
                }
            }
        }



        public static void CompactParkingGarage(IVehicle[] ParkingGarage)
        {
            int writeIndex = 0; // Håller koll på nästa lediga plats för att skriva fordon

            for (int readIndex = 0; readIndex < ParkingGarage.Length; readIndex++)
            {
                if (ParkingGarage[readIndex] != null)
                {
                    ParkingGarage[writeIndex] = ParkingGarage[readIndex]; // Flytta fordon till första lediga plats
                    if (writeIndex != readIndex)
                    {
                        ParkingGarage[readIndex] = null; // Töm den gamla platsen
                    }
                    writeIndex++; // Flytta fram till nästa lediga skrivplats
                }
            }
        }

    }
}
