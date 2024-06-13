using System;

namespace GemHuntersGame
{
    public class Game
    {
        private DesignBoard Board { get; }
        private PlayerMovements Player1 { get; }
        private PlayerMovements Player2 { get; }
        private PlayerMovements CurrentTurn { get; set; }
        private int TotalTurns { get; set; }

        public Game()
        {
            Board = new DesignBoard();
            Player1 = new PlayerMovements("P1", new Position(0, 0));
            Player2 = new PlayerMovements("P2", new Position(5, 5));
            CurrentTurn = Player1;
            TotalTurns = 0;
        }

        public void Start()
        {
            while (!IsGameOver())
            {
                Board.Display();
                Console.WriteLine($"Current turn: {CurrentTurn.Name}");
                Console.WriteLine("Enter move (U/D/L/R):");
                char move = Console.ReadKey().KeyChar;
                Console.WriteLine();
                if (Board.IsValidMove(CurrentTurn, move))
                {
                    CurrentTurn.Move(move);
                    Board.CollectGem(CurrentTurn);
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

        private void SwitchTurn()
        {
            CurrentTurn = (CurrentTurn == Player1) ? Player2 : Player1;
        }

        private bool IsGameOver()
        {
            return TotalTurns >= 30;
        }

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