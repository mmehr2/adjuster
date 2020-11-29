using NUnit.Framework;
using adjuster;

namespace adjuster.Tests
{
    public class Sensor_Tests
    {
        //private BinarySearchingAdjuster bsa;
        private SensorControlMock ms;

        [SetUp]
        public void Setup()
        {
            // deprecated: do not use; see Microsoft docs here: 
            ms = new SensorControlMock();
            //bsa = new BinarySearchingAdjuster(ms);
        }

        [Test]
        public void Test_SetCurrent0_GetCurrentIsZero()
        {
            double TEST_CURRENT = 0.0;
            ms.SetCurrent(TEST_CURRENT);
            Assert.AreEqual(ms.GetCurrent(), TEST_CURRENT);
        }
    }
}