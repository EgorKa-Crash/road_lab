using Road_Lap1.Settings;
using Road_Lap1.Roads;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Road_Lap1
{
    class Tunnel : RoadBase
    {
        public Tunnel(Point[] way, int startTunnel, int finTunnel, SystemSettings _settings)
        {
            this.MAX_SPEED = _settings.Speed.Max;
            this.MIN_SPEED = 0;
            this.START_SIGN_POINT = 19;
            this.FIN_SIGN_POINT = 14;
            typesRoadMarking = new int[4] { 2, 2, 1, 1 };
            marking = new List<RoadMarking>();
            roads = new List<Line>();
            roadSign = new List<SignLine>();
            this.way = Pointer(way, POINTS_INTERVAL, SMOOTHING);
            BuildRoad(startTunnel, finTunnel);
            setTrafficLight();
            roadSign[0].signPoints[18].Signal = TrafficSignalType.Tunnel;
            roadSign[1].signPoints[13].Signal = TrafficSignalType.Tunnel;
        }

        private int trafficLights = 0;
        public override void setTrafficLight() //симулятор светофора
        {
            switch (trafficLights)
            {
                case 0:
                {
                    roadSign[0].signPoints[19].Signal = TrafficSignalType.RedSemaphore;
                    roadSign[1].signPoints[14].Signal = TrafficSignalType.RedSemaphore;
                }
                break;
                case 1:
                {
                    roadSign[0].signPoints[19].Signal = TrafficSignalType.GreenSemaphore;
                }
                break;
                case 2:
                {
                    roadSign[0].signPoints[19].Signal = TrafficSignalType.RedSemaphore;
                    roadSign[1].signPoints[14].Signal = TrafficSignalType.RedSemaphore;
                }
                break;
                case 3:
                {
                    roadSign[1].signPoints[14].Signal = TrafficSignalType.GreenSemaphore;
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
        protected override void BuildRoad(int startTunnel, int finTunnel)
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
