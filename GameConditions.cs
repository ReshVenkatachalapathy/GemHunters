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