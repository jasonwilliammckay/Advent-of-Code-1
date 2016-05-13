

using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using AdventOfCode_1;

namespace AdventCode1_TestSuite
{
    [TestClass]
    public class UnitTest1
    {
        int floorResult;

        [TestMethod]
        public void test_validFile()
        {
            floorResult = Program.determineFloor("../../input_1_valid.txt");
            Assert.AreEqual(floorResult, 232);
            Assert.IsTrue(BasementTracker.basementHasBeenFound());
            Assert.AreEqual((int)BasementTracker.getBasementPosition(), 1783);
        }

        [TestMethod]
        public void test_emptyFile()
        {
            floorResult = Program.determineFloor("../../input_2_empty.txt");
            Assert.AreEqual(floorResult, 0);
            Assert.IsFalse(BasementTracker.basementHasBeenFound());
        }

        [TestMethod]
        public void test_onlyDown()
        {
            floorResult = Program.determineFloor("../../input_3_onlyDown.txt");
            Assert.AreEqual(floorResult, -10);
            Assert.IsTrue(BasementTracker.basementHasBeenFound());
            Assert.AreEqual((int)BasementTracker.getBasementPosition(), 1);
        }

        [TestMethod]
        public void test_onlyUp()
        {
            floorResult = Program.determineFloor("../../input_4_onlyUp.txt");
            Assert.AreEqual(floorResult, 10);
            Assert.IsFalse(BasementTracker.basementHasBeenFound());
        }

        [TestMethod]
        public void test_equalUpAndDown()
        {
            int result = Program.determineFloor("../../input_5_evenUpAndDown.txt");
            Assert.AreEqual(result, 0);
            Assert.IsFalse(BasementTracker.basementHasBeenFound());
        }


    }
}
