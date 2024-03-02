using fundamentals.basic_control_structures;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace fundamentalsTest
{
    [TestClass]
    public class DataTypesTest
    {
        [TestMethod]
        public void DataTypesSampleTest()
        {
            try
            {
                DataTypes dataTypes = new DataTypes();
                dataTypes.DataTypesSample();
                // MSTest does not have assertTrue method that takes a message as in your Java example
                // If the method executes without throwing an exception, the test will pass automatically
            }
            catch (System.Exception)
            {
                // If an exception is caught, the test will fail
                Assert.Fail("Method execution should not throw an exception.");
            }
        }
    }
}
