using Road_Lap1.Configuration;
using Road_Lap1.Configuration.Roads;
using Road_Lap1.Roads.CarFold;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;


namespace Road_Lap1
{
    public partial class RoadWindow : Form
    {
        private Form _configurationForm;
        private SystemSettings _settings;

        private readonly double _overtakingBlockingRadius = 200;
        public int countPassingRoads { get; set; }  //количество попутных дорог
        public int countOppositeRoads { get; set; } //количество противоположных дорог 
        private bool workingStatus { get; set; } // 0 - пауза, 1 - работа
         
        List<Car> cars = new List<Car>(); 

        IRoad road;
          
        object carLocker = new object();

         

        /// <summary>
        /// инициализация форм настроек и основной формы
        /// </summary>
        /// <param name="confForm"></param>
        /// <param name="systemConfig"></param>
        public RoadWindow(Form form, SystemSettings settings)
        {
            noLimitImage = Properties.Resources.NoLimit;
            limitImage = Properties.Resources.Limit;
            greenSemaphoreImage = Properties.Resources.GreenSemaphore;
            redSemaphoreImage = Properties.Resources.RedSemaphore;
            carRoadImage = Properties.Resources.CarRoad;
            highwayImage = Properties.Resources.Highway;
            tunnelImage = Properties.Resources.Tunnel;

            InitializeComponent();
            _settings = settings;
            countPassingRoads = _settings.Traffic.GetCountLine(Direction.OneWay);
            countOppositeRoads = _settings.Traffic.GetCountLine(Direction.TwoWay);
            _configurationForm = form;
            RoadGenerator();
            addLimitFlag = true;
            speedLimitLabel.Text = "" + speedLimitTrackBar.Value * 10;
        }
    
        private bool stopStatus = false;

        /// <summary>
        /// обработка нажатия кнопки старт, проверка не продолжить ли
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void startButton_Click(object sender, EventArgs e)
        {
            addLimitFlag = false;
            if (!workingStatus && !stopStatus)
            {
                workingStatus = true;
                //roadGenerator();
                CarGenerator();
                Tick();
            }
            else if (stopStatus && !addLimitFlag)
            {
                stopStatus = false;
                workingStatus = true;
                CarGenerator();
                //roadDrawing();
                Tick();
            } 
        }
         


        private void RoadGenerator()
        {
            /*  int screenWidth = trackPictureBox.Width;
              int screenHeight = trackPictureBox.Height;*/
             
            //Point[] wey = new Point[] { new Point(400, -400), new Point(400, 50), new Point(350, 200), new Point(300, 450), new Point(350, 900) ,new Point(350, 1300) };

            //Point[] wey = new Point[] { new Point(150, -10), new Point(150, 10), new Point(350, 150), new Point(300, 450), new Point(100, 900), new Point(100, 1000) };

            //Point[] wey = new Point[] { new Point(-10, -10), new Point(100, 100), new Point(280, 150), new Point(400, 300), new Point(450, 500), new Point(350, 900), new Point(350, 1000) };

            //Point[] wey = new Point[] { new Point(-200, -400), new Point(50, 0), new Point(100, 300), new Point(200, 650), new Point(300, 800), new Point(400, 500), new Point(450, 250), new Point(900, 50), new Point(1000, 0) };

            //Point[] wey = new Point[] { new Point(0, 1000), new Point(100, 350), new Point(200, 200), new Point(600, 500), new Point(600, 800), new Point(500, 1200)};

           // Point[] wey = new Point[] { new Point(0, 1000), new Point(150, 200), new Point(400, 120), new Point(500, 100), new Point(700, 250), new Point(800, 600), new Point(1000, 700), new Point(1100, 650), new Point(1300, 600) }; // лежачий вопросительный знак

            Point[] wey = new Point[] { new Point(-300, 600), new Point(0, 400), new Point(300, 400), new Point(600, 0), new Point(900, 500), new Point(1200, 600), new Point(1400, 900), new Point(1500, 1200) }; // хорошая карта, рекомендую , выпуклая вверх
             
            int[] RM = MarkingGenerator();

            speedLimitTrackBar.Maximum = _settings.SpeedLimit.Max / 10;
            speedLimitTrackBar.Minimum = _settings.SpeedLimit.Min / 10;
            dynamicSpeed.Maximum = _settings.SpeedLimit.Max;
            dynamicSpeed.Minimum = 0;

            if ( _settings.TypeRoad == TypeRoad.Tunnel)
            { 
                road = new Tunnel(wey, 15, 25); // обозначены начало и конец тонеля, возможно потом можно вывести для динамической настройки карты
            }
            else if (_settings.TypeRoad == TypeRoad.Higway)
            {
                road = new Highway(wey, RM, 1, _settings);
            }
            else
            { 
                road = new Highway(wey, RM, 1, _settings);             
            } 
        }


        /// <summary>
        /// генерация типов разметки в соответствии с 
        /// </summary>
        /// <returns></returns>
        private int[] MarkingGenerator()
        {
            List<int> RM1 = new List<int>();
            RM1.Add(2);
            for (int i = 0; i < countOppositeRoads - 1; i++)
            {
                RM1.Add(3);
            }
            if (countOppositeRoads > 0)
                RM1.Add(1);
            for (int i = 0; i < countPassingRoads - 1; i++)
            {
                RM1.Add(3);
            }
            RM1.Add(2);

            return RM1.ToArray();
        }
         

        Random rnd = new Random();
        //List<double> _list = new List<double>();
        /// <summary>
        /// великолепне место, асинхронная генерация машин, позволяет задавать частоту и вид распределения появления машин
        /// </summary>
        private void CarGenerator()
        {
            var t1 = Task.Run((Action)(() =>
            { 
                while (workingStatus)
                {
                    int numRoad = rnd.Next(0, countPassingRoads + countOppositeRoads); 
                    lock (carLocker)
                    { 
                        var raddSpeed = _settings.CarSpeedIntensity.NextValue();

                        cars.Add(new Car(0, 0, numRoad, (int)raddSpeed, (double)this.road.roads[numRoad].roadPoints[0].x, (double)this.road.roads[numRoad].roadPoints[0].y, raddSpeed / 10, 1, Color.FromArgb(rnd.Next(200), rnd.Next(256), rnd.Next(256))) );

                    }
                    Thread.Sleep((int)_settings.FlowIntensity.NextValue()); 
                }
            })); 
        }

        private void Tick()
        {

            Thread tr = new Thread(Tick2);
            tr.Start(); 
        } 

        private Car currentCar;
        /// <summary>
        /// циклы для расчета, что делать каждой из машин за 1 тик программы
        /// </summary>
        private void Tick2()
        {
            while (workingStatus)
            { 
                lock (carLocker)
                {
                    CarMovementCalculations.carMovement( cars , road,countOppositeRoads,_overtakingBlockingRadius, _settings.SpeedLimit.Max);
                } 
                if (trackPictureBox.InvokeRequired)
                {
                    if (stopInvoking != true)
                    {
                        invokeInProgress = true;

                        trackPictureBox.Invoke(new Action(() => { RoadDrawing();  }));//roadDrawing(); 

                        invokeInProgress = false;
                         
                        if (currentCar != null)
                        {
                            Invoke((MethodInvoker)delegate
                            {
                                selCarLable.Text = dynamicSpeed.Value.ToString();
                                currentCar.carDesiredSpeed = dynamicSpeed.Value;
                            }); 
                        }
                    } 
                } 
                Thread.Sleep(20); 
            } 
        }
         

        //Bitmap btm = new Bitmap(trackPictureBox.Width, trackPictureBox.Height);
        Bitmap btm = new Bitmap(1423, 880 );//1423; 880
        //Bitmap btm1 = new Bitmap(1423, 880 );//1423; 880

        //RectangleF cloneRect = new RectangleF(0, 0, 1423, 880); 

        Pen pen = new Pen(Color.Red);
        Pen pen2 = new Pen(Color.Red);
        Pen pen3 = new Pen(Color.Red);
        Font font = new Font("Console", 12, FontStyle.Bold);  
        SolidBrush sb = new SolidBrush(Color.Red); 
       /* private void RoadDrawing1() //полученный битмэп можно взять за основу, не просчитывая каждый раз заново дороги
        {

            Graphics grf = Graphics.FromImage(btm1);
            grf.Clear(Color.Transparent);
            DrawMarkup(grf);
            DrawSigns(grf); 

             
        }*/


        private void RoadDrawing() //полученный битмэп можно взять за основу, не просчитывая каждый раз заново дороги
        { 
            //System.Drawing.Imaging.PixelFormat format =  btm.PixelFormat;
            //btm = btm1.Clone(cloneRect, format);
            Graphics grf = Graphics.FromImage(btm);
            grf.Clear(Color.Transparent);

            DrawMarkup(grf); 
            DrawSigns(grf);
            DrawCars(grf);

            trackPictureBox.Image = btm;
        }

        private void DrawCars(Graphics grf)
        {
            lock (carLocker)
            {
                foreach (Car c in cars)
                {
                    if (c.xCarCoordinate > -10 && c.xCarCoordinate < 1450 && c.yCarCoordinate > -10 && c.yCarCoordinate < 900)
                    {
                        if (c == currentCar)
                        {
                            pen2.Color = Color.Red; // = new Pen(Color.Red);
                           // pen3.Color = Color.Red; // = new Pen(Color.Red);
                                                    //pen3 = new Pen(Color.Red);
                        }
                        else
                        {
                            pen2.Color = c.carColor;  // = new Pen(Color.Red);
                            //pen3.Color = Color.Red;
                        }
                        sb.Color = Color.Black;
                        pen2.Width = 18;

                        double cos = c.yCarSpeed / Math.Sqrt(c.xCarSpeed * c.xCarSpeed + c.yCarSpeed * c.yCarSpeed);
                        double sin = c.xCarSpeed / Math.Sqrt(c.xCarSpeed * c.xCarSpeed + c.yCarSpeed * c.yCarSpeed);

                        // grf.DrawImage(RotateImage(carImage, (float)Math.Asin(sin) * 50), new Rectangle((int)c.xCarCoordinate, (int)c.yCarCoordinate, 30, 30));

                        /*Point point1 = new Point(CarMovementCalculations.LineCoord((int)c.xCarCoordinate - 9, (int)c.yCarCoordinate - 18, (int)c.xCarCoordinate, (int)c.yCarCoordinate, cos, sin));
                        Point point2 = new Point(CarMovementCalculations.LineCoord((int)c.xCarCoordinate + 9, (int)c.yCarCoordinate - 18, (int)c.xCarCoordinate, (int)c.yCarCoordinate, cos, sin));
                        Point point4 = new Point(CarMovementCalculations.LineCoord((int)c.xCarCoordinate - 9, (int)c.yCarCoordinate + 18, (int)c.xCarCoordinate, (int)c.yCarCoordinate, cos, sin));
                        Point point3 = new Point(CarMovementCalculations.LineCoord((int)c.xCarCoordinate + 9, (int)c.yCarCoordinate + 18, (int)c.xCarCoordinate, (int)c.yCarCoordinate, cos, sin));

                        grf.DrawLine(pen2, point1.x, point1.y, point2.x, point2.y);
                        grf.DrawLine(pen2, point2.x, point2.y, point3.x, point3.y);
                        grf.DrawLine(pen3, point3.x, point3.y, point4.x, point4.y);
                        grf.DrawLine(pen2, point1.x, point1.y, point4.x, point4.y);*/


                        Point point1 = new Point(CarMovementCalculations.LineCoord((int)c.xCarCoordinate, (int)c.yCarCoordinate + 18, (int)c.xCarCoordinate, (int)c.yCarCoordinate, cos, sin));
                        Point point2 = new Point(CarMovementCalculations.LineCoord((int)c.xCarCoordinate, (int)c.yCarCoordinate - 18, (int)c.xCarCoordinate, (int)c.yCarCoordinate, cos, sin));

                        grf.DrawLine(pen2, point1.x, point1.y, point2.x, point2.y);

                        grf.DrawString(Math.Round(c.currentCarSpeed * 10, 0).ToString(), font, sb, new PointF((float)c.xCarCoordinate - 8, (float)c.yCarCoordinate - 5));
                        sb.Color = Color.White;
                        grf.DrawString(Math.Round(c.currentCarSpeed * 10, 0).ToString(), font, sb, new PointF((float)c.xCarCoordinate - 10, (float)c.yCarCoordinate - 5));
                    }
                }
            }
        }

        private void DrawMarkup(Graphics grf)
        {
            for (int i = 0; i < road.marking.Count(); i++)
            {
                RoadMarking mark = road.marking[i];

                if (road.typesRoadMarking[i] == 3)
                {
                    pen.Color = Color.Gray;
                    pen.Width = 2;
                }


                else if (road.typesRoadMarking[i] == 2)
                {
                    pen.Color = Color.Black;
                    pen.Width = 2;
                }


                else if (road.typesRoadMarking[i] == 1)
                {
                    pen.Color = Color.Black;
                    pen.Width = 6;
                    DrowLine(grf, i, mark);
                    pen.Color = Color.White;
                    pen.Width = 2;
                }

                DrowLine(grf, i, mark);
            }
        }

        private void DrowLine(Graphics grf, int i, RoadMarking mark)
        {
            for (int j = 0; j < mark.markingPoints.Count - 1; j++)
            {
                if (road.typesRoadMarking[i] == 3)
                    grf.DrawLine(pen, mark.markingPoints[j].x, mark.markingPoints[j].y, (mark.markingPoints[j + 1].x + mark.markingPoints[j].x) / 2, (mark.markingPoints[j + 1].y + mark.markingPoints[j].y) / 2);
                else
                    grf.DrawLine(pen, mark.markingPoints[j].x, mark.markingPoints[j].y, mark.markingPoints[j + 1].x, mark.markingPoints[j + 1].y);
            }
        }

        Image noLimitImage; 
        Image limitImage; 
        Image greenSemaphoreImage; 
        Image redSemaphoreImage;
        Image carRoadImage ;
        Image highwayImage;
        Image tunnelImage ;
        private void DrawSigns(Graphics grf)
        { 
            foreach (SignLine signline in road.roadSign)
            {
                for (int j = 1; j < signline.signPoints.Count - 1; j++)
                {
                    if(signline.signPoints[j + 1].en != TrafficSignal.Signals.Nothing)
                    {
                        Image currentImage = limitImage;
                        TrafficSignal.Signals T = signline.signPoints[j + 1].en;
                        switch (T)
                        {
                            case TrafficSignal.Signals.Limit:
                                { 
                                    break;
                                }
                            case TrafficSignal.Signals.NoLimit:
                                {
                                    currentImage = noLimitImage;
                                    break;
                                }
                            case TrafficSignal.Signals.GreenSemaphore:
                                {
                                    currentImage = greenSemaphoreImage;
                                    break;
                                }
                            case TrafficSignal.Signals.RedSemaphore:
                                {
                                    currentImage = redSemaphoreImage;
                                    break;
                                }
                            case TrafficSignal.Signals.Highway:
                                {
                                    currentImage = highwayImage;
                                    break;
                                }
                            case TrafficSignal.Signals.CarRoad:
                                {
                                    currentImage = carRoadImage;
                                    break;
                                }
                            case TrafficSignal.Signals.Tunnel:
                                {
                                    currentImage = tunnelImage;
                                    break;
                                }
                        } 
                            grf.DrawImage(currentImage, new Rectangle(signline.signPoints[j].x - 10, signline.signPoints[j].y - 12, 30, 30));
                        if (signline.signPoints[j + 1].en == TrafficSignal.Signals.Limit)
                        {
                            
                            grf.DrawString(signline.signPoints[j + 1].maximumAllowedSpeed.ToString(),
    font,
    new SolidBrush(Color.Black),
    new PointF(signline.signPoints[j].x - 8, signline.signPoints[j].y - 5));
                        }
                    } 
                }
            }
        }


        public static Image RotateImage(Image img, float rotationAngle)
        {
           // create an empty Bitmap image
            Bitmap bmp = new Bitmap(img.Width, img.Height);

          //  turn the Bitmap into a Graphics object
            Graphics gfx = Graphics.FromImage(bmp);

           // now we set the rotation point to the center of our image
            gfx.TranslateTransform((float)bmp.Width / 2, (float)bmp.Height / 2);

           // now rotate the image
            gfx.RotateTransform(rotationAngle);

            gfx.TranslateTransform(-(float)bmp.Width / 2, -(float)bmp.Height / 2);

           // set the InterpolationMode to HighQualityBicubic so to ensure a high
           // quality image once it is transformed to the specified size
            gfx.InterpolationMode = InterpolationMode.HighQualityBicubic;

          //  now draw our new image onto the graphics object
            gfx.DrawImage(img, new System.Drawing.Point(0, 0));

          //  dispose of our Graphics object
            gfx.Dispose();

           // return the image
            return bmp;
        }

        private void PauseButton_Click(object sender, EventArgs e)
        {
            workingStatus = false;
            stopStatus = true;
        }

        private void ResumeButton_Click(object sender, EventArgs e)
        {
            workingStatus = false;
            _configurationForm.Show();
            Dispose();
        }
          
        private void TrackPictureBox_MouseClick(object sender, MouseEventArgs e)
        {
            if (addLimitFlag) 
            {
                //RoadDrawing1();
                int lim ;
                int oldLim  ; 
                if (addLimRadioButton.Checked)
                {
                    currentLimLine.signPoints[currentLimNum].en = TrafficSignal.Signals.Limit; // указание типа знака   
                      lim = speedLimitTrackBar.Value * 10; 
                      oldLim = currentLimLine.signPoints[currentLimNum].maximumAllowedSpeed; 
                }
                else if (delLimRadioButton.Checked)
                {
                    currentLimLine.signPoints[currentLimNum].en = TrafficSignal.Signals.Nothing;
                      oldLim = currentLimLine.signPoints[currentLimNum].maximumAllowedSpeed;
                      lim = currentLimLine.signPoints[currentLimNum-1].maximumAllowedSpeed; 
                }
                else 
                { 
                    currentLimLine.signPoints[currentLimNum].en = TrafficSignal.Signals.NoLimit;
                      oldLim = currentLimLine.signPoints[currentLimNum].maximumAllowedSpeed;
                      lim = road.MAX_SPEED; 
                }
                LimLineEditor(oldLim, lim);

                RoadDrawing();

                trackPictureBox.Image = btm;

            }
            else
            {
                int x = e.Location.X;
                int y = e.Location.Y;
                double minRad = 100000;
                for (var i = 0; i < cars.Count; i++)
                {
                    double rad = cars[i].Radius(x, y);
                    if (minRad > rad)
                    {
                        minRad = rad;
                        currentCar = cars[i];
                        if (currentCar.carDesiredSpeed > road.MAX_SPEED)
                            currentCar.carDesiredSpeed = road.MAX_SPEED;
                        dynamicSpeed.Value = currentCar.carDesiredSpeed;
                    }
                }
            } 
        }


        private void LimLineEditor(int oldLim, int lim)
        {
            for (int i = currentLimNum; i < currentLimLine.signPoints.Count - 1; i++)
            {
                if (currentLimLine.signPoints[i].maximumAllowedSpeed == oldLim && (currentLimLine.signPoints[i].en == TrafficSignal.Signals.Nothing || i == currentLimNum))
                    currentLimLine.signPoints[i].maximumAllowedSpeed = lim;
                else
                    break;
            }
        }

        private bool invokeInProgress = false;
        private bool stopInvoking = false;
        private async void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (invokeInProgress)
            {
                stopStatus = false;
                workingStatus = false;
                e.Cancel = true; // cancel the original event

                stopInvoking = true; // advise to stop taking new work

                // now wait until current invoke finishes
                await Task.Factory.StartNew(() =>
                {
                    while (invokeInProgress) { }
                });

                // now close the form
                this.CloseAll();
            }
            else
            {
                this.CloseAll();
            }
        }

        private void SpeedLimitTrackBar_Scroll(object sender, EventArgs e)
        {
            speedLimitLabel.Text = ""+speedLimitTrackBar.Value * 10;
        }

        private void AddLimitButton_Click(object sender, EventArgs e)
        {
            stopStatus = true;
            workingStatus = false;
            addLimitFlag = true;

        }
        private bool addLimitFlag = false; 
        private SignLine currentLimLine;
        private int currentLimNum;

        private void TrackPictureBox_MouseMove(object sender, MouseEventArgs e)
        {
            if (addLimitFlag)
            {
                int x = e.Location.X;
                int y = e.Location.Y;

                double minRad = 100000;
                foreach (SignLine signline in road.roadSign)
                {
                    int num = 0;
                    foreach (Point p in signline.signPoints)
                    {
                        num++;
                        int dX = e.Location.X - p.x;
                        int dY = e.Location.Y - p.y;
                        double rad = Math.Sqrt(dX * dX + dY * dY);
                        if (minRad > rad)
                        {
                            minRad = rad;
                            x = p.x;
                            y = p.y;
                            //currentLimPoint = p;
                            currentLimLine = signline;
                            currentLimNum = num;
                        }
                    }
                } 
                
                Graphics grf = Graphics.FromImage(btm);
                grf.Clear(Color.Transparent); 
                  
                DrawMarkup(grf);
                DrawSigns(grf);
                DrawCars(grf); 

                SolidBrush brush = new SolidBrush(Color.Red); 
                grf.FillEllipse(brush, x - 5, y - 7, 20, 20);

                trackPictureBox.Image = btm;
            } 
        }

        private void RoadWindow_Load(object sender, EventArgs e)
        {
            
        }


        private void Button1_Click_1(object sender, EventArgs e)
        {

            //var form = new SemaphoreSettingsForm(this, _settings);
            // form.Show();
            //road.setTrafficLight();
            Thread thr = new Thread(SemaphoreWorcs);
            thr.Start();
        }

        private void SemaphoreWorcs()
        {
            while (workingStatus)
            {
                road.setTrafficLight();
                Thread.Sleep(_settings.Semaphores.Left.TimeMilliseconds);
                road.setTrafficLight();

                while (CarsCountOnSegment(road.START_SIGN_POINT, road.FIN_SIGN_POINT, 1) != 0)
                {
                    Thread.Sleep(100);
                }

                road.setTrafficLight();             
                Thread.Sleep(_settings.Semaphores.Right.TimeMilliseconds); //TimeMillisecondsPassing
                road.setTrafficLight();


                while (CarsCountOnSegment(road.FIN_SIGN_POINT, road.START_SIGN_POINT, 0) != 0)
                {
                    Thread.Sleep(100);
                }

            }
        }

        private int CarsCountOnSegment(int SPoint, int LPoint, int NRoad)
        {
            int count = 0;

            for(int i = 0; i < cars.Count; i++)
            {
                if (cars[i].roadNumber == NRoad && cars[i].roadPointNumber < road.roads[NRoad].roadPoints.Count - LPoint && cars[i].roadPointNumber > SPoint)
                    count++;
            }

/*
            foreach (Car c in cars)
            {
                if (c.roadNumber == NRoad && c.roadPointNumber < road.roads[NRoad].roadPoints.Count - LPoint && c.roadPointNumber > SPoint)
                    count++;
            }*/
            return count;
        }
        private void DynamicSpeed_Scroll(object sender, EventArgs e)
        {
            currentCar.carDesiredSpeed = dynamicSpeed.Value * 10; 

            //currentCar.maximumAllowedSpeed = 1; 
        }

        private void button2_Click(object sender, EventArgs e)
        {
            System.Diagnostics.Process.Start("C:/Users/Егор/Desktop/Road_Lap2.2/road_lab/calc.html");
            /*string path = Application.StartupPath + @"\info\html\page.html";
            webBrowser1.Navigate(path);*/
        }
    }
}
