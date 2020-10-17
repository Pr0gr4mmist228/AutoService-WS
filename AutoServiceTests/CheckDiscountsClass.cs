using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using AutoServiceTests;
using AutoServiceMethods;

namespace AutoServiceTests
{
    [TestClass]
    public class CheckDiscountsClass
    {
        [TestMethod]
        public void CheckDiscounts()
        {
            //Assert

            double actualFirst = DiscountsCheck.FirstValue(1);

            double actualSecond = DiscountsCheck.SecondValue(1);

            double expectedFirst = 0.05;
            double expectedSecond = 0.15;

            Assert.AreEqual(actualFirst+1,expectedFirst);
            Assert.AreEqual(actualSecond+1, expectedSecond);
        }
    }
}
