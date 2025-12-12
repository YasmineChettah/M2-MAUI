using System.Collections.Generic;

public class FakePlayer : IPlayer
{
    public char Symbol { get; }

    private Queue<int[]> moves;

    public FakePlayer(char symbol, List<int[]> predefinedMoves)
    {
        Symbol = symbol;
        moves = new Queue<int[]>(predefinedMoves);
    }

    public int[] GetNextMove()
    {
        return moves.Dequeue();
    }
}
