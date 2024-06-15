/* Developer: Reshma Venkatachalapathy
 * Date:12-06-2024
 * Project Details: Project for creating a game called "Gem Hunters". A 6*6 matrix board 
 *                  with two players where they get to collect the gems. Player with most 
 *                  gems will win the game.
 * Code Description: This task will declare and initiate the classes and menthods 
 *                   for the project
 *                   
 */

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

    // Declaring for the position
    public class Position
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