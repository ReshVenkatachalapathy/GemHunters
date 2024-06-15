/* Developer: Reshma Venkatachalapathy
 * Date:12-06-2024
 * Project Details: Project for creating a game called "Gem Hunters". A 6*6 matrix board 
 *                  with two players where they get to collect the gems. Player with most 
 *                  gems will win the game.
 * Code Description: This task will verify the below conditions of the game,
 *                   -> Start the game,
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
    public class GameConditions
    {
        private DesignBoard Board { get; }
        private PlayerMovements Player1 { get; }
        private PlayerMovements Player2 { get; }
        private PlayerMovements CurrentTurn { get; set; }
        private int TotalTurns { get; set; }

        public GameConditions()
        {
            Board = new DesignBoard();
            Player1 = new PlayerMovements("P1", new Position(0, 0));
            Player2 = new PlayerMovements("P2", new Position(5, 5));
            CurrentTurn = Player1;
            TotalTurns = 0;
        }

        // Method will start the game by desplaying the player turns and moves
        public void Start()
        {
            while (!IsGameOver())
            {
                Board.Display();
                Console.WriteLine($"Current turn: {CurrentTurn.Name}");
                Console.WriteLine("Enter move (U/D/L/R):");
                char move = System.Console.ReadKey().KeyChar;
                Console.WriteLine();
                if (Board.IsValidMove(CurrentTurn, move))
                {
                    int beforeXIndex, beforetYIndex;
                    beforeXIndex = CurrentTurn.Position.X;
                    beforetYIndex = CurrentTurn.Position.Y;
                    CurrentTurn.Move(move);
                    char c = Board.CollectGem(CurrentTurn);
                    if(c=='G'){
                        c = '-';
                    }                
                    Board.updateBoard(beforeXIndex,beforetYIndex,CurrentTurn.Position.X,CurrentTurn.Position.Y,CurrentTurn.previousValue,CurrentTurn.Name);
                    CurrentTurn.previousValue=c;
                    SwitchTurn();
                    TotalTurns++;
                }
                else
                {
                    Console.WriteLine("Invalid move!");
                }
            }
            AnnounceWinner();
        }

        // Switch the player turns
        private void SwitchTurn()
        {
            CurrentTurn = (CurrentTurn == Player1) ? Player2 : Player1;
        }

        private bool IsGameOver()
        {
            return TotalTurns >= 30;
        }


        // Method will display the winner details
        private void AnnounceWinner()
        {
            Console.WriteLine("Game over!");
            Console.WriteLine($"Player 1 collected {Player1.GemCount} gems");
            Console.WriteLine($"Player 2 collected {Player2.GemCount} gems");
            if (Player1.GemCount > Player2.GemCount)
                Console.WriteLine("Player 1 wins!");
            else if (Player1.GemCount < Player2.GemCount)
                Console.WriteLine("Player 2 wins!");
            else
                Console.WriteLine("It's a tie!");
        }
    }

}