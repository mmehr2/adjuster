using System;

namespace adjuster
{
    class Program
    {
        static void usage()
        {
            Console.WriteLine("Usage: adjuster TARGET [TOLERANCE]");
            Console.WriteLine("  where TARGET is luminance value 0.0-256.0");
            Console.WriteLine("  and optional TOLERANCE is in luminance units as well");
        }
        static int Main(string[] args)
        {
            double target = 100.0;
            double tolerance = 0.1;
            Console.WriteLine("Test run of luminance adjustment using SensorControl mockup");
            if (args.Length < 2) {
                usage();
                return 0;
            }
            // input two doubles from args[1:2]
            Console.WriteLine($"Target: {target} at Tolerance: {tolerance}");
            try
            {
                ISensorControl m = new SensorControlMock();
                IAdjuster a = new Adjuster(m);
                a.SetLuminance(target, tolerance);
                return 0;
            }
            catch
            {
                // output the exception here
                return 1;
            }
        }
    }
}
