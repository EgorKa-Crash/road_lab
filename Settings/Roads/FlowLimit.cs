using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Road_Lap1.Settings.Roads
{
    public class FlowLimit : LimitBase
    {
        public double Min => MinBase;

        public double Max => MaxBase;

        public FlowLimit(double minSpeed, double maxSpeed) : base(minSpeed, maxSpeed) { }
    }
}
