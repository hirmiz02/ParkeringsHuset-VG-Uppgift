using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ParkeringsHuset
{
    public class Motorbike : Vehicle
    {
        public string make;
        public Motorbike()
        {
            SetRegNumber();
            SetColor();
            SetTime();

            Random rnd = new Random();
            string[] makes = { "Honda", "Yamaha", "Kawasaki", "BMW", "Harley", "Ducati", "Norton", "Aprilia" };
            make = makes[rnd.Next(makes.Length)];
        }
    }
}
