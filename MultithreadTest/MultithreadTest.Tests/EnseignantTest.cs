using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using MultithreadTest.Personnel;

namespace MultithreadTest.Tests
{
    [TestClass]
    public class EnseignantTest
    {
        [TestMethod]
        public void Test_DireDate()
        {
            Enseignant enseignant = new Enseignant("Enseignant Boy");

            DateTime current = new DateTime();
            current = DateTime.Now;

            var phrase = enseignant.DireLaDate(current);
            Assert.AreNotEqual(0, phrase.Length);

            var result = "Aujourd'hui nous sommes le : " + current;

            Assert.AreEqual(result, phrase);

            return;
        }
    }
}
