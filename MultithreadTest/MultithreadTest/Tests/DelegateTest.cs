using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MultithreadTest.Tests
{
    public class DelegateTest
    {
        delegate int Calcul(int i1, int i2);

        public static void Tutorial()
        {
            //Affichage de la console.
            Console.WriteLine("Test de delegate");
            Console.WriteLine("----------------------");

            //On passe à la méthode Afficher la méthode à lancer et les arguments.
            Afficher(Add, 25, 19);
            Afficher(Sub, 52, 17);
            Afficher(Mul, 10, 12);
            Afficher(Div, 325, 5);

            //On ne ferme pas la console immédiatement.
            Console.ReadKey();
        }

        //On fait une méthode générale qui prendra le delegate en paramètre.
        static void Afficher(Calcul calcul, int i, int j)
        {
            Console.WriteLine("{0} {1} {2} = {3}", i, calcul.Method.Name,
                j, calcul(i, j));
        }

        //Méthodes très simples qui ont toutes un type de retour et des paramètres identiques.
        static int Add(int i, int j) { return i + j; }
        static int Sub(int i, int j) { return i - j; }
        static int Mul(int i, int j) { return i * j; }
        static int Div(int i, int j) { return i / j; }
    }
}
