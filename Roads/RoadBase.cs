using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Road_Lap1.Roads
{
    public abstract class RoadBase
    {
        public int START_SIGN_POINT { get; set; }
        public int FIN_SIGN_POINT { get; set; }

        public int MAX_SPEED { get; set; }
        protected int MIN_SPEED { get; set; }

        public List<RoadMarking> marking { get; set; }
        public List<SignLine> roadSign { get; set; }
        public List<Line> roads { get; set; }

        public int[] typesRoadMarking { get; set; }

        protected Point[] way { get; set; }

        protected int ROAD_WIDTH = 40;
        protected readonly int POINTS_INTERVAL = 50;
        protected readonly int SMOOTHING = 3;// 1 - гипергладко , 5 - ближе к оригиналу

        public abstract void setTrafficLight(); //симулятор светофора
        protected abstract void BuildRoad(int n, int m);

        /// <summary>
        /// вторая версия сглаживания и добавления промежуточных точек маршрута
        /// </summary>
        protected Point[] Pointer(Point[] way , int POINTS_INTERVAL, int SMOOTHING)
        {
            //Point[] way2; 
            List<Point> way2 = new List<Point>();
            List<Point> way3 = new List<Point>();
            double summRoadLength = 0;

            for (int i = 0; i < way.Length - 1; i++) //по всем дорогам , находение длины маршрута
            {
                int dX = way[i].x - way[i + 1].x;
                int dY = way[i].y - way[i + 1].y;
                summRoadLength += Math.Sqrt(dX * dX + dY * dY);
                way3.Add(new Point(way[i].x, way[i].y));

            }
            int pointsCount = (int)summRoadLength / POINTS_INTERVAL;


            for (int i = way.Length; i < pointsCount; i++) //количество проходов необходимых для добавления нужного количества точек
            {
                i += SMOOTHING;
                way2.Add(new Point(way3[0].x, way3[0].y)); //запись 1 точки в промежуточный результат
                double newRad = summRoadLength / (i + SMOOTHING);
                int newPoint = 0; // номер рассаматриваемоего отрезка
                int oldPoint = 0; // номер рассаматриваемоего отрезка
                int ddx = 0;
                int ddy = 0;

                while (oldPoint < way3.Count - 1) // проход по всем точкам
                {

                    int dX = way3[oldPoint + 1].x - way2[newPoint].x + ddx;
                    int dY = way3[oldPoint + 1].y - way2[newPoint].y + ddy;
                    double oldRad = Math.Sqrt(dX * dX + dY * dY);

                    double otn = newRad / oldRad;
                    if (otn < 0.03)
                        otn = 0.03;
                    if (otn > 1)
                    {
                        oldPoint++;
                        ddx = dX;
                        ddy = dY;
                    }
                    else
                    {
                        way2.Add(new Point(way2[newPoint].x + (int)(dX * otn), way2[newPoint].y + (int)(dY * otn)));
                        newPoint++;
                        ddx = 0;
                        ddy = 0;
                    }
                }
                way2.Add(new Point(way3[way3.Count - 1].x, way3[way3.Count - 1].y)); //запись последней точки трассы

                way3.Clear();
                for (int j = 0; j < way2.Count; j++) //по всем дорогам
                {
                    way3.Add(new Point(way2[j].x, way2[j].y));
                }
                way2.Clear();
            }
            return way3.ToArray();
        }



        protected List<SignLine> SetLimSpeed(int countPassingRoads, int countOppositeRoads, int N, int MAX_SPEED, Point[] way, List<SignLine> roadSign, int ROAD_WIDTH)
        {
            // точки по которым проверяется скорость и расставляются знаки
            if (countPassingRoads > 0)
            {
                roadSign.Add(new SignLine(0));
                for (int j = 0; j < way.Length; j++)
                {
                    var point = LineCoord((way[j].x - (N + 1) * 0.5 * ROAD_WIDTH), way[j].y, way[j].x, way[j].y, j, way);
                    point.maximumAllowedSpeed = MAX_SPEED;
                    roadSign[0].signPoints.Add(new TrafficSignal(TrafficSignalType.Nothing, point));
                }
            }
            roadSign[0].signPoints.Reverse();


            if (countOppositeRoads > 0)
            {
                roadSign.Add(new SignLine(1));
                for (int j = 0; j < way.Length; j++)
                {
                    var point = LineCoord((way[j].x + (N + 1) * 0.5 * ROAD_WIDTH), way[j].y, way[j].x, way[j].y, j, way);
                    point.maximumAllowedSpeed = MAX_SPEED;
                    roadSign[1].signPoints.Add(new TrafficSignal(TrafficSignalType.Nothing, point));
                }
            } 
            return roadSign;
        }



        /// <summary>
        /// нахождение угла отклонения между последовательно идущими отрезками
        /// </summary>
        /// <param name="x">для поворота</param>
        /// <param name="y">для поворота</param>
        /// <param name="xP">точка отсчета</param>
        /// <param name="yP">точка отсчета</param>
        /// <param name="k">номер точки</param>
        /// <returns></returns>
        protected Point LineCoord(double x, double y, double xP, double yP, int k, Point[] way)
        {
            double sin;
            double cos;

            if (k == 0 || k >= way.Length - 1)
            {
                sin = 0;
                cos = 0;
            }
            else
            {
                double deltX = way[k - 1].x - way[k].x;
                double deltY = way[k - 1].y - way[k].y;
                double sin1 = deltX / Math.Sqrt(deltX * deltX + deltY * deltY); //угол у 1 прямой с вертикалью 

                deltX = way[k].x - way[k + 1].x;
                deltY = way[k].y - way[k + 1].y;
                double sin2 = deltX / Math.Sqrt(deltX * deltX + deltY * deltY);

                deltX = way[k - 1].x - way[k].x;
                deltY = way[k - 1].y - way[k].y;
                double cos1 = deltY / Math.Sqrt(deltX * deltX + deltY * deltY); //угол у 1 прямой с вертикалью 

                deltX = way[k].x - way[k + 1].x;
                deltY = way[k].y - way[k + 1].y;
                double cos2 = deltY / Math.Sqrt(deltX * deltX + deltY * deltY);


                sin = (sin1 + sin2) / 2;
                cos = (cos1 + cos2) / 2;
            }

            Point coord; // Setting up the int array for return

            x -= xP;       // преобразование координат в систему координат с началом в точке around
            y -= yP;

            Point temp = new Point((int)
                (x * cos + y * sin), (int)
                (y * cos - x * sin)
                );      // применяем матрицу поворота

            temp.x += (int)xP;     // обратное преобразование координат
            temp.y += (int)yP;
            return temp;
        }
    }
}
