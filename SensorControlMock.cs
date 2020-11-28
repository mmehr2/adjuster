using System;

namespace adjuster
{

    class SensorControlMock : ISensorControl
    {
        //
        double data;
        double input;

        public override double GetMinCurrent() { return 0.0; }
        public override double GetMaxCurrent() { return 255.0; }
        public override double GetLuminance() { return data; }
        public override void SetCurrent(double value) {

            double MIN_LUMINANCE = 0.0;
            double MAX_LUMINANCE = 256.0;

            // set value of luminance as function of input current
            input = value; // in amps
            double delta = input - GetMinCurrent(); // 1:1 xfer function converts to units of 1/256 of full-scale range
            double range = GetMaxCurrent() - GetMinCurrent();
            double out_range = MAX_LUMINANCE - MIN_LUMINANCE;
            data = out_range * delta / range + MIN_LUMINANCE;
            //std::cout << "Set current to " << input << " mA gives output luminance of " << data << std::endl;
            Console.WriteLine($"Set current to {input} mA gives output luminance of {data}");
        }
    };

}