using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ParkeringsHuset
{
    public class Bus : Vehicle
    {
        public int passengers;
        public Bus()
        {
            SetRegNumber();
            SetColor();
            SetTime();

            Random rnd = new Random();
            passengers = rnd.Next(40, 70);
        }
    }
}
