using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GemHuntersGame
{
    public class Class1
    {
    }
    class Position
    {
        public int X { get; }
        public int Y { get; }

        public Position(int x, int y)
        {
            X = x;
            Y = y;
        }
    }


    class Cell
    {
        public string Occupant { get; set; }

        public Cell(string occupant)
        {
            Occupant = occupant;
        }
    }

 
}