/* Developer: Reshma Venkatachalapathy
 * Date:12-06-2024
 * Project Details: Project for creating a game called "Gem Hunters". A 6*6 matrix board 
 *                  with two players where they get to collect the gems. Player with most 
 *                  gems will win the game.
 * Code Description: This task will verify the below conditions of the game,
 *                   -> Verify the player's movement is only left,right,up and down.If any
 *                   other move is instructed then display invalid
 *       
 *                
 *                   
 */


using System;

namespace GemHuntersGame
{
    public class PlayerMovements
    {
        public string Name { get; }
        public Position Position { get; set; }
        public int GemCount { get; set; }

        public char previousValue { get; set; }

        public PlayerMovements(string name, Position position)
        {
            Name = name;
            Position = position;
            GemCount = 0;
            previousValue = '-';
        }

        // Method will move player based on user's direction
        public void Move(char direction)
        {
            switch (direction)
            {
                case 'L':
                    Position = new Position(Position.X, Position.Y - 1);
                    break;
                case 'R':
                    Position = new Position(Position.X, Position.Y + 1);
                    break;
                case 'U':
                    Position = new Position(Position.X - 1, Position.Y);
                    break;
                case 'D':
                    Position = new Position(Position.X + 1, Position.Y);
                    break;
                default:
                    Console.WriteLine("Invalid move. Players can move only left, right, up and down.");
                    break;
            }
        }
    }
}

