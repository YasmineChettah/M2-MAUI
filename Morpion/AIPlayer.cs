using System;

public class AIPlayer : Player
{
    private Random playCase = new Random();

    public AIPlayer(char symbol) : base(symbol)
    {
    }

    public override int[] GetNextMove()
    {
        int x = playCase.Next(0, 3);
        int y = playCase.Next(0, 3);

        return new int[] { x, y };
    }
}
