using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Sepo;
using Tasks;
//using AllTasks = AllTasks.AllTasks;

namespace StartProgram
{
    class Start
    {
        static void Main()
        {
            while (true)
            {
                if (!Tumbler())
                {
                    break;
                }
                Exit.ExitProgram();
            }
        }

        static bool Tumbler()
        {
            Console.Clear();
            var st = new SetLabel();
            st.Label("Выберите действие");
            st.AddPoint(0,"Выход из программы");
            st.AddPoint(1,"Задание №1");
            st.AddPoint(2,"Задание №2");
            st.AddPoint(5,"Сложное задание №5");
            var sel = st.UserSelTask();

            if (sel == 0)
            {
                return false;
            }
            while (true)
            {
                return AllTasks.TaskTumbler(sel);
            }
        }
    }
}
