using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Road_Lap1
{
    public class Line
    {
        public List<Point> roadPoints = new List<Point>();
        public int roadNumber { get; set; }
        public Line(int roadNumber)
        {
            this.roadNumber = roadNumber;
        }
    }
}
