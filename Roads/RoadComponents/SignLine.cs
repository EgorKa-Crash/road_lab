using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Road_Lap1
{
    class SignLine
    {
        public List<TrafficSignals> signPoints = new List<TrafficSignals>();
        public int roadNumber { get; set; }
        public SignLine(int roadNumber)
        {
            this.roadNumber = roadNumber;
        }
    }
}
