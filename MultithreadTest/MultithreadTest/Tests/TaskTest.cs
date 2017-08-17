using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MultithreadTest.Tests
{
    public class TaskTest
    {
        public static void Tutorial()
        {
            List<string> list = new List<string>()
            {
                "String1",
                "String2",
                "String3",
                "String4",
                "String5",
                "String6",
                "String3",
                "String4",
                "String5",
                "String6",
                "String3",
                "String4",
                "String5",
                "String6",
                "String3",
                "String4",
                "String5",
                "String6",
                "String3",
                "String4",
                "String5",
                "String6",
                "String3",
                "String4",
                "String5",
                "String6",
                "String3",
                "String4",
                "String5",
                "String6",
                "String3",
                "String4",
                "String5",
                "String6",
                "String3",
                "String4",
                "String5",
                "String6"
            };

            Parallel.ForEach(list, text =>
            {
                for(int i = 0; i < 9999999; i++)
                {

                }
                Console.WriteLine(">> Current Text : " + text + " -- Thread ID : " + Task.CurrentId);
            });

        }
    }
}
