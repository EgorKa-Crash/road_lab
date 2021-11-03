using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;   

namespace Road_Lap1.Roads.CarFold
{
    class CarMovementCalculations
    { 
        public static void carMovement(List<Car> cars , IRoad road, int countOppositeRoads, double overtakingBlockingRadius, int maxSpeed)
        {
            double BRAKING_RADIUS = 80;
            double ADVANCE_RADIUS = 85;
            for (int i = 0; i < cars.Count; i++)
            {
                Car frontCar = null;
                double minRadToFrontCar = 5000;
                double stoplightMinRad = 5000;

                List<Car> cars2 = cars.Where(t => t.roadNumber == cars[i].roadNumber).ToList();
                FrontCarFinder(cars, i, ref frontCar, ref minRadToFrontCar, cars2);
                stoplightMinRad = StopLightFidder(cars, road, countOppositeRoads, i, stoplightMinRad);


                cars[i].maximumAllowedSpeed = road.roadSign[cars[i].roadNumber < countOppositeRoads ? 1 : 0].signPoints[cars[i].roadPointNumber].maximumAllowedSpeed; //установка ограничения скорости 

                int carSpeed = cars[i].CurrentCarSpeed();

                //разные виды торможения, иначе разгон
                if (minRadToFrontCar < BRAKING_RADIUS + carSpeed * 2)
                {
                    cars[i].BrakingCar((int)minRadToFrontCar, frontCar.currentCarSpeed);
                }
                else if (stoplightMinRad < BRAKING_RADIUS + carSpeed * 2 || cars[i].maximumAllowedSpeed < carSpeed || cars[i].carDesiredSpeed < carSpeed) // 
                {
                    cars[i].BrakingCar();
                }
                else if (cars[i].maximumAllowedSpeed * 0.95 > carSpeed  )
                    cars[i].BoostCar();

                // шаг вперед 
                if(cars[i].currentCarSpeed > 0.001)
                cars[i].BeginCar(road.roads[cars[i].roadNumber].roadPoints[cars[i].roadPointNumber].x, road.roads[cars[i].roadNumber].roadPoints[cars[i].roadPointNumber].y);

                // проверка, может ли данная машина пойти на обгон
                OvertakingCheck(cars, road, overtakingBlockingRadius, ADVANCE_RADIUS, i, ref frontCar, ref minRadToFrontCar, carSpeed);

                //try
               // {
                    if (cars[i].Radius(road.roads[cars[i].roadNumber].roadPoints[cars[i].roadPointNumber].x, road.roads[cars[i].roadNumber].roadPoints[cars[i].roadPointNumber].y) < 30)
                    {
                        cars[i].roadPointNumber++;
                        cars[i].carOvertaking = false;
                    }
               // }
               /*
                catch
                {
                    cars.Remove(cars[i]);
                }*/

                if (cars[i].roadPointNumber >= road.roads[cars[i].roadNumber].roadPoints.Count - 2)
                {
                    cars.Remove(cars[i]);
                } 
            }
        }

        private static void OvertakingCheck(List<Car> cars, IRoad road, double overtakingBlockingRadius, double ADVANCE_RADIUS, int i, ref Car frontCar, ref double minRadToFrontCar, int carSpeed)
        {
            if (frontCar != null && frontCar.currentCarSpeed < cars[i].carDesiredSpeed && minRadToFrontCar < ADVANCE_RADIUS + carSpeed * 2) //если встретилась впереди машина, которую хочется обогнать
            {
                minRadToFrontCar = 5000;
                //поиск радиуса до ближайшей машины, которая совершает обгон
                foreach (Car car in cars)
                {
                    double minRad1 = cars[i].Radius(car.xCarCoordinate, car.yCarCoordinate);

                    if (minRad1 < minRadToFrontCar && car.carOvertaking == true && cars[i] != car)
                    {
                        minRadToFrontCar = minRad1;
                        frontCar = car;
                    }
                }

                // проверка при перестроении навлево
                if (road.typesRoadMarking[cars[i].roadNumber] == 3 && 0 == cars.Where(car => car.roadNumber == cars[i].roadNumber - 1).Where(car => car.roadPointNumber > cars[i].roadPointNumber - 4 && car.roadPointNumber < cars[i].roadPointNumber + 7).ToList().Count && cars[i].carOvertaking == false && minRadToFrontCar > overtakingBlockingRadius)
                {
                    cars[i].roadNumber--;
                    if (carSpeed < 20)
                        cars[i].roadPointNumber += 0;
                    else
                        cars[i].roadPointNumber += 2;
                    cars[i].carOvertaking = true;
                }

                // проверка при перестроении направо
                if (road.typesRoadMarking[cars[i].roadNumber + 1] == 3 && 0 == cars.Where(car => car.roadNumber == cars[i].roadNumber + 1).Where(car => car.roadPointNumber > cars[i].roadPointNumber - 4 && car.roadPointNumber < cars[i].roadPointNumber + 7).ToList().Count && cars[i].carOvertaking == false && minRadToFrontCar > overtakingBlockingRadius)
                {
                    cars[i].roadNumber++;
                    if (carSpeed < 20)
                        cars[i].roadPointNumber += 0;
                    else
                        cars[i].roadPointNumber += 2;
                    cars[i].carOvertaking = true;
                }
            }
        }

        private static double StopLightFidder(List<Car> cars, IRoad road, int countOppositeRoads, int i, double stoplightMinRad)
        {
            // нахождение минимального радиуса до точки со светофором
            for (int j = cars[i].roadPointNumber; j < road.roads[cars[i].roadNumber].roadPoints.Count; j++)
            {
                double minRad1 = 500;
                //if (road.roads[cars[i].roadNumber].roadPoints[j].driveStatus == false)
                if (road.roadSign[cars[i].roadNumber < countOppositeRoads ? 1 : 0].signPoints[j].en == TrafficSignal.Signals.RedSemaphore)
                {
                    minRad1 = cars[i].Radius(road.roads[cars[i].roadNumber].roadPoints[j].x, road.roads[cars[i].roadNumber].roadPoints[j].y);
                    if (stoplightMinRad > minRad1)
                    {
                        stoplightMinRad = minRad1;
                    }
                }
            }

            return stoplightMinRad;
        }

        private static void FrontCarFinder(List<Car> cars, int i, ref Car frontCar, ref double minRadToFrontCar, List<Car> cars2)
        {
            foreach (Car car in cars2) // нахождение минимального радиуса до впереди идущего авто
            {
                double minRad1 = cars[i].Radius(car.xCarCoordinate, car.yCarCoordinate);
                //сравнение происходит со сдвинутыми радиусами, для определения, где перед машины, куда она едет
                double minRad2 = car.Radius(cars[i].xCarCoordinate + cars[i].xCarSpeed, cars[i].yCarCoordinate + cars[i].yCarSpeed);

                if (minRad2 < minRad1 && minRad1 < minRadToFrontCar && cars[i] != car)
                {
                    minRadToFrontCar = minRad1;
                    frontCar = car;
                }
            }
        }

        public static Point LineCoord(double x, double y, int xP, int yP, double cos, double sin)
        {
            Point coord; // Setting up the int array for return

            x -= xP;       // преобразование координат в систему координат с началом в точке around
            y -= yP;

            Point temp = new Point((int)
                (x * cos + y * sin), (int)
                (y * cos - x * sin)
                );      // применяем матрицу поворота

            temp.x += xP;     // обратное преобразование координат
            temp.y += yP;

            return temp;
        }
    }
}
