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
    public class Adjuster : IAdjuster {
        ISensorControl sc;
        double BSearchLum(double low, double hi, double target, double tolerance) {
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

        public Adjuster(ISensorControl sc_) {
            sc = sc_;
        }
        public double SetLuminance(double target, double tolerance) {
            // use sc to set current values and zero in on proper luminance

            return BSearchLum(sc.GetMinCurrent(), sc.GetMaxCurrent(), target, tolerance);
        }
    };

};