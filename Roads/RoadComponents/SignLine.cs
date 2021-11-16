using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Road_Lap1
{
    public class SignLine
    {
        public List<TrafficSignal> signPoints = new List<TrafficSignal>();
        public int roadNumber { get; set; }
        public SignLine(int roadNumber)
        {
            this.roadNumber = roadNumber;
        }
    }
}
