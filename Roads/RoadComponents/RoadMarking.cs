using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Road_Lap1
{
    public class RoadMarking
    {
        public int typeRoadMarking { get; set; }
        public List<Point> markingPoints = new List<Point>();

        public RoadMarking(int markLane)
        {
            this.typeRoadMarking = markLane;
        }
    }
}
