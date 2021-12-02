namespace Road_Lap1.Settings
{
    public class Limit<T>
    {
        public T Min { get; set; }
        public T Max { get; set; }

        public Limit(T min, T max)
        {
            Min = min;
            Max = max;
        }
    }
}
