using Road_Lap1.Configuration.Distribution;
using Road_Lap1.Settings;
using System;
using System.Collections.Generic;

namespace Road_Lap1.Configuration.Distribution
{
    public static class DistributionFactory
    {
        private static Dictionary<Type, Func<double?, double?, IDistribution>> _constructor = new Dictionary<Type, Func<double?, double?, IDistribution>>
        {
            [typeof(NormalDistribution)] = (mx, dx) => new NormalDistribution(mx, dx),
            [typeof(UniformDistribution)] = (a, b) => new UniformDistribution(a, b),
            [typeof(ExponentialDistribution)] = (lymbda, _) => new ExponentialDistribution(lymbda),
            [typeof(DetermineDistribution)] = (a, _) => new DetermineDistribution(a),
        };

        public static IDistribution Create<T>(double? x, double? y = null)
                                              where T : IDistribution 
                                              => _constructor[typeof(T)](x, y);
    }
}
