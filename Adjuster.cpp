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

class IAdjuster {
   IAdjuster() = default;
   // etc.
   virtual ~IAdjuster() = 0;
   virtual double SetLuminance(double value, double tolerance) = 0;
}

class Adjuster : public IAdjuster {
   ISensorControl& sc;
   void BSearchLum(double low, double hi, double target, double tolerance) {
        avg = (low + hi)/2.; // need to use double divisor
        sc.SetCurrent(avg);
        double lum = sc.GetLuminance();
        
       if (abs(lum - target) < tolerance) {
         return  lum;
        }
        else if (lum > target)
          return BSearchLum(low, avg, target, tolerance);
       else
          return BSearchLum(avg, hi, target, tolerance);
      }
public:
   Adjuster(const ISensorControl& sc_) : sc(sc_) {}
   override double SetLuminance(double target, double tolerance) {
       // use sc to set current values and zero in on proper luminance
       
      return BSearchLum(sc.GetMinCurrent(), sc.GetMaxCurrent(), target, tolerance);
    }
}
