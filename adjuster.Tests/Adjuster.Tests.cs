using NUnit.Framework;
using adjuster;

namespace adjuster.Tests
{
    public class Adjuster_Tests
    {
        private BinarySearchingAdjuster bsa;
        private SensorControlMock ms;
        private double avgLuminance { get => (ms.GetMinLuminance() + ms.GetMaxLuminance())/2.0;  }
        private double currentTolerance = 0.02;  // experimentally determined as between 0.01 and 0.02 for LUM range 0-1000

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
            Assert.That(bsa.Luminance, Is.EqualTo(TARGET).Within(TOLERANCE));
        }

        private void testIfTargetThrowsException(double TARGET, double TOLERANCE)
        {
            Assert.That(
            () => {
                bsa.SetLuminance(TARGET, TOLERANCE);
            },
            Throws.ArgumentException);
        }

        private void testIfTargetSetsCurrentInTolerance(double TARGET, double TOLERANCE, double CURRENT, double CUR_TOL)
        {
            bsa.SetLuminance(TARGET, TOLERANCE);
            Assert.That(bsa.Current, Is.EqualTo(CURRENT).Within(CUR_TOL));
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
        public void test_SetMinLuminanceTarget_TestIfFinalCurrentIsInTolerance()
        {
            double TOLERANCE = 0.1;
            double TARGET = ms.GetMinLuminance();
            double CURRENT = ms.GetMinCurrent();
            double CUR_TOL = currentTolerance;
            testIfTargetSetsCurrentInTolerance(TARGET, TOLERANCE, CURRENT, CUR_TOL);
        }

        [Test]
        public void test_SetMaxLuminanceTarget_TestIfFinalCurrentIsInTolerance()
        {
            double TOLERANCE = 0.1;
            double TARGET = ms.GetMaxLuminance();
            double CURRENT = ms.GetMaxCurrent();
            double CUR_TOL = currentTolerance;
            testIfTargetSetsCurrentInTolerance(TARGET, TOLERANCE, CURRENT, CUR_TOL);
        }

        [Test]
        public void test_ToleranceZero_ThrowsException()
        {
            double TOLERANCE = 0.0;
            double TARGET = avgLuminance;
            testIfTargetThrowsException(TARGET, TOLERANCE);
        }

        [Test]
        public void test_ToleranceNegative_ThrowsException()
        {
            double TOLERANCE = -2.0;
            double TARGET = avgLuminance;
            testIfTargetThrowsException(TARGET, TOLERANCE);
        }
    }

}