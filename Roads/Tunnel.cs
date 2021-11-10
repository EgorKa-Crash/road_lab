using Road_Lap1.Roads;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Road_Lap1
{
    class Tunnel : CommonsMethodsForRoads, IRoad
    {
        public int START_SIGN_POINT { get; set; } = 19;
        public int FIN_SIGN_POINT { get; set; } = 14;
        public int MAX_SPEED { get; set; } = 90;
        public int MIN_SPEED { get; set; } = 0;
        public Point[] way { get; set; } //маршрут, передаваемый при создании дороги

        public List<SignLine> roadSign { get; set; }

        public List<Line> roads { get; set; } // все полосы у дороги

        public int[] typesRoadMarking { get; set; } // маркировка 1 = , 2 _____, 3 ------  

        public List<RoadMarking> marking { get; set; }

        private Timer _timer;



        //public int[] speedLimits { get; set; } 
        //public int highwayNumber { get; set; }

        private int ROAD_WIDTH = 40;
        private readonly int POINTS_INTERVAL = 50;
        private readonly int SMOOTHING = 3;// 1 - гипергладко , 5 - ближе к оригиналу

        public Tunnel(Point[] way, int startTunnel, int finTunnel)
        {            
            typesRoadMarking = new int[4] { 2, 2, 1, 1 };
            marking = new List<RoadMarking>();
            roads = new List<Line>();
            roadSign = new List<SignLine>();
            this.way = Pointer(way, POINTS_INTERVAL, SMOOTHING); 
            buildTunnel(startTunnel, finTunnel);
            setTrafficLight();
            roadSign[0].signPoints[18].en = TrafficSignal.Signals.Tunnel;
            roadSign[1].signPoints[13].en = TrafficSignal.Signals.Tunnel;          
        }

        private int trafficLights = 0;
        public void setTrafficLight() //симулятор светофора
        {
            switch (trafficLights)
            {
                case 0:
                {
                    roadSign[0].signPoints[19].en = TrafficSignal.Signals.RedSemaphore;
                    roadSign[1].signPoints[14].en = TrafficSignal.Signals.RedSemaphore;
                }
                break;
                case 1:
                {
                    roadSign[0].signPoints[19].en = TrafficSignal.Signals.GreenSemaphore;
                }
                break;
                case 2:
                {
                    roadSign[0].signPoints[19].en = TrafficSignal.Signals.RedSemaphore;
                    roadSign[1].signPoints[14].en = TrafficSignal.Signals.RedSemaphore;
                }
                break;
                case 3:
                {
                    roadSign[1].signPoints[14].en = TrafficSignal.Signals.GreenSemaphore;
                    trafficLights = -1;
                }
                break;
            }
            trafficLights++;
        }
         
         
        /// <summary>
        /// создание полос и разметки
        /// </summary>
        /// <param name="countPassingRoads"></param>
        /// <param name="countOppositeRoads"></param>
        private void buildTunnel(int startTunnel, int finTunnel)
        {
            int countPassingRoads = 1;
            int countOppositeRoads = 1;
            int N = countPassingRoads + countOppositeRoads;

            marking.Add(new RoadMarking(typesRoadMarking[0]));
            for (int j = 0; j < way.Length; j++) //проход по всей длинне маршрута
            {
                if (j < startTunnel || j > finTunnel)
                {
                    marking[0].markingPoints.Add(LineCoord(way[j].x - ((0 * ROAD_WIDTH) - (N * ROAD_WIDTH / 2)), way[j].y, way[j].x, way[j].y, j, way));
                }
                else
                {
                    marking[0].markingPoints.Add(LineCoord((way[j].x + ROAD_WIDTH / 2), way[j].y, way[j].x, way[j].y, j, way));
                }
            }
            marking.Add(new RoadMarking(typesRoadMarking[2]));
            for (int j = 0; j < way.Length; j++) //проход по всей длинне маршрута
            {
                if (j < startTunnel || j > finTunnel)
                {
                    marking[1].markingPoints.Add(LineCoord(way[j].x - ((2 * ROAD_WIDTH) - (N * ROAD_WIDTH / 2)), way[j].y, way[j].x, way[j].y, j, way));
                }
                else
                {
                    marking[1].markingPoints.Add(LineCoord((way[j].x - ROAD_WIDTH / 2), way[j].y, way[j].x, way[j].y, j, way));
                }
            }

            marking.Add(new RoadMarking(typesRoadMarking[1]));
            for (int j = 0; j < startTunnel - 1; j++) //проход по всей длинне маршрута
            {
                marking[2].markingPoints.Add(new Point(way[j].x, way[j].y));
            }

            marking.Add(new RoadMarking(typesRoadMarking[1]));
            for (int j = finTunnel + 2; j < way.Length; j++) //проход по всей длинне маршрута
            {
                marking[3].markingPoints.Add(new Point(way[j].x, way[j].y));
            }


            for (int i = 0; i < 2; i++) //проход по всем полосам
            {
                roads.Add(new Line(i));

                for (int j = 0; j < way.Length; j++) //проход по всей длинне маршрута
                {
                    if (j < startTunnel || j > finTunnel)
                    {
                        roads[i].roadPoints.Add(LineCoord(way[j].x - (i * ROAD_WIDTH + 0.5 * ROAD_WIDTH - (N * ROAD_WIDTH / 2)), way[j].y, way[j].x, way[j].y, j, way));
                    }
                    else
                    {
                        roads[i].roadPoints.Add(new Point(way[j].x, way[j].y));
                    }
                }
            }
            roads[1].roadPoints.Reverse();

            roadSign = SetLimSpeed(countPassingRoads, countOppositeRoads, N, MAX_SPEED, way, roadSign, ROAD_WIDTH);
             
        } 
    }
}
