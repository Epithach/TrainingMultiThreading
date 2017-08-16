using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MultithreadTest.Personnel
{
    public class Enseignant
    {
        private string Name { get; set; }

        public Enseignant(string name)
        {
            this.Name = name;
            Console.WriteLine("Je suis le nouvel enseignant : " + this.Name);
        }

        public string DireLaDate(DateTime date)
        {
            var phrase = ("Aujourd'hui nous sommes le : " + date.ToString());
            return phrase;
        }

        public void Enseigner()
        {            
            Console.WriteLine(this.Name + " commence à enseigner !");
            for (int i = 0; i < 50; i++)
            {
                Console.WriteLine("PROFESSEUR ENSEIGNE");
            }
            Console.WriteLine(this.Name + " a fini son cours");
        }
    }
}
