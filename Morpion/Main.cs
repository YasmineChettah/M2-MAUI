using System;

public class MorpionGame
{
    public static void Main()
    {
        Morpion jeu = new Morpion();
        char joueurActuel = 'X';

        while (true)
        {
            jeu.Display();
            Console.WriteLine($"Tour du joueur {joueurActuel}");

            Console.Write("Entrez la ligne (0-2) : ");
            int x = int.Parse(Console.ReadLine());

            Console.Write("Entrez la colonne (0-2) : ");
            int y = int.Parse(Console.ReadLine());

            bool coupValide = jeu.Play(x, y, joueurActuel);

            if (!coupValide)
            {
                Console.WriteLine("Case déjà prise ! Appuie sur Enter.");
                Console.ReadLine();
                continue; // redo
            }

            // Alternate gamer
            joueurActuel = (joueurActuel == 'X') ? 'O' : 'X';
        }
    }
}
