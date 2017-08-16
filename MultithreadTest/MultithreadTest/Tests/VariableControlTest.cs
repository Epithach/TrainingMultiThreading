using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;

namespace MultithreadTest.Tests
{
    /*
     * Les variables de contrôle
     * 
     * Il peut sembler que les variables de contrôle soient un concept très poussé, mais pas du tout !
     * Il s'agit bêtement d'une variable globale que seul le thread principal modifiera et que les threads enfants contrôleront.
     * Ce concept est particulièrement efficace dans le cas où le thread effectue une boucle infinie.
     */
    public class VariableControlTest
    {
        //Quelques variables à portée globale.
        private static bool _quitter = false;
        private static int _identificateur = 0;

        public static void Tutorial()
        {
            Console.Title = "Variables de contrôle";

            //On crée un tableau de threads.
            Thread[] threads = new Thread[5];

            //On itère à travers le tableau afin de créer et lancer les threads.
            for (int i = 0; i < threads.Length; i++)
            {
                //Création et lancement des threads.
                threads[i] = new Thread(OperThread);
                threads[i].Start();

                //On laisse passer 500ms entre les création de thread.
                Thread.Sleep(500);
            }

            //On demande à ce que tous les threads quittent.
            _quitter = true;

            Console.ReadKey();
        }

        static void OperThread()
        {
            //On donne au thread un identificateur unique.
            int id = ++_identificateur;

            Console.WriteLine("Début du thread {0}", id);

            while (!_quitter)
            {
                //On fait des choses ici tant qu'on ne désire pas quitter...
                Console.WriteLine("Thread {0} a le contrôle", id);

                //On met le thread en état de sommeil pour 1000ms / 1s.
                Thread.Sleep(1000);
            }

            Console.WriteLine("Thread {0} terminé", id);
        }
    }
}
