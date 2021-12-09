using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Road_Lap1.Extensions
{
    public static class FormExtensions
    {
        public static void CloseAll(this Form form)
        {
            Container<CancellationTokenSource>.Instance.First()?.Cancel();
            foreach (var item in Container<Form>.Instance)
            {
                item.Dispose();
            }
        }

        public static void ShowSystemInfo(this Form form)
        {
            var text = "\nИнформация о разработчиках \n\n\nЛабораторный практикум по дисциплине:\n \"Технологии программирования\"\n" +
                "\t       Тема: \n\"Система моделирования движения\n транспорта в тоннеле и на автостраде\"\n" +
                "\nРазработчики:\n" +
                " Студенты группы 6404-090301D:\n" +
                " Беседин Александр Денисович\n" +
                " Калеев Егор Дмитриевич\n" +
                "\nРуководитель:\n" +
                " Зеленко Лариса Сергеевна\n" +
                " \tСамарский университет 2021";

            MessageBox.Show(text, "Info",  MessageBoxButtons.OK, MessageBoxIcon.Information);
        }
    }
}
