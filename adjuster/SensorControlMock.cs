using System;

namespace adjuster
{

    public class SensorControlMock : ISensorControl
    {
        //
        double data;
        double input;

        public double MinCurrent { get => 0.0; }
        public double MaxCurrent { get => 255.0; }
        public double MinLuminance { get => 0.0; }
        public double MaxLuminance { get => 1000.0; }
        //public double Current { get => input; }
        public double Luminance { get => data; }
        public double Current
        {
            get { return input; }
            set
            {

                double MIN_LUMINANCE = MinLuminance;
                double MAX_LUMINANCE = MaxLuminance;
                double MIN_CURRENT = MinCurrent;
                double MAX_CURRENT = MaxCurrent;
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
        }
    }
}