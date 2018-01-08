using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Simulator;

namespace Tests
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void TestMethod1()
        {

            var sim = new Simulation();
            sim.Simulate();

        }
    }
}
