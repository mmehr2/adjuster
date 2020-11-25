// current to LED
// sensor luminance (photo diode)

#include <cmath>
using std::abs;

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
class ISensorControl {
    public:
    double GetMinCurrent() const;
    double GetMaxCurrent() const;
    double GetLuminance() const;
    void SetCurrent(double value);
};

class ISensorControlMock : public ISensorControl {
    //
    double data;
    public:
    double GetMinCurrent() const { return 0.0; }
    double GetMaxCurrent() const { return 255.0; }
    double GetLuminance() const { return data; }
    void SetCurrent(double value) { data = value; }
};

class IAdjuster {
    public:
   IAdjuster() = default;
   // etc.
   virtual ~IAdjuster() = 0;
   virtual double SetLuminance(double value, double tolerance) = 0;
};

class Adjuster : public IAdjuster {
   ISensorControl& sc;
   double BSearchLum(double low, double hi, double target, double tolerance) {
        double avg = (low + hi)/2.; // need to use double divisor
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
   Adjuster(ISensorControl& sc_) : sc(sc_) {}
   double SetLuminance(double target, double tolerance) override {
       // use sc to set current values and zero in on proper luminance
       
      return BSearchLum(sc.GetMinCurrent(), sc.GetMaxCurrent(), target, tolerance);
    }
};

