using System;
using System.Threading.Tasks;

public class AIPlayer : IPlayer
{
    public char Symbol { get; }
    private Random range = new Random();

    public AIPlayer(char symbol)
    {
        Symbol = symbol;
    }

    public async Task<int[]> GetNextMove()
    {
        await Task.Delay(1000);

        int x = range.Next(0, 3);
        int y = range.Next(0, 3);

        return new int[] { x, y };
    }
}
