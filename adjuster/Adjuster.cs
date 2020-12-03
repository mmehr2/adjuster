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
        // search results
        public int Steps { get; private set;  }
        public double Target { get; private set; }
        public double Tolerance { get; private set; }
        public double Current { get; private set; }
        public double Luminance { get; private set; }
        double BSearchLum(double low, double hi, double target, double tolerance) {
            if (target > sc.MaxLuminance || target < sc.MinLuminance)
            {
                throw new ArgumentException($"Target luminance {target} out of range {sc.MinLuminance}:{sc.MaxLuminance}", "target");
            }
            if (tolerance <= 0.0)
            {
                throw new ArgumentException($"Target tolerance {tolerance} must be positive", "tolerance");
            }
            double avg = (low + hi) / 2.0; // need to use double divisor
            Steps += 1;
            sc.Current = (avg);
            double lum = sc.Luminance;

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
            Steps = 0;
            Target = Tolerance = 0.0;
            Current = Luminance = 0.0;
        }
        public double SetLuminance(double target, double tolerance) {
            // use sc to set current values and zero in on proper luminance
            Steps = 0;
            Target = target;
            Tolerance = tolerance;
            Luminance = BSearchLum(sc.MinCurrent, sc.MaxCurrent, target, tolerance);
            Current = sc.Current;
            double diff = Luminance - Target;
            Console.WriteLine($"Final: current {Current} gives luminance {Luminance} in {Steps} steps, a difference of {diff} from target {Target} at tolerance level {Tolerance}");
            return Luminance;
        }
    };

};