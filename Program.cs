using System;

namespace adjuster
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");
            ISensorControl m = new SensorControlMock();
            IAdjuster a = new Adjuster(m);
            a.SetLuminance(100.0, 0.1);
        }
    }
}
