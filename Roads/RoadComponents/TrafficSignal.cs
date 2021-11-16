using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Road_Lap1
{
    public class TrafficSignal
    { 
        public Point Point { get; set; }

        public TrafficSignalType Signal { get; set; }        

        public TrafficSignal(TrafficSignalType sign, Point p)
        {
            Signal = sign;
            Point = p;
        }
    }
}
