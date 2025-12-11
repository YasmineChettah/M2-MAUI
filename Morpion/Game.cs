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

        Console.WriteLine("Choose mode:");
        Console.WriteLine("1 - Human vs Human");
        Console.WriteLine("2 - Human vs AI");
        Console.Write("Your choice: ");

        string choice = Console.ReadLine();

        if (choice == "2")
        {
            playerX = new Player('X');
            playerO = new AIPlayer('O');
            Console.WriteLine("You play against the AI!");
        }
        else
        {
            playerX = new Player('X');
            playerO = new Player('O');
            Console.WriteLine("Human vs Human mode!");
        }

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
            int row = move[0];
            int column = move[1];

            bool success = board.PlayMove(row, column, currentPlayer.Symbol);

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

