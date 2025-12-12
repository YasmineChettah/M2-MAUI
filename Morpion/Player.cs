using System;

public class Player : IPlayer
{
    public char Symbol { get; private set; }

    public Player(char symbol)
    {
        Symbol = symbol;
    }

    public async Task<int[]> GetNextMove()
    {
        Console.Write($"Player {Symbol}, enter row (0-2): ");
        int x = int.Parse(Console.ReadLine());

        Console.Write($"Player {Symbol}, enter col (0-2): ");
        int y = int.Parse(Console.ReadLine());

        return new int[] { x, y };
    }
}
