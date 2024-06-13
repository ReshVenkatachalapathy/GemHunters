using System;


namespace GemHuntersGame

{
    public class DesignBoard
    {
        private Cell[,] Grid { get; }
        private PlayerMovements Player1 { get; }
        private PlayerMovements Player2 { get; }

        public DesignBoard()
        {
            Grid = new Cell[6, 6];
            InitializeBoard();
        }

        public void InitializeBoard()
        {
            // Initialize cells
            for (int i = 0; i < 6; i++)
            {
                for (int j = 0; j < 6; j++)
                {
                    Grid[i, j] = new Cell("-");
                }
            }

            // Place players
            Grid[0, 0].Occupant = "P1";
            Grid[5, 5].Occupant = "P2";

            // Place gems and obstacles (for simplicity, randomly placed)
            Random random = new Random();
            for (int i = 0; i < 4; i++)
            {
                int gemX = random.Next(6);
                int gemY = random.Next(6);
                while (Grid[gemX, gemY].Occupant != "-")
                {
                    gemX = random.Next(6);
                    gemY = random.Next(6);
                }
                Grid[gemX, gemY].Occupant = "G";

                int obstacleX = random.Next(6);
                int obstacleY = random.Next(6);
                while (Grid[obstacleX, obstacleY].Occupant != "-")
                {
                    obstacleX = random.Next(6);
                    obstacleY = random.Next(6);
                }
                Grid[obstacleX, obstacleY].Occupant = "O";
            }
        }

        public void Display()
        {
            for (int i = 0; i < 6; i++)
            {
                for (int j = 0; j < 6; j++)
                {
                    Console.Write(Grid[i, j].Occupant + " ");
                }
                Console.WriteLine();
            }
        }

        public bool IsValidMove(PlayerMovements player, char direction)
        {
            int newX = player.Position.X;
            int newY = player.Position.Y;

            switch (direction)
            {
                case 'U':
                    newY--;
                    break;
                case 'D':
                    newY++;
                    break;
                case 'L':
                    newX--;
                    break;
                case 'R':
                    newX++;
                    break;
                default:
                    return false;
            }

            if (newX < 0 || newX >= 6 || newY < 0 || newY >= 6)
            {
                return false; // Out of bounds
            }

            if (Grid[newX, newY].Occupant == "O")
            {
                return false; // Obstacle
            }

            return true;
        }

        public void CollectGem(PlayerMovements player)
        {
            if (Grid[player.Position.X, player.Position.Y].Occupant == "G")
            {
                player.GemCount++;
                Grid[player.Position.X, player.Position.Y].Occupant = "-";
            }
        }


    }

}