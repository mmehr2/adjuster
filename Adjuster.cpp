// current to LED
// sensor luminance (photo diode)

#include <cmath>
using std::abs;

#include "SensorControl.h"
#include "Adjuster.h"

double Adjuster::BSearchLum(double low, double hi, double target, double tolerance) {
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

Adjuster::Adjuster(ISensorControl& sc_) : sc(sc_) {}

double Adjuster::SetLuminance(double target, double tolerance) {
    // use sc to set current values and zero in on proper luminance
    
    return BSearchLum(sc.GetMinCurrent(), sc.GetMaxCurrent(), target, tolerance);
}

