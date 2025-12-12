using System;

public class AIPlayer : IPlayer
{
    private Random playCase = new Random();
    public char Symbol { get; private set; }

    public AIPlayer(char symbol)
    {
        Symbol = symbol;
    }

    public int[] GetNextMove()
    {
        int x = playCase.Next(0, 3);
        int y = playCase.Next(0, 3);

        return new int[] { x, y };
    }
}
