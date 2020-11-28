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
abstract class ISensorControl {
    public abstract double GetMinCurrent();
    public abstract double GetMaxCurrent();
    public abstract double GetLuminance();
    public abstract void SetCurrent(double value);
};

class ISensorControlMock : ISensorControl {
    //
    double data;

    public override double GetMinCurrent() { return 0.0; }
    public override double GetMaxCurrent() { return 255.0; }
    public override double GetLuminance() { return data; }
    public override void SetCurrent(double value) { data = value; }
};

abstract class IAdjuster {
    public abstract double SetLuminance(double value, double tolerance);
};

class Adjuster : IAdjuster {
   ISensorControl sc;
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

   public Adjuster(ISensorControl sc_) {
        sc = sc_;
    }
    public override double SetLuminance(double target, double tolerance) {
       // use sc to set current values and zero in on proper luminance
       
      return BSearchLum(sc.GetMinCurrent(), sc.GetMaxCurrent(), target, tolerance);
    }
};

