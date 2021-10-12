using Road_Lap1.Configuration.Intensity;

namespace Road_Lap1.Configuration.Intensity
{
    public static class IntensityFactory
    {
        public static IIntensity CreateDetermineIntensity(double? x, double? y = null) => new DetermineIntensity(x);

        public static IIntensity CreateExponentialIntensity(double? x, double? y = null) => new ExponentialIntensity(x);

        public static IIntensity CreateNormalIntensity(double? x, double? y) => new NormalIntensity(x, y);

        public static IIntensity CreateUniformIntensity(double? x, double? y) => new UniformIntensity(x, y);
    }
}
