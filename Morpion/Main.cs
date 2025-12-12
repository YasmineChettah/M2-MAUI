using System;

public class MorpionGame
{
    public static async Task Main()
    {
        Game game = new Game();
        await game.Play();
    }
}
