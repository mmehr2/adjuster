namespace adjuster
{
    public interface ISensorControl
    {
        // input
        double GetMinCurrent();
        double GetMaxCurrent();
        double GetCurrent();
        void SetCurrent(double value);

        //output
        double GetMinLuminance();
        double GetMaxLuminance();
        double GetLuminance();
    };
}
