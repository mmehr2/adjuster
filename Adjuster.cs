// current to LED
// sensor luminance (photo diode)

/*
IAdjuster
    double SetLuminance(double value);
Adjuster - algo to adjust current until luminance is what we need
inject ISensorControl
    double GetMinCurrent() const;
    double GetMaxCurrent() const;
    double GetLuminance();
    void SetCurrent(double value);
*/
using System;

namespace adjuster {
    public class BinarySearchingAdjuster : IAdjuster {
        ISensorControl sc;
        double BSearchLum(double low, double hi, double target, double tolerance) {
            if (target > sc.GetMaxLuminance() || target < sc.GetMinLuminance())
            {
                throw new System.ArgumentException($"Target luminance {target} out of range {sc.GetMinLuminance()}:{sc.GetMaxLuminance()}", "target");
            }
            if (tolerance <= 0.0)
            {
                throw new System.ArgumentException($"Target tolerance {tolerance} must be positive", "tolerance");
            }
            double avg = (low + hi) / 2.0; // need to use double divisor
            sc.SetCurrent(avg);
            double lum = sc.GetLuminance();

            if (Math.Abs(lum - target) < tolerance) {
                return lum;
            }
            else if (lum > target)
                return BSearchLum(low, avg, target, tolerance);
            else
                return BSearchLum(avg, hi, target, tolerance);
        }

        public BinarySearchingAdjuster(ISensorControl sc_) {
            sc = sc_;
        }
        public double SetLuminance(double target, double tolerance) {
            // use sc to set current values and zero in on proper luminance

            return BSearchLum(sc.GetMinCurrent(), sc.GetMaxCurrent(), target, tolerance);
        }
    };

};