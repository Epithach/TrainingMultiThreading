using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace MultithreadTest.Tests
{
    public class ThreadTest
    {
        public static void Tutorial()
        {
            //Il faut créer un objet ParameterizedThreadStart dans le constructeur
            //du thread afin de passer un paramètre.
            Thread th = new Thread(new ParameterizedThreadStart(Afficher));

            Thread th2 = new Thread(new ParameterizedThreadStart(Afficher));

            //Lorsqu'on exécute le thread, on lui donne son paramètre de type Object.
            th.Start("A");

            th2.Start("B");

            Console.ReadKey();
        }

        //La méthode prend en paramètre un et un seul paramètre de type Object.
        static void Afficher(object texte)
        {
            for (int i = 0; i < 10000; i++)
            {
                //On écrit le texte passer en paramètre. N'oubliez pas de le caster 
                //car il s'agit d'un type Object, pas String.
                Console.Write((string)texte);
            }
            Console.WriteLine("<------------Thread {0} terminé----------->", (string)texte);
        }
    }
}
