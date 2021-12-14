using System.ComponentModel;

namespace Road_Lap1.Settings.Roads
{
    public enum RoadType
    {
        [Description("Тоннель")] Tunnel,
        [Description("Автомагистраль")] Higway,
        [Description("Обычная дорога")] Road
    } 
}
