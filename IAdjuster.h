/*
IAdjuster
    double SetLuminance(double value);
Adjuster - algo to adjust current until luminance is what we need
*/

class IAdjuster {
    public:
        IAdjuster() = default;
   virtual ~IAdjuster() = default;
   IAdjuster(const IAdjuster&) = default;
   IAdjuster& operator=(const IAdjuster&) = default;
   virtual double SetLuminance(double value, double tolerance) = 0;
};
