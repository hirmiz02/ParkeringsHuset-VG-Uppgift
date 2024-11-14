using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ParkeringsHuset
{
    public interface IVehicle
    {
         string regNumber {  get; set; }
         string color { get; set; }
         public DateTime ParkingTime { get; set; }

        void SetRegNumber();
        void SetColor();
        void SetTime();

    }
    public abstract class Vehicle : IVehicle  //Säkerställ att alla subklasser följer interfacets kontrakt
    {
        public string regNumber { get; set; }
        public string color { get; set; }
        public DateTime ParkingTime { get; set; }   

        public void SetTime()
        {
            ParkingTime = DateTime.Now;
        }
        public void SetRegNumber()
        {
            Random rnd = new Random();
            string letters = "";

            for (int i = 0; i < 3; i++)
            {
                letters += (char)rnd.Next('A', 'Z' + 1);
            }

            string numbers = rnd.Next(100, 1000).ToString();
            regNumber = letters + numbers;
        }

        public void SetColor()
        {
            Console.WriteLine();
            Console.WriteLine($"Typ av fordon: {this.GetType().Name}");
            Console.Write("Välj en färg för fordonet (t.ex. Röd, Blå, Svart): ");
            string chosenColor = Console.ReadLine();  
            color = chosenColor;
        }
    }

}
