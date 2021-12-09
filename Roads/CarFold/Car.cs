using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Road_Lap1
{
    public class Car
    {
        private readonly double CAR_INERTIA = 0.2; //меньше значение, больше снос


        public double xCarCoordinate { get; set; }
        public Color carColor { get; set; }
        public double yCarCoordinate { get; set; }
        public int roadNumber { get; set; }
        public int roadPointNumber { get; set; }
        public double xCarSpeed { get; set; }
        public double yCarSpeed { get; set; }
        public double currentCarSpeed { get; set; }
        public int carDesiredSpeed { get; set; } // желаемая скорость автомобиля
        public int maximumAllowedSpeed { get; set; } // максимальная разрешенная скорость автомобиля
        public bool carOvertaking { get; set; } // автомобиль обгоняет
         
        public Car(double xCarSpeed, double yCarSpeed, int roadNumber, int carDesiredSpeed, double xCarCoordinate, double yCarCoordinate, double currentCarSpeed, int roadPointNumber, Color carColor)
        {
            this.xCarSpeed = xCarSpeed;
            this.yCarSpeed = yCarSpeed;
            this.currentCarSpeed = currentCarSpeed;
            this.roadNumber = roadNumber;
            this.carDesiredSpeed = carDesiredSpeed;
            this.xCarCoordinate = xCarCoordinate;
            this.yCarCoordinate = yCarCoordinate;
            this.roadPointNumber = roadPointNumber;
            this.carColor = carColor;
            maximumAllowedSpeed = carDesiredSpeed;
        }

        /// <summary>
        /// расчетная скорость машины
        /// </summary>
        /// <returns></returns>
        public int CurrentCarSpeed()
        {
            return (int)(Math.Sqrt(xCarSpeed * xCarSpeed + yCarSpeed * yCarSpeed) * 10.0);
        }

        /*public void recalculateCarSpeed(Road road)
        {
            //if (currentCarSpeed > carDesiredSpeed)
              //ускорение или торможение, для приближения к нормальной скорости

            double Dx = road.xEnd - xCarCoordinate;
            double Dy = road.yEnd - yCarCoordinate;
            double d = Math.Sqrt(Dx * Dx + Dy * Dy); if (d == 0) d = 0.01F;
            double sin = Dx / d;
            double cos = Dy / d;

            xCarSpeed = sin * currentCarSpeed;
            yCarSpeed = cos * currentCarSpeed;
        }*/
        public void BeginCar(int x, int y)
        {
            double Dx = x - xCarCoordinate;
            double Dy = y - yCarCoordinate;
            double d = Math.Sqrt(Dx * Dx + Dy * Dy); if (d == 0) d = 0.01F;
            double sin = Dx / d;
            double cos = Dy / d;

            xCarSpeed += (sin * currentCarSpeed - xCarSpeed) * CAR_INERTIA;
            yCarSpeed += (cos * currentCarSpeed - yCarSpeed) * CAR_INERTIA;

            xCarCoordinate += xCarSpeed;
            yCarCoordinate += yCarSpeed;
        }
        public double Radius(double x, double y)
        {
            double Dx = x - xCarCoordinate;
            double Dy = y - yCarCoordinate;
            double res = Math.Sqrt((Dx * Dx + Dy * Dy));
            return res;
        }

        public void BrakingCar(int minRad, double carSpeed)
        {

            if (currentCarSpeed > carSpeed - 1)//&& currentCarSpeed > carSpeed - 0.1 //minRad < 150 &&
                currentCarSpeed -= currentCarSpeed / 10;
            /*

                            else if(currentCarSpeed < carSpeed - 1)
                              currentCarSpeed = carSpeed - 1;*/
        }

        /// <summary>
        /// экстренное торможение
        /// </summary>
        public void BrakingCar()
        {
            currentCarSpeed -= currentCarSpeed / 10;
        }
        public void BoostCar()
        {
            if (maximumAllowedSpeed > CurrentCarSpeed())
            {
                currentCarSpeed += (carDesiredSpeed / 10.0 - currentCarSpeed) / 30;
            }
            if(currentCarSpeed * 10.0 > maximumAllowedSpeed)
            {
                currentCarSpeed = maximumAllowedSpeed / 10;
            }
        } 
    }
}
