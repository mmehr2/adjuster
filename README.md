# adjuster
Simple binary search with hardware interface (from interview)

Plan:
1. Save Adjuster.cpp in Github repo w. readme
1. Get it to compile (VSCode via CL *or* VS2019)
1. Copy over to an (empty) C# file and repo
1. Convert the code over into proper C# interfaces and classes
1. Implement NUNIT tests on the C# side
1. Get those tests to compile and run
1. Get to GREEN!
1. Ideas for refactoring...let them appear!

- MILESTONE: C++ running (ACHIEVED)
- MILESTONE: AC# running (ACHIEVED)
- MILESTONE: AC# tests running (ACHIEVED)

Usage: adjuster TARGET [TOLERANCE]  
where TARGET is luminance value 0.0-1000.0  
and optional TOLERANCE is in luminance units as well

### Typical output
.\adjuster 49 .01  
Test run of luminance adjustment using SensorControl mockup  
Target: 49 at Tolerance: 0.01 
Setting current to 127.5 mA gives output luminance of 500  
Setting current to 63.75 mA gives output luminance of 250  
Setting current to 31.875 mA gives output luminance of 125  
Setting current to 15.9375 mA gives output luminance of 62.5  
Setting current to 7.96875 mA gives output luminance of 31.25  
Setting current to 11.953125 mA gives output luminance of 46.875  
Setting current to 13.9453125 mA gives output luminance of 54.6875  
Setting current to 12.94921875 mA gives output luminance of 50.78125  
Setting current to 12.451171875 mA gives output luminance of 48.828125  
Setting current to 12.7001953125 mA gives output luminance of 49.8046875  
Setting current to 12.57568359375 mA gives output luminance of 49.31640625  
Setting current to 12.513427734375 mA gives output luminance of 49.072265625  
Setting current to 12.4822998046875 mA gives output luminance of 48.9501953125  
Setting current to 12.49786376953125 mA gives output luminance of 49.01123046875  
Setting current to 12.490081787109375 mA gives output luminance of 48.980712890625  
Setting current to 12.493972778320312 mA gives output luminance of 48.9959716796875  
Final: current 12.493972778320312 gives luminance 48.9959716796875 in 16 steps, a difference of -0.0040283203125 from target 49 at tolerance level 0.01