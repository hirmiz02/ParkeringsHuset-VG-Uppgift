using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ParkeringsHuset
{
    
    public class Car : Vehicle
    {
        public bool electric;
        public Car() 
        {
            SetRegNumber(); 
            SetColor();
            SetTime();

            Random rnd = new Random();
            electric = rnd.Next(0, 2) == 1;
        }
    }
}
