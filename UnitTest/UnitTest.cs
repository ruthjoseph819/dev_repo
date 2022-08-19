using Microsoft.VisualStudio.TestTools.UnitTesting;
using DateApp;

namespace UnitTest
{
    [TestClass]
    public class UnitTest
    {
        [TestMethod]
        public void AddDaysToDate_Test()
        {
           // Arrange

            string inputdate = "28/02/2021" ;
            int inputdays = 5;
            string expectedOutput = "5/3/2021";
            // Act
            string actualOutput = Program.addDaysToDate(inputdate, inputdays);
            
            // Assert
            Assert.AreEqual(expectedOutput, actualOutput);
        }
    }
}
