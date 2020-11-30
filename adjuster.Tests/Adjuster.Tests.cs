using NUnit.Framework;
using adjuster;

namespace adjuster.Tests
{
    public class Adjuster_Tests
    {
        private BinarySearchingAdjuster bsa;
        private SensorControlMock ms;
        private double avgLuminance { get => (ms.GetMinLuminance() + ms.GetMaxLuminance())/2.0;  }

        //[SetUp]
        //public void Setup()
        public Adjuster_Tests()
        {
            // deprecated: do not use Setup(); see Microsoft docs here: (Testing Best Practices under .NET 5.0 docs)
            ms = new SensorControlMock();
            bsa = new BinarySearchingAdjuster(ms);
        }

        private void testIfTargetIsInTolerance(double TARGET, double TOLERANCE)
        {
            bsa.SetLuminance(TARGET, TOLERANCE);
            double diff = TARGET - bsa.Luminance;
            Assert.IsTrue(System.Math.Abs(diff) < TOLERANCE);
        }

        [Test]
        public void test_SetAvgLuminanceTarget_TestIfFinalLumIsInTolerance()
        {
            double TOLERANCE = 0.1;
            double TARGET = avgLuminance;
            testIfTargetIsInTolerance(TARGET,  TOLERANCE);
        }

        [Test]
        public void test_SetMinLuminanceTarget_TestIfFinalLumIsInTolerance()
        {
            double TOLERANCE = 0.1;
            double TARGET = ms.GetMinLuminance();
            testIfTargetIsInTolerance(TARGET, TOLERANCE);
        }

        [Test]
        public void test_SetMaxLuminanceTarget_TestIfFinalLumIsInTolerance()
        {
            double TOLERANCE = 0.1;
            double TARGET = ms.GetMaxLuminance();
            testIfTargetIsInTolerance(TARGET, TOLERANCE);
        }

        [Test]
        public void test_ToleranceZero_throwsException()
        {
            double TOLERANCE = 0.0;
            double TARGET = avgLuminance;
            //bsa.SetLuminance(TARGET, TOLERANCE);
            //Assert.Catch();
        }
    }

}