using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;

namespace MultithreadTest.Tests
{
    /**
     * JOIN 
     * 
     * Il s'agit très simplement d'attendre la fin d'un autre thread afin de continuer le thread dans lequel le Join() est défini.
     */
    public class JoinTest
    {
        public static void Tutorial()
        {
            Thread th = new Thread(new ParameterizedThreadStart(Afficher));

            Thread th2 = new Thread(new ParameterizedThreadStart(Afficher));

            th.Start("A");

            //On attend la fin du thread A avant de commencer le thread B.
            th.Join();

            th2.Start("B");

            Console.ReadKey();
        }

        static void Afficher(object texte)
        {
            for (int i = 0; i < 10000; i++)
            {
                Console.Write((string)texte);
            }
        }
    }
}
