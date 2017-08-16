using MultithreadTest.Personnel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MultithreadTest.Tests
{
    public class EmployeesTest
    {
        public static void Tutorial()
        {
            #region Enseignant tests


            Enseignant p = new Enseignant("ProfesseurMan");
            Balayeur b = new Balayeur("BalayeurBoy");

            Task task1 = new Task(p.Enseigner);
            Task task2 = new Task(b.Balayer);

            task1.Start();
            task2.Start();

            Console.WriteLine("Main thread ended");

            #endregion
        }

    }
}
