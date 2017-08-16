using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;

namespace MultithreadTest.Tests
{
    /*
     * LOCK
     * 
     * L'instruction lock permet de verrouiller efficacement une ressource tant et aussi longtemps qu'un bloc d'instruction est en cours.
     * Cela signifie que si d'autres threads tentent d'accéder à la même ressource en même temps, ils ne pourront pas.
     * Cela ne signifie pas qu'ils planteront et se termineront,
     * mais plutôt qu'ils passeront le jeton à un autre thread et attendront patiemment leur tour afin d'accéder à cette ressource.
     */
        public class LocksTest
        {
            //Variable témoin du lock.
            private static Object _lock = new Object();

            //Sert à initialiser des valeurs pseudos-aléatoires.
            private static Random _rand = new Random((int)DateTime.Now.Ticks);

            //Variable de contrôle.
            private static bool _quitter = false;

            //Variables globales étant affectées par les threads.
            private static int _nominateur;
            private static int _denominateur;

            public static void Tutorial()
            {
                Console.Title = "Démonstration des lock";

                //On crée les threads.
                Thread init = new Thread(Initialiser);
                init.Start();

                Thread reinit = new Thread(Reinitialiser);
                reinit.Start();

                Thread div = new Thread(Diviser);
                div.Start();

                //On les laisse travailler pendant 3 seconde.
                Thread.Sleep(3000);
                //Puis on leur demande de quitter.
                _quitter = true;

                Console.ReadKey();
            }

            private static void Initialiser()
            {
                //Boucle infinie contrôlée.
                while (!_quitter)
                {
                    //On verouille l'accès aux variables tant que l'on a pas terminé.
                    lock (_lock)
                    {
                        //Initialisation des valeurs.
                        _nominateur = _rand.Next(20);
                        _denominateur = _rand.Next(2, 30);
                    }

                    //On recommence dans 250ms.
                    Thread.Sleep(250);
                }
            }

            private static void Reinitialiser()
            {
                //Boucle infinie contrôlée.
                while (!_quitter)
                {
                    //On verouille l'accès aux variables tant que l'on a pas terminé.
                    lock (_lock)
                    {
                        //Réinitialisation des valeurs.
                        _nominateur = 0;
                        _denominateur = 0;
                    }

                    //On recommence dans 300ms.
                    Thread.Sleep(300);
                }
            }

            private static void Diviser()
            {
                //Boucle infinie contrôlée.
                while (!_quitter)
                {
                    //On verouille pendant les opérations.
                    lock (_lock)
                    {
                        //Erreur si le dénominateur est nul.
                        if (_denominateur == 0)
                            Console.WriteLine("Division par 0");
                        else
                        {
                            Console.WriteLine("{0} / {1} = {2}", _nominateur, _denominateur, _nominateur / (double)_denominateur);
                        }
                    }

                    //On recommence dans 275ms.
                    Thread.Sleep(275);
                }
            }
        }
    }