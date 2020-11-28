class ISensorControl {
    public:
    virtual double GetMinCurrent() const =0;
    virtual double GetMaxCurrent() const =0;
    virtual double GetLuminance() const =0;
    virtual double GetCurrent() const =0;
    virtual void SetCurrent(double value) =0;
    ISensorControl() = default;
    virtual ~ISensorControl() = default;
};
