using NUnit.Framework;
using adjuster;

namespace adjuster.Tests
{
    public class Sensor_Tests
    {
        //private BinarySearchingAdjuster bsa;
        private ISensorControl ms;

        //[SetUp]
        //public void Setup()
        public Sensor_Tests()
        {
            // deprecated: do not use Setup(); see Microsoft docs here: (Testing Best Practices under .NET 5.0 docs)
            ms = new SensorControlMock();
            //bsa = new BinarySearchingAdjuster(ms);
        }

        [Test]
        public void Test_SetCurrent0_GetCurrentIsZero()
        {
            double TEST_CURRENT = 0.0;
            ms.Current = (TEST_CURRENT);
            Assert.AreEqual(ms.Current, TEST_CURRENT);
        }

        [Test]
        public void Test_SetMinCurrent_GetCurrentIsEqual()
        {
            double TEST_CURRENT = ms.MinCurrent;
            ms.Current = (TEST_CURRENT);
            Assert.AreEqual(ms.Current, TEST_CURRENT);
        }

        [Test]
        public void Test_SetMaxCurrent_GetCurrentIsEqual()
        {
            double TEST_CURRENT = ms.MaxCurrent;
            ms.Current = (TEST_CURRENT);
            Assert.AreEqual(ms.Current, TEST_CURRENT);
        }

        [Test]
        public void Test_SetAvgCurrent_GetCurrentIsEqual()
        {
            double TEST_CURRENT = (ms.MaxCurrent + ms.MinCurrent) / 2.0;
            ms.Current = (TEST_CURRENT);
            Assert.AreEqual(ms.Current, TEST_CURRENT);
        }
    }

}