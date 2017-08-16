using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MultithreadTest.Personnel
{
    class Balayeur
    {
        private string Name { get; set; }

        public Balayeur(string name)
        {
            this.Name = name;
            Console.WriteLine("Je suis le nouveau baleyeur : " + this.Name );
        }

        public void Balayer()
        {
            Console.WriteLine(this.Name + " commence à baleyer !");
            for (int i = 0; i < 50; i++)
            {
                Console.WriteLine("BALAYEUR BALAYE");
            }
            Console.Write(this.Name + " a fini de balayer !");
            return;
        }
    }
}
