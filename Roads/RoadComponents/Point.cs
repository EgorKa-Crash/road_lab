using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Road_Lap1
{
    public class Point
    {
        public int x { get; set; }
        public int y { get; set; }
        public int maximumAllowedSpeed { get; set; }

        public Point(int x, int y)
        {
            this.x = x;
            this.y = y;
            //driveStatus = true;
            maximumAllowedSpeed = 110;
        }

        public Point(Point P)
        {
            this.x = P.x;
            this.y = P.y;
        }
    }
}
