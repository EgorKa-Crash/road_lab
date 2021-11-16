using Road_Lap1.Configuration;
using Road_Lap1.Configuration.Roads;
using Road_Lap1.Roads;
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

        private EventWaitHandle _flowEventWait = new AutoResetEvent(false);
        private EventWaitHandle _semaphoreEventWait = new AutoResetEvent(false);
        private bool _eventFlag = false;

        private Task _flowTask;
        private Task _semaphoreTask;

        private bool addLimitFlag = false;

        private readonly double _overtakingBlockingRadius = 200;
        public int countPassingRoads { get; set; }  //количество попутных дорог
        public int countOppositeRoads { get; set; } //количество противоположных дорог 

        List<Car> cars = new List<Car>(); 

        RoadBase road;
          
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
            crossImage = Properties.Resources.Cross;
           
            InitializeComponent();
            _settings = settings;
            countPassingRoads = _settings.Traffic.CountPasssingLine;
            countOppositeRoads = _settings.Traffic.CountOppositeLine ;
            _configurationForm = form;
            RoadGenerator();
            addLimitFlag = true;
            speedLimitLabel.Text = "" + speedLimitTB.Value * 10;
        }
    
        /// <summary>
        /// обработка нажатия кнопки старт, проверка не продолжить ли
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void startButton_Click(object sender, EventArgs e)
        {
            roadMarkPanel.Visible = false;
            if (_eventFlag)
            {
                _eventFlag = false;
            }

            addLimitFlag = false;

            if (_settings.RoadType == RoadType.Tunnel)
            {
                StartSemaphoreSimulation();
            }

            CarGenerator();
            StartFlowSimulation();
        }

        private void StartFlowSimulation()
        {
            if (_flowTask == null)
            {
                _flowTask = new Task(Tick2);
                _flowTask.Start();
            }
            else
            {
                _eventFlag = false;
                _flowEventWait.Set();
            }
        }

        private void StartSemaphoreSimulation()
        {
            _eventFlag = false;
            if (_semaphoreTask == null)
            {
                _semaphoreTask = new Task(SemaphoreWorcs);
                _semaphoreTask.Start();
            }
            else
            {
                _semaphoreEventWait.Set();
            }
        }

        private void PauseButton_Click(object sender, EventArgs e)
        {
            _eventFlag = true;
        }

        private void ResumeButton_Click(object sender, EventArgs e)
        {
            _eventFlag = true;
            _configurationForm.Show();
            Dispose();
        }

  
        private void RoadGenerator()
        {
            Point[] wey = new Point[] { new Point(-300, 600), new Point(0, 400), new Point(300, 400), new Point(600, 0), new Point(900, 500), new Point(1200, 600), new Point(1400, 900), new Point(1500, 1200) }; // хорошая карта, рекомендую , выпуклая вверх
             
            int[] RM = MarkingGenerator();

            speedLimitTB.Maximum = _settings.SpeedLimit.Max / 10;
            speedLimitTB.Minimum = _settings.SpeedLimit.Min / 10;
            dynamicSpeed.Maximum = _settings.SpeedLimit.Max;
            dynamicSpeed.Minimum = 0;
            pb_CarSpeed.Maximum = _settings.SpeedLimit.Max;
            pb_CarSpeed.Minimum = 0;
             

            if ( _settings.RoadType == RoadType.Tunnel)
            { 
                road = new Tunnel(wey, 15, 25, _settings); // обозначены начало и конец тонеля, возможно потом можно вывести для динамической настройки карты
            }
            else if (_settings.RoadType == RoadType.Higway)
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
            Task.Run(() =>
            { 
                 
                while (!_eventFlag)
                {
                    if (cars.Count < 150)
                    {
                        int numRoad = rnd.Next(0, countPassingRoads + countOppositeRoads);
                        lock (carLocker)
                        {
                            var raddSpeed = _settings.CarSpeedIntensity.NextValue();

                            cars.Add(new Car(0, 0, numRoad, (int)raddSpeed, (double)this.road.roads[numRoad].roadPoints[0].x, (double)this.road.roads[numRoad].roadPoints[0].y, raddSpeed / 10, 1, Color.FromArgb(rnd.Next(200), rnd.Next(150), rnd.Next(150))));

                        }
                        Thread.Sleep((int)_settings.FlowIntensity.NextValue());
                    }
                     
                }
            }); 
        }

        private Car currentCar;
        /// <summary>
        /// циклы для расчета, что делать каждой из машин за 1 тик программы
        /// </summary>
        private void Tick2()
        {
            while (true)
            {
                _flowEventWait.WaitOneEx(_eventFlag);

                lock (carLocker)
                {
                    CarMovementCalculations.carMovement(cars, road,countOppositeRoads,_overtakingBlockingRadius, _settings.SpeedLimit.Max);
                } 
                if (trackPictureBox.InvokeRequired)
                {
                    trackPictureBox?.Invoke(new Action(() => RoadDrawing()));

                    if (currentCar != null)
                    {
                        Invoke((MethodInvoker)delegate
                        {
                            selCarLable.Text = dynamicSpeed.Value.ToString();
                            currentCar.carDesiredSpeed = dynamicSpeed.Value;
                            pb_CarSpeed.Value = (int)(currentCar.currentCarSpeed * 10.0);
                        });
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
        Image crossImage ;
        private void DrawSigns(Graphics grf)
        { 
            foreach (SignLine signline in road.roadSign)
            {
                for (int j = 1; j < signline.signPoints.Count - 1; j++)
                {
                    if(signline.signPoints[j + 1].Signal != TrafficSignalType.Nothing)
                    {
                        Image currentImage = limitImage;
                        TrafficSignalType T = signline.signPoints[j + 1].Signal;
                        switch (T)
                        {
                            case TrafficSignalType.Limit:
                                { 
                                    break;
                                }
                            case TrafficSignalType.NoLimit:
                                {
                                    currentImage = noLimitImage;
                                    break;
                                }
                            case TrafficSignalType.GreenSemaphore:
                                {
                                    currentImage = greenSemaphoreImage;
                                    break;
                                }
                            case TrafficSignalType.RedSemaphore:
                                {
                                    currentImage = redSemaphoreImage;
                                    break;
                                }
                            case TrafficSignalType.Highway:
                                {
                                    currentImage = highwayImage;
                                    break;
                                }
                            case TrafficSignalType.CarRoad:
                                {
                                    currentImage = carRoadImage;
                                    break;
                                }
                            case TrafficSignalType.Tunnel:
                                {
                                    currentImage = tunnelImage;
                                    break;
                                }
                        }

                        grf.DrawImage(currentImage, new Rectangle(signline.signPoints[j].Point.x - 10, signline.signPoints[j].Point.y - 12, 30, 30));

                        if (signline.signPoints[j + 1].Signal == TrafficSignalType.Limit)
                        {

                            grf.DrawString(signline.signPoints[j + 1].Point.maximumAllowedSpeed.ToString(),
                                           font,
                                           new SolidBrush(Color.Black),
                                           new PointF(signline.signPoints[j].Point.x - 8, signline.signPoints[j].Point.y - 5));
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

       
        private void TrackPictureBox_MouseClick(object sender, MouseEventArgs e)
        {
            if (addLimitFlag) 
            {
                if(!IsCorrectPlaceToLimitSign(currentLimLine.signPoints[currentLimNum].Signal))
                {
                    return;
                }

                int lim  = 0;
                int oldLim  = 0; 
                if (setLimitRB.Checked)
                {
                    currentLimLine.signPoints[currentLimNum].Signal = TrafficSignalType.Limit; // указание типа знака   
                      lim = speedLimitTB.Value * 10; 
                      oldLim = currentLimLine.signPoints[currentLimNum].Point.maximumAllowedSpeed; 
                }
                else if (delLimRB.Checked)
                { 
                    currentLimLine.signPoints[currentLimNum].Signal = TrafficSignalType.Nothing;
                      oldLim = currentLimLine.signPoints[currentLimNum].Point.maximumAllowedSpeed;
                      lim = currentLimLine.signPoints[currentLimNum-1].Point.maximumAllowedSpeed; 
                }
                else if (notLimRB.Checked)
                { 
                    currentLimLine.signPoints[currentLimNum].Signal = TrafficSignalType.NoLimit;
                      oldLim = currentLimLine.signPoints[currentLimNum].Point.maximumAllowedSpeed;
                      lim = road.MAX_SPEED; 
                }
                LimLineEditor(oldLim, lim);

                RoadDrawing();

                trackPictureBox.Image = btm;

            }
            else
            {
                /*if (_settings.RoadType != RoadType.Tunnel)
                {
                    return;
                }*/

                int x = e.Location.X;
                int y = e.Location.Y;
                double minRad = 50;
                for (var i = 0; i < cars.Count; i++)
                {
                    double rad = cars[i].Radius(x, y);
                    if (minRad > rad)
                    {
                        minRad = rad;
                        currentCar = cars[i];
                        if (currentCar.carDesiredSpeed > road.MAX_SPEED) 
                        {
                            currentCar.carDesiredSpeed = road.MAX_SPEED; 
                        }
                        selectedCarPanel.Visible = true;
                        dynamicSpeed.Value = currentCar.carDesiredSpeed;

                    }
                    else if(minRad == 50)
                    selectedCarPanel.Visible = false;
                }
            } 
        }

        private bool IsCorrectPlaceToLimitSign(TrafficSignalType sign)
        {
            return sign != TrafficSignalType.CarRoad
                   && sign != TrafficSignalType.Highway
                   && sign != TrafficSignalType.Tunnel
                   && sign != TrafficSignalType.GreenSemaphore
                   && sign != TrafficSignalType.RedSemaphore;
        }

        private void LimLineEditor(int oldLim, int lim)
        {
            for (int i = currentLimNum; i < currentLimLine.signPoints.Count - 1; i++)
            {
                if (currentLimLine.signPoints[i].Point.maximumAllowedSpeed == oldLim && (currentLimLine.signPoints[i].Signal == TrafficSignalType.Nothing || i == currentLimNum))
                    currentLimLine.signPoints[i].Point.maximumAllowedSpeed = lim;
                else
                    break;
            }
        }

       // private bool invokeInProgress = false;
        private /*async*/ void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
          //  if(!invokeInProgress)
            {
                this.CloseAll();
             //   return;
            }

            //e.Cancel = true;

            //await Task.Run(() =>
            //{
            //    while (invokeInProgress)
            //    { }
            //});

            //this.CloseAll();
        }
         


        
        private SignLine currentLimLine;
        private int currentLimNum;

        private void TrackPictureBox_MouseMove(object sender, MouseEventArgs e)
        {
            if (!addLimitFlag)
            {
                return;
            }

            Graphics grf = Graphics.FromImage(btm);
            grf.Clear(Color.Transparent);

            DrawMarkup(grf);
            DrawSigns(grf);
            DrawCars(grf);
            GetSignCoordinates(e, out int x, out int y);
            DrawEditableSign(x, y, grf);

            trackPictureBox.Image = btm;
        }

        private void GetSignCoordinates(MouseEventArgs e, out int x, out int y)
        {
            x = e.Location.X;
            y = e.Location.Y;
            double minRad = 100000;
            foreach (SignLine signline in road.roadSign)
            {
                int num = 0;
                foreach (var p in signline.signPoints)
                {
                    num++;
                    int dX = e.Location.X - p.Point.x;
                    int dY = e.Location.Y - p.Point.y;
                    double rad = Math.Sqrt(dX * dX + dY * dY);
                    if (minRad > rad)
                    {
                        minRad = rad;
                        x = p.Point.x;
                        y = p.Point.y;
                        currentLimLine = signline;
                        currentLimNum = num;
                    }
                }
            }
        }

        private void DrawEditableSign(int x, int y, Graphics grf)
        {
            Image signImage = null;
            if (notLimRB.Checked)
            {
                signImage = noLimitImage;
                grf.DrawImage(signImage, new Rectangle(x - 10, y - 12, 30, 30));
            }
            else if (setLimitRB.Checked)
            {
                signImage = limitImage;
                grf.DrawImage(signImage, new Rectangle(x - 10, y - 12, 30, 30));
                grf.DrawString((speedLimitTB.Value * 10).ToString(),
                               font,
                               new SolidBrush(Color.Black),
                               new PointF(x - 8, y - 5));
            }
            else if(delLimRB.Checked)
            {
                signImage = crossImage;
                grf.DrawImage(signImage, new Rectangle(x - 10, y - 12, 30, 30));
               /* SolidBrush brush = new SolidBrush(Color.Red);
                grf.FillEllipse(brush, x - 5, y - 7, 20, 20);*/
            }
        }

       
        private void SemaphoreWorcs()
        {
            while (true)
            {
                TurnOtherLight();

                while (CarsCountOnSegment(road.START_SIGN_POINT, road.FIN_SIGN_POINT, 1) != 0)
                {
                    _semaphoreEventWait.WaitOneEx(_eventFlag);
                    Thread.Sleep(100);
                }

                TurnOtherLight();

                while (CarsCountOnSegment(road.FIN_SIGN_POINT, road.START_SIGN_POINT, 0) != 0)
                {
                    _semaphoreEventWait.WaitOneEx(_eventFlag);
                    Thread.Sleep(100);
                }
            }
        }

        private void TurnOtherLight()
        {
            road.setTrafficLight();
            WaitingOnOtherLight(_settings.Semaphore.TimeMilliseconds);
            _semaphoreEventWait.WaitOneEx(_eventFlag);
            road.setTrafficLight();
        }

        private int WaitingOnOtherLight(int timeout)
        {
            var counter = 0;
            while (timeout >= counter)
            {
                _semaphoreEventWait.WaitOneEx(_eventFlag);

                counter += 100;
                Thread.Sleep(100);
            }

            return counter;
        }

        private int CarsCountOnSegment(int SPoint, int LPoint, int NRoad)
        {
            int count = 0;

            for(int i = 0; i < cars.Count; i++)
            {
                if (cars[i].roadNumber == NRoad && cars[i].roadPointNumber < road.roads[NRoad].roadPoints.Count - LPoint && cars[i].roadPointNumber > SPoint)
                    count++;
            }

            return count;
        }

        private void DynamicSpeed_Scroll(object sender, EventArgs e)
        {
            currentCar.carDesiredSpeed = dynamicSpeed.Value * 10; 
        }

        private void button2_Click(object sender, EventArgs e)
        {
            System.Diagnostics.Process.Start("C:/Users/Егор/Desktop/Road_Lap2.2/road_lab/calc.html");
            /*string path = Application.StartupPath + @"\info\html\page.html";
            webBrowser1.Navigate(path);*/
        }

       

        private void radioButton1_MouseClick(object sender, MouseEventArgs e)
        {
            setLimitRB.BackColor = Color.Blue;
            delLimRB.BackColor = Color.White;
            notLimRB.BackColor = Color.White;

        }

        private void radioButton2_MouseClick(object sender, MouseEventArgs e)
        {
            delLimRB.BackColor = Color.Blue;
            setLimitRB.BackColor = Color.White;
            notLimRB.BackColor = Color.White;
        }

        private void radioButton3_MouseClick(object sender, MouseEventArgs e)
        {
            notLimRB.BackColor = Color.Blue;
            setLimitRB.BackColor = Color.White;
            delLimRB.BackColor = Color.White;
        }

        private void trackBar1_Scroll(object sender, EventArgs e)
        {
            speedLimitLabel.Text = (speedLimitTB.Value * 10).ToString();
        }

        private void speedLimitLabel_MouseClick(object sender, MouseEventArgs e)
        {
            setLimitRB.Checked = true;
            setLimitRB.BackColor = Color.Blue;
            delLimRB.BackColor = Color.White;
            notLimRB.BackColor = Color.White;
        }

        private void setLimitButton_Click(object sender, EventArgs e)
        {
            _eventFlag = true;
            addLimitFlag = true;
            roadMarkPanel.Visible = true;
        }
    }
}
