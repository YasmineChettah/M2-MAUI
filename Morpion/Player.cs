using System;

public class Player
{
    public char Symbol;

    public Player(char symbol)
    {
        Symbol = symbol;
    }

    public virtual int[] GetNextMove()
    {
        Console.Write("Enter row (0-2): ");
        int x = int.Parse(Console.ReadLine());

        Console.Write("Enter col (0-2): ");
        int y = int.Parse(Console.ReadLine());

        return new int[] { x, y };
    }
}
