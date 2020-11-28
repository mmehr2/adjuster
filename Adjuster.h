#include "IAdjuster.h"

class Adjuster : public IAdjuster {
   ISensorControl& sc;
   double BSearchLum(double low, double hi, double target, double tolerance);
public:
	Adjuster(ISensorControl& sc_);
	//~Adjuster() = default;
	virtual ~Adjuster() override {}
   double SetLuminance(double target, double tolerance) override;
};
