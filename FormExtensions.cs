using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Road_Lap1
{
    public static class FormExtensions
    {
        public static void CloseAll(this Form form)
        {
            foreach (var item in Container<Form>.Instance)
            {
                item.Dispose();
            }
        }
    }
}
