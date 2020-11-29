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
            Console.WriteLine("Test run of luminance adjustment using SensorControl mockup");
            if (args.Length == 0) {
                usage();
                return 0;
            }
            try
            {
                // input two doubles from args[1:2]
                double target = 100.0;
                double tolerance = 0.1;
                target = Double.Parse(args[0]);
                if (args.Length > 1)
                {
                    tolerance = Double.Parse(args[1]);
                }
                Console.WriteLine($"Target: {target} at Tolerance: {tolerance}");
                ISensorControl m = new SensorControlMock();
                IAdjuster a = new BinarySearchingAdjuster(m);
                a.SetLuminance(target, tolerance);
                return 0;
            }
            catch (System.Exception e)
            {
                System.Console.WriteLine(e.Message);
                return 1;
            }
        }
    }
}
