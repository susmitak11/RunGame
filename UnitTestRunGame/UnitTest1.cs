using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace UnitTestRunGame
{
    [TestClass]
    
    public class UnitTest1
    {
        [TestMethod]
        public void TestRandom()
        {//testing if the random numbers is within the limit
            Random rand = new Random();
            int Result = rand.Next(10, 20);
            Assert.IsTrue(Result >= 10 && Result <= 20);
        }

        [TestMethod]
        public void TestLargeValue()
        {//testing the random number is not greater than the value provided
            Random rand = new Random();
            int Result = rand.Next(10, 20);
            Assert.IsFalse(Result >20);
        }

    }
}
