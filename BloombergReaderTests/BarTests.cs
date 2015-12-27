using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using BloombergReader.Model;

namespace BloombergReaderTests
{
    [TestClass]
    public class BarTests
    {
        [TestMethod]
        public void BarType_CloseGreaterThanOpen_ReturnsBull()
        {
            Bar bar = new Bar() { Close = 100, Open = 20 };
            Assert.AreEqual(BarTypes.Bull, bar.BarType);
        }

        [TestMethod]
        public void BarType_CloseLessThanOpen_ReturnsBear()
        {
            Bar bar = new Bar() { Close = 10, Open = 200 };
            Assert.AreEqual(BarTypes.Bear, bar.BarType);
        }

        [TestMethod]
        public void BarType_CloseIsEqualToOpen_ReturnsNotDefined()
        {
            Bar bar = new Bar() { Close = 10, Open = 10 };
            Assert.AreEqual(BarTypes.NotDefined, bar.BarType);
        }
    }
}
