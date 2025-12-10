using System;

public class Morpion
{
    // Create a matrice 3x3 to intilize board
    private char[,] plateau = new char[3, 3];

    public Morpion()
    {
        // Initialize board with empty cases
        for (int i = 0; i < 3; i++)
            for (int j = 0; j < 3; j++)
                plateau[i, j] = ' ';
    }

    public void Display()
    {
        Console.Clear();
        Console.WriteLine(" |  0   1   2|");
        Console.WriteLine(" ------------");
        for (int i = 0; i < 3; i++)
        {
            Console.Write(i + "| ");
            for (int j = 0; j < 3; j++)
            {
                Console.Write(plateau[i, j]);
                if (j <= 2) Console.Write(" | ");
            }
            Console.WriteLine();
            if (i <= 2) Console.WriteLine(" ------------");
        }
    }

    public bool Play(int x, int y, char symbole)
    {
        // Check if case is empty
        if (plateau[x, y] == ' ')
        {
            plateau[x, y] = symbole;
            return true;
        }
        return false;
    }
}
