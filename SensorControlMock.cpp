#include "SensorControlMock.h"
#include <iostream>

double MIN_LUMINANCE = 0.0;
double MAX_LUMINANCE = 256.0;

void SensorControlMock::SetCurrent(double input_) {
	// set value of luminance as function of input current
	input = input_; // in amps
	auto delta = input - GetMinCurrent(); // 1:1 xfer function converts to units of 1/256 of full-scale range
	auto range = GetMaxCurrent() - GetMinCurrent();
	auto out_range = MAX_LUMINANCE - MIN_LUMINANCE;
	data = out_range * delta / range + MIN_LUMINANCE;
	std::cout << "Set current to " << input << " mA gives output luminance of " << data << std::endl;
}