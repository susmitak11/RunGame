using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using RunGame;

namespace UnitTestRunGame
{
    [TestClass]
    
    public class UnitTest1
    {
        [TestMethod]
        public void TestPunterCreation()
        {
            //testing the Factory not creating the instances that are not defined
            //if you don't give proper name based on the defined classes, no instance will be created
            RunGame.PunterAbstract result = PunterFactory.CreatePunter("John");
            Assert.AreEqual(null, result);
        }

        [TestMethod]
        public void TestFactoryCreation()
        {
            //testing if Factory class is creating proper instances
            PunterAbstract punter1 = PunterFactory.CreatePunter("test1");
            PunterAbstract punter2 = PunterFactory.CreatePunter("test2");

            //testing the number of created instances
            int result = PunterFactory.ReturnCount();
            Assert.AreEqual(2, result);
        }

    }
}
