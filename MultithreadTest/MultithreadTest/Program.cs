using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using MultithreadTest.Personnel;
using MultithreadTest.Tests;

namespace MultithreadTest
{
    class Program
    {


        static void Main(string[] args)
        {
            /**
             * Employees tests
             */
            EmployeesTest.Tutorial();

            /**
             * Delegates tests 
             */
            DelegateTest.Tutorial();

            /**
             * Threads tests
             */
            ThreadTest.Tutorial();

            /**
             * Variable de Controle tests
             */
            VariableControlTest.Tutorial();

            /*
             * Lock tests
             */
            LocksTest.Tutorial();

            /*
             * Mutex tests
             */
            MutexTest.Tututial();

            /*
             * SémaphoreSlim tests 
             */
            SemaphoreSlimTest.Tutorial();

            /*
             * Join tests 
             */
            JoinTest.Tutorial();

            /*
             * Task test
             */
            TaskTest.Tutorial();
            /*
             * Abort Tests
             */
            //AbortTest.Tutorial();

            Console.ReadKey();
        }
    }
}