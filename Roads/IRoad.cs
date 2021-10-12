using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Road_Lap1
{
    interface IRoad
    {
        int MAX_SPEED { get; set; }
        int MIN_SPEED { get; set; }
        List<RoadMarking> marking { get; set; }
        List<SignLine> roadSign { get; set; }

        // int highwayNumber { get; set; }
        List<Line> roads { get; set; }
        int[] typesRoadMarking { get; set; }
        Point[] way { get; set; }

        void setTrafficLight(); //симулятор светофора

        // void pointer();
        // void pointer1();


    }
}
