using System;

namespace adjuster
{

    public class SensorControlMock : ISensorControl
    {
        //
        double data;
        double input;

        public double GetMinCurrent() { return 0.0; }
        public double GetMaxCurrent() { return 255.0; }
        public double GetMinLuminance() { return 0.0; }
        public double GetMaxLuminance() { return 1000.0; }
        public double GetCurrent() { return input; }
        public double GetLuminance() { return data; }
        public void SetCurrent(double value) {

            double MIN_LUMINANCE = GetMinLuminance();
            double MAX_LUMINANCE = GetMaxLuminance();
            double MIN_CURRENT = GetMinCurrent();
            double MAX_CURRENT = GetMaxCurrent();
            if (value < MIN_CURRENT || value > MAX_CURRENT)
            {
                throw new System.ArgumentException($"Current ({value} mA) is out of range ({MIN_CURRENT}:{MAX_CURRENT})", "value");
            }


            // set value of luminance as function of input current
            input = value; // in milliamps
            double delta = input - MIN_CURRENT; // 1:1 xfer function converts to units of 1/256 of full-scale range
            double range = MAX_CURRENT - MIN_CURRENT;
            double out_range = MAX_LUMINANCE - MIN_LUMINANCE;
            data = out_range * delta / range + MIN_LUMINANCE;
            //std::cout << "Set current to " << input << " mA gives output luminance of " << data << std::endl;
            Console.WriteLine($"Setting current to {input} mA gives output luminance of {data}");
        }
    };

}