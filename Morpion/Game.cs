using System;
using System.Threading.Tasks;
public class Game
{
    private Board board;
    private IPlayer playerX;
    private IPlayer playerO;
    private IPlayer currentPlayer;

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

    public async Task Play()
    {
        while (true)
        {
            board.Display();
            Console.WriteLine($"Player {currentPlayer.Symbol}'s turn");

            int[] move = await currentPlayer.GetNextMove();
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

    //Tests
    public Game(Board board, IPlayer playerX, IPlayer playerO)
    {
        this.board = board;
        this.playerX = playerX;
        this.playerO = playerO;
        this.currentPlayer = playerX;
    }
    public IPlayer CurrentPlayer => currentPlayer;
    public Board Board => board;
    public void SwitchPlayerForTest()
    {
        currentPlayer = (currentPlayer == playerX) ? playerO : playerX;
    }

}

