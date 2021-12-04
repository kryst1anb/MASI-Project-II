using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace UnitTests
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void TestMethod1()
        {
            //Arrange
            string pregnancies = "5";

            //Act
            bool isValid = MiASI_Project2_MedicalSupportSystem.PatientAddData.isValidPregnancies(pregnancies);

            //Assert
            Assert.IsTrue(isValid);
        }
    }
}
