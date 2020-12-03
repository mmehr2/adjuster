namespace adjuster
{
    public interface ISensorControl
    {
        // input
        double MinCurrent { get; }
        double MaxCurrent { get; }
        double Current { get; set;  }

        //output
        double MinLuminance { get; }
        double MaxLuminance { get; }
        public double Luminance { get; }
        
    };
}
