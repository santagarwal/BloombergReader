using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BloombergReader.Core.BloombergRequests;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace BloombergReader.Core.Tests
{
    [TestClass]
    public class IntradayBarDataRequestTests
    {
        [TestMethod]
        public void IntradayBarDataRequest_SmokeTest()
        {
            // Arrange
            var intradayBarDataRequest = new IntradayBarDataRequest("security");

            // Act
            int counter = intradayBarDataRequest.GetBars().Count();

            // Assert
            Assert.IsTrue(counter > 0);
        }
    }
}
