using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Road_Lap1
{
    partial class TrafficSignals : Point
    { 
        public TrafficSignal.Signals en { get; set; } 
         
        public TrafficSignals(TrafficSignal.Signals sign, int x, int y)
        {
            en = sign;
            this.x = x;
            this.y = y;
            //driveStatus = true;
            maximumAllowedSpeed = 110;
        }

        public TrafficSignals(TrafficSignal.Signals sign, Point p, int maxSpeed)
        {
            en = sign;
            this.x = p.x;
            this.y = p.y;
            //driveStatus = true;
            maximumAllowedSpeed = maxSpeed;
        }

    }
}
