using Road_Lap1.Configuration;
using Road_Lap1.Configuration.Roads;
using Road_Lap1.Roads;
using System.Collections.Generic;

namespace Road_Lap1
{
    class Highway : RoadBase
    {       
        public int highwayNumber { get; set; }

        public Highway(Point[] way, int[] typesRoadMarking, int highwayNumber, SystemSettings settings)
        {
            this.MAX_SPEED = settings.Speed.Max;
            this.MIN_SPEED = settings.Speed.Min;
            marking = new List<RoadMarking>();
            roads = new List<Line>();
            roadSign = new List<SignLine>();
            this.way = Pointer(way, POINTS_INTERVAL, SMOOTHING);
            this.typesRoadMarking = typesRoadMarking;
            this.highwayNumber = highwayNumber;
            var countPassingRoads = settings.Traffic.CountPasssingLine;
            var countOppositeRoads = settings.Traffic.CountOppositeLine;

            BuildRoad(countPassingRoads, countOppositeRoads);

            if (settings.RoadType == RoadType.Road)
            {
                if (countOppositeRoads > 0)
                    roadSign[1].signPoints[10].Signal = TrafficSignalType.CarRoad;
                if (countPassingRoads > 0)
                    roadSign[0].signPoints[15].Signal = TrafficSignalType.CarRoad;
            }
            else
            {
                if (countOppositeRoads > 0)
                    roadSign[1].signPoints[10].Signal = TrafficSignalType.Highway;
                if (countPassingRoads > 0)
                    roadSign[0].signPoints[15].Signal = TrafficSignalType.Highway;
            }
        }
        

        /// <summary>
        /// создание полос и разметки
        /// </summary>
        /// <param name="countPassingRoads"></param>
        /// <param name="countOppositeRoads"></param>
        protected override void BuildRoad(int countPassingRoads, int countOppositeRoads)
        {
            int N = countPassingRoads + countOppositeRoads;


            for (int i = 0; i < N + 1; i++) //проход по всем полосам разметки
            {
                //double cos;
                //double sin;
                marking.Add(new RoadMarking(typesRoadMarking[i]));
                for (int j = 0; j < way.Length; j++) //проход по всей длинне маршрута
                {
                    marking[i].markingPoints.Add(LineCoord(way[j].x - ((i * ROAD_WIDTH) - (N * ROAD_WIDTH / 2)), way[j].y, way[j].x, way[j].y, j, way));
                }
            }


            //задание точек маршрута 
            for (int i = 0; i < N; i++) //проход по всем полосам
            {
                roads.Add(new Line(i));

                //double cos;
                //double sin;
                for (int j = 0; j < way.Length; j++) //проход по всей длинне маршрута
                {
                    roads[i].roadPoints.Add(LineCoord(way[j].x - (i * ROAD_WIDTH + 0.5 * ROAD_WIDTH - (N * ROAD_WIDTH / 2)), way[j].y, way[j].x, way[j].y, j, way));
                }
            }
            for (int i = 0; i < countPassingRoads; i++)
            {
                roads[countOppositeRoads + i].roadPoints.Reverse();
            }

            roadSign = SetLimSpeed(countPassingRoads, countOppositeRoads, N, MAX_SPEED, way, roadSign, ROAD_WIDTH);
        }

        public override void setTrafficLight()
        {

        }
    }
} 