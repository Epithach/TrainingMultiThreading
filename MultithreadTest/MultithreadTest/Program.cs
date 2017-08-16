using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using MultithreadTest.Personnel;

namespace MultithreadTest
{
    class Program
    {

        //Mon delegate aura exactement la même signature que ma méthode !
        delegate bool PremierDelegate(string test);
        delegate int Calcul(int a, int b);

        static public bool Test(string test)
        {
            return test.Length < 15;
        }

        static void PrintCalcul(Calcul calcul, int i, int j)
        {
            Console.WriteLine("{0} {1} {2} = {3}", i, calcul.Method.Name,
                j, calcul(i, j));
        }

        static int Add(int i, int j) { return i + j; }
        static int Sub(int i, int j) { return i - j; }
        static int Mul(int i, int j) { return i * j; }
        static int Div(int i, int j) { return i / j; }

        static void Afficher(object text)
        {
            for (int i = 0; i < 1000; i++)
            {
                Console.Write((string)text);
            }
            Console.WriteLine("<------------Thread {0} terminé----------->", (string)text);
        }

        /*
        static void Main(string[] args)
        {
            #region Enseignant tests
            
            //Enseignant p = new Enseignant("ProfesseurMan");
            //Balayeur b = new Balayeur("BalayeurBoy");

            //Task task1 = new Task(p.Enseigner);
            //Task task2 = new Task(b.Balayer);

            //task1.Start();
            //task2.Start();

            Console.WriteLine("Main thread ended");
            
            #endregion

            //Je crée une variable a qui contiendra la méthode Test.
            PremierDelegate a = new PremierDelegate(Test);

            //Au lieu d'appeler Test, je vais appeler a, ce qui me donnera le même résultat
            bool resultat = a("Ceci est un test qui est négatif !");
            bool res2 = a("Positif");

            PrintCalcul(Add, 1, 1);
            PrintCalcul(Sub, 1, 1);
            PrintCalcul(Mul, 1, 1);

            //Il faut créer un objet ParameterizedThreadStart dans le constructeur
            //du thread afin de passer un paramètre.
            Thread th = new Thread(new ParameterizedThreadStart(Afficher));

            Thread th2 = new Thread(new ParameterizedThreadStart(Afficher));

            //Lorsqu'on exécute le thread, on lui donne son paramètre de type Object.
            th.Start("A");

            th2.Start("B");

            Console.ReadKey();
        }
        */

        //Quelques variables à portée globale.
        private static bool _quitter = false;
        private static int _identificateur = 0;
        /*
        static void Main(string[] args)
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
        */

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

        //Variable témoin du lock.
        private static Object _lock = new Object();

        //Sert à initialiser des valeurs pseudos-aléatoires.
        private static Random _rand = new Random((int)DateTime.Now.Ticks);

        //Variables globales étant affectées par les threads.
        private static int _nominateur;
        private static int _denominateur;

        static void Main(string[] args)
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