/* Developer: Reshma Venkatachalapathy
 * Date:12-06-2024
 * Project Details: Project for creating a game called "Gem Hunters". A 6*6 matrix board 
 *                  with two players where they get to collect the gems. Player with most 
 *                  gems will win the game.
 * Code Description: This is the main task which will call the consequent methods.
 */

using System;

namespace GemHuntersGame
{
    class MainClass
    {
        static void Main(string[] args)
        {
            GameConditions gemHunters = new GameConditions();
            Console.WriteLine("Printed");
            gemHunters.Start();
        }
    }
}