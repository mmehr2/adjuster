namespace adjuster
{
    public interface ISensorControl
    {
        double GetMinCurrent();
        double GetMaxCurrent();
        double GetMinLuminance();
        double GetMaxLuminance();
        double GetLuminance();
        void SetCurrent(double value);
    };
}
