#include "SensorControlMock.h"
#include "Adjuster.h"

#include <iostream>
using std::cout;
using std::endl;
#include <cmath>
using std::atof;

/*
Document related classes used here:
IAdjuster
    double SetLuminance(double value);
Adjuster - algo to adjust current until luminance is what we need
inject ISensorControl
    double GetMinCurrent() const;
    double GetMaxCurrent() const;
    double GetLuminance();
    void SetCurrent(double value);
*/

int main(int argc, char**argv)
{
    double target = 100.0;
    double tolerance = 0.1;
    if (argc <= 1) {
        cout << "Usage: adjuster TARGET [TOLERANCE]\n";
        cout << "  where TARGET is luminance value 0-255\n";
        cout << "  and optional TOLERANCE is in luminance units as well\n";
        cout << endl;
        return 0;
    }
    else if (argc > 2) {
        tolerance = atof(argv[2]);
    }
    target = atof(argv[1]);
    cout << "Adjust luminance to " << target << " until tolerance of " << tolerance << " is achieved." << endl;
    // create a sensor control using the mock device
    SensorControlMock m;
    Adjuster a(m);
    a.SetLuminance(target, tolerance);
    return 0;
}
