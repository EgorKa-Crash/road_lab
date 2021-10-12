using Road_Lap1.Configuration;
using Road_Lap1.Configuration.Roads;
using Road_Lap1.Roads;
using System.Collections.Generic;

namespace Road_Lap1
{
    class Highway : CommonsMethodsForRoads , IRoad 
    {
        public int MAX_SPEED { get; set; }
        public int MIN_SPEED { get; set; }  
        public Point[] way { get; set; } //маршрут, передаваемый при создании дороги 
        public List<Line> roads { get; set; } // все полосы у дороги
        public List<SignLine> roadSign { get; set; } // дорожные знаки
        public int[] typesRoadMarking { get; set; } // маркировка 1 = , 2 _____, 3 ------ 

        public List<RoadMarking> marking { get; set; }

        //public int[] speedLimits { get; set; } 
        public int highwayNumber { get; set; }

        private int ROAD_WIDTH = 40;
        private readonly int POINTS_INTERVAL = 50;
        private readonly int SMOOTHING = 3;// 1 - гипергладко , 5 - ближе к оригиналу

        public Highway(Point[] way, int[] typesRoadMarking, int highwayNumber, SystemSettings settings)
        {
            this.MAX_SPEED = settings.SpeedLimit.Max;
            this.MIN_SPEED = settings.SpeedLimit.Min;
            marking = new List<RoadMarking>();
            roads = new List<Line>();
            roadSign = new List<SignLine>();
            this.way = Pointer(way, POINTS_INTERVAL, SMOOTHING);
            this.typesRoadMarking = typesRoadMarking;
            this.highwayNumber = highwayNumber;
            var countPassingRoads = settings.Traffic.GetCountLine(Direction.OneWay);
            var countOppositeRoads = settings.Traffic.GetCountLine(Direction.TwoWay);

            BuildHighway(countPassingRoads, countOppositeRoads);

            if (settings.TypeRoad == TypeRoad.Road)
            {
                if (countOppositeRoads > 0)
                    roadSign[1].signPoints[10].en = TrafficSignal.Signals.CarRoad;
                if (countPassingRoads > 0)
                    roadSign[0].signPoints[15].en = TrafficSignal.Signals.CarRoad;
            }
            else
            {
                if (countOppositeRoads > 0)
                    roadSign[1].signPoints[10].en = TrafficSignal.Signals.Highway;
                if (countPassingRoads > 0)
                    roadSign[0].signPoints[15].en = TrafficSignal.Signals.Highway;
            }
        }
        

        /// <summary>
        /// создание полос и разметки
        /// </summary>
        /// <param name="countPassingRoads"></param>
        /// <param name="countOppositeRoads"></param>
        private void BuildHighway(int countPassingRoads, int countOppositeRoads)
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


            //задание точек маршрута, прямолинейные и редкие
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

        public void setTrafficLight()
        {
            throw new System.NotImplementedException();
        }
    }
} 