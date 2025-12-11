using System;

public class Game
{
    private Board board;
    private Player playerX;
    private Player playerO;
    private Player currentPlayer;

    public Game()
    {
        board = new Board();
        playerX = new Player('X');
        playerO = new Player('O');
        currentPlayer = playerX;
    }

    private void SwitchPlayer()
    {
        currentPlayer = (currentPlayer == playerX) ? playerO : playerX;
    }

    public void Play()
    {
        while (true)
        {
            board.Display();
            Console.WriteLine($"Player {currentPlayer.Symbol}'s turn");

            int[] move = currentPlayer.GetNextMove();
            int x = move[0];
            int y = move[1];

            bool success = board.PlayMove(x, y, currentPlayer.Symbol);

            if (!success)
            {
                Console.WriteLine("Invalid move! Press Enter…");
                Console.ReadLine();
                continue;
            }

            if (board.CheckWin(currentPlayer.Symbol))
            {
                board.Display();
                Console.WriteLine($"Player {currentPlayer.Symbol} wins!");
                break;
            }

            if (board.IsFull())
            {
                board.Display();
                Console.WriteLine("Equal");
                break;
            }

            SwitchPlayer();
        }
    }
}

