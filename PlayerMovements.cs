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

