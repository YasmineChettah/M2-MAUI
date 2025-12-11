using System;

public class Board
{
    private char[,] display = new char[3, 3];

    public Board()
    {
        // Initialize board with empty spaces
        for (int i = 0; i < 3; i++)
            for (int j = 0; j < 3; j++)
                display[i, j] = ' ';
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
                Console.Write(display[i, j]);
                if (j <= 2) Console.Write(" | ");
            }
            Console.WriteLine();
            if (i <= 2) Console.WriteLine(" ------------");
        }
    }

    public bool PlayMove(int x, int y, char symbole)
    {
        if(x < 0 || y < 0 || x > 2 || y > 2) return false;

        // Check if case is empty
        if (display[x, y] == ' ')
        {
            display[x, y] = symbole;
            return true;
        }
        return false;
    }

    public bool CheckWin(char symbole)
    {
        // Lines win
        for (int i = 0; i < 3; i++)
        {
            if (display[i, 0] == symbole && display[i, 1] == symbole && display[i, 2] == symbole)
                return true;
        }

        // Columns win
        for (int j = 0; j < 3; j++)
        {
            if (display[0, j] == symbole && display[1, j] == symbole && display[2, j] == symbole)
                return true;
        }

        // Diagonal win
        if (display[0, 0] == symbole && display[1, 1] == symbole && display[2, 2] == symbole)
            return true;

        return false; // no win
    }

    public bool IsFull()
    {
        for (int i = 0; i < 3; i++)
            for (int j = 0; j < 3; j++)
                if (display[i, j] == ' ')
                    return false;

        return true; // no empty case => equals
    }
}




