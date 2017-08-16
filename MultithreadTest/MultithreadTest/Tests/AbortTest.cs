using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;

namespace MultithreadTest.Tests
{
    public class AbortTest
    {
        public static void Tutorial()
        {
            Thread thread = new Thread(Test);

            thread.Start();
            Thread.Sleep(100);

            //On tue le processus. À NE PAS FAIRE !
            thread.Abort();

            Console.ReadKey();
        }

        public static void Test()
        {
            for (int i = 0; i < 10000; i++)
                Console.WriteLine(i);
        }
    }
}
