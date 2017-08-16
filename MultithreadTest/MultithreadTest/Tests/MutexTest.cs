using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;

namespace MultithreadTest.Tests
{
    /*
     * MUTEX
     * 
     * Les Mutex sont excessivement similaires aux lock.
     * Cependant, si vous désirez créer de nombreuses sections critiques indépendantes,
     * les Mutex ont l'avantage d'être sous forme d'objets plutôt que d'instructions.
     * Un petit exemple vous éclaira sur l'utilisation des Mutex.
     */
    public class MutexTest
    {
        private const int TAILLE_TABLEAU = 2;

        //On crée les Mutex.
        private static Mutex _muxMultiplier = new Mutex();
        private static Mutex _muxDiviser = new Mutex();
        private static Mutex _muxPrint = new Mutex();

        //On crée les tableaux de valeurs.
        private static int[] _valDiv = new int[TAILLE_TABLEAU];
        private static int[] _valMul = new int[TAILLE_TABLEAU];

        //Objet Random et variable de contrôle.
        private static Random _rand = new Random((int)DateTime.Now.Ticks);
        private static bool _quitter = false;

        public static void Tututial()
        {
            Console.Title = "Exemple de Mutex";

            //On crée et on démarre les threads.
            Thread init = new Thread(Initialiser);
            init.Start();

            Thread mul = new Thread(Multiplier);
            mul.Start();

            Thread div = new Thread(Diviser);
            div.Start();

          //  Thread print = new Thread(Print);
          //  div.Start("TestBoy");

            //On laisse les threads fonctionner un peu...
            Thread.Sleep(3000);
            //On demande à ce que les opérations se terminent.
            _quitter = true;

            Console.ReadKey();
        }

        private static void Initialiser()
        {
            while (!_quitter)
            {
                //On demande au thread d'attendre jusqu'à ce qu'il ait le contrôle sur les Mutex.
                _muxMultiplier.WaitOne();
                _muxDiviser.WaitOne();

                for (int i = 0; i < TAILLE_TABLEAU; i++)
                {
                    //On assigne au tableau de nouvelles valeurs.
                    _valMul[i] = _rand.Next(2, 20);
                    _valDiv[i] = _rand.Next(2, 20);
                }

                Console.WriteLine("Nouvelles valeurs !");

                //On relâche les Mutex
                _muxDiviser.ReleaseMutex();
                _muxMultiplier.ReleaseMutex();

                //On tombe endormi pour 100ms.
                Thread.Sleep(100);
            }
        }

        private static void Multiplier()
        {
            while (!_quitter)
            {
                //On demande le Mutex de multiplication.
                _muxMultiplier.WaitOne();

                //On multiplie.
                Console.WriteLine("{0} x {1} = {2}", _valMul[0], _valMul[1], _valMul[0] * _valMul[1]);

                //On relâche le Mutex.
                _muxMultiplier.ReleaseMutex();

                //On tombe endormi pour 200ms.
                Thread.Sleep(200);
            }
        }

        private static void Diviser()
        {
            while (!_quitter)
            {
                //On demande le Mutex de division.
                _muxDiviser.WaitOne();

                //On divise.
                Console.WriteLine("{0} / {1} = {2}", _valDiv[0], _valDiv[1], _valDiv[0] * _valDiv[1]);

                //On relâche le Mutex de Division.
                _muxDiviser.ReleaseMutex();

                //On tombe endormi pour 200ms.
                Thread.Sleep(200);
            }
        }

        private static void Print(object test)
        {
            while (_quitter)
            {
                _muxPrint.WaitOne();
                Console.WriteLine("Petit bonjour de la part de #{0}", test);
                _muxPrint.ReleaseMutex();
                Thread.Sleep(200);
            }
        }

    }
}
