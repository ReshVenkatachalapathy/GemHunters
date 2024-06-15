/* Developer: Reshma Venkatachalapathy
 * Date:12-06-2024
 * Project Details: Project for creating a game called "Gem Hunters". A 6*6 matrix board 
 *                  with two players where they get to collect the gems. Player with most 
 *                  gems will win the game.
 * Code Description: This task will verify the below conditions of the game,
 *                   -> Create a 6*6 matrix for the board,
 *                   -> Check the moves of the player is valid, 
 *                   -> Number of turns are within the limit,
 *                   -> Switch the players for their turn,
 *                   -> Announce the winner. If the gems collected are same then announce 
 *                   as tied.
 *                   
 */


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

        public void updateBoard(int i, int j, int x, int y, char a, String b){
            Grid[i,j] = new Cell(""+a);
            Grid[x,y] = new Cell(b);
        }

        //Method will create a 6*6 matrix for the board
        public void InitializeBoard()
        {
            
            for (int i = 0; i < 6; i++)
            {
                for (int j = 0; j < 6; j++)
                {
                    Grid[i, j] = new Cell("-");
                }
            }

            // Assign the players in their positions
            Grid[0, 0].Occupant = "P1";
            Grid[5, 5].Occupant = "P2";

            // Assign the gems and obstacles in the board randomly
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


        // Display the board after making the move by the user
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

        // Verify if the user given direction is valid move.
        public bool IsValidMove(PlayerMovements player, char direction)
        {
            int newX = player.Position.X;
            int newY = player.Position.Y;

            switch (direction)
            {
                case 'L':
                    newY--;
                    break;
                case 'R':
                    newY++;
                    break;
                case 'U':
                    newX--;
                    break;
                case 'D':
                    newX++;
                    break;
                default:
                    return false;
            }

            if (newX < 0 || newX >= 6 || newY < 0 || newY >= 6)
            {
                return false; 
            }

            if (Grid[newX, newY].Occupant == "O" || Grid[newX, newY].Occupant == "P1" || Grid[newX, newY].Occupant == "P2")
            {
                return false; 
            }

            return true;
        }

        //Method will collect the gems if it is 'G' and restrict move if it is 'O'
        public char CollectGem(PlayerMovements player)
        {
            if (Grid[player.Position.X, player.Position.Y].Occupant == "G")
            {
                player.GemCount++;
                Grid[player.Position.X, player.Position.Y].Occupant = "-";
                return 'G';
            }
            else if(Grid[player.Position.X, player.Position.Y].Occupant == "O"){
                return 'O';
            }
            else{
                return '-';
            }
        }


    }

}