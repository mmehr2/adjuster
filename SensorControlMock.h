#include "SensorControl.h"

// Mockup definition of interface, defined inline
class SensorControlMock : public ISensorControl {
    //
    double data;
    double input;
    public:
    double GetMinCurrent() const override { return 0.0; }
    double GetMaxCurrent() const override { return 255.0; }
    double GetLuminance() const override { return data; }
    double GetCurrent() const override { return input; }
    void SetCurrent(double value) override;
};
