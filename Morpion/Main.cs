using System;

public class MorpionGame
{
    public static void Main()
    {
        Morpion game = new Morpion();
        char actualPlayer = 'X';

        while (true)
        {
            game.Display();
            Console.WriteLine($"Player {actualPlayer} turn");

            Console.Write("Enter line (0-2) : ");
            int x = int.Parse(Console.ReadLine());

            Console.Write("Enter column (0-2) : ");
            int y = int.Parse(Console.ReadLine());

            bool coupValide = game.Play(x, y, actualPlayer);

            if (!coupValide)
            {
                Console.WriteLine("Case not available ! Click on Enter.");
                Console.ReadLine();
                continue; // redo
            }

            if (game.CheckWin(actualPlayer))
            {
                game.Display();
                Console.WriteLine($"Player {actualPlayer} won !");
                break;
            }

            if (game.IsFull())
            {
                game.Display();
                Console.WriteLine("Equals !");
                break;
            }

            // Alternate player
            actualPlayer = (actualPlayer == 'X') ? 'O' : 'X';
        }
    }
}
