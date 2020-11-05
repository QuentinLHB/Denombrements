/**
* titre : Dénombrements
* description : Effectue des Arrangements, Permutations et Combinaisons en mode console.
* auteur : QuentinLHB
* date création : 05/11/2020
* date dernière modification : 05/11/2020
*/
using System;

namespace Denombrements
{
    class Program
    {
        static int Menu()
        {
            /// Affiche le menu et récupère la saisie de l'utilisateur
            /// Retourne la saisie
            Console.WriteLine("Permutation ...................... 1");
            Console.WriteLine("Arrangement ...................... 2");
            Console.WriteLine("Combinaison ...................... 3");
            Console.WriteLine("Quitter .......................... 0");
            Console.Write("Choix :                            ");
            int choix = int.Parse(Console.ReadLine());
            return choix;
        }

        static int Saisie(string msg)
        {
            /// Affiche un message, récupère la saisie, et boucle jusqu'à l'obtention d'un entier.
            /// msg : Message à afficher.
            /// Retourne l'entier tapé.
            int n = 0;
            bool ok = false;
            while (ok != true)
            {
                try
                {
                    Console.Write(msg);
                    n = int.Parse(Console.ReadLine());
                    ok = true;
                }
                catch
                {
                    Console.WriteLine("Erreur de saisie.");
                }
            }
            return n;
        }

        static long CalculR(int n, int ini)
        {
            /// Calcul de R
            /// n : Nombre d'élements du sous ensemble
            /// ini : Initialisation de k
            /// Retourne R.
            long r = 1;
            for (int k = ini; k <= n; k++)
                r *= k;
            return r;
        }

        static void AffichResult(string msg, long r)
        {
            /// Affiche le résultat de l'opération choisie
            /// msg : Affiche les valeurs entrées par l'utilisateur
            /// r : le résultat à afficher
            Console.WriteLine(msg + r);
        }

       
        static void Main(string[] args)
        {
            int choix = 5;
            while (choix != 0)
            {
                choix = 5;
                while (choix > 3 | choix < 0)
                {
                    choix = Menu();
                }
                
                if (choix == 0) 
                { 
                    Environment.Exit(0);
                }

                if (choix == 1)
                {
                    int total = Saisie("nombre total d'éléments à gérer = ");
                    long r = CalculR(total, 1);
                    AffichResult((total.ToString() + "! = "), r);
                }
                else
                {
                    if (choix == 2)
                    {
                        int total = Saisie("nombre total d'éléments à gérer = ");
                        int SousEns = Saisie("nombre d'éléments dans le sous ensemble = ");
                        long r = CalculR(SousEns, 1);
                        AffichResult("A(" + total.ToString() + "/" + SousEns.ToString() + ") = ", r);
                    }
                    else
                    {
                        int total = Saisie("nombre total d'éléments à gérer = ");
                        int sousEns = Saisie("nombre d'éléments dans le sous ensemble = ");
                        long r1 = CalculR(sousEns, (total - sousEns + 1));
                        long r2 = CalculR(sousEns, 1);
                        AffichResult("C(" + total.ToString() + "/" + sousEns.ToString() + ") = ", (r1 / r2));
                    }
                }
            }
            Console.ReadLine();
        }
    }
}
