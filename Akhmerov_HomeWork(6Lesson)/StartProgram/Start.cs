using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Sepo;

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
            }
        }

        static bool Tumbler()
        {
            Console.Clear();
            var st = new SetLabel();
            st.Label("Выберите действие");
            st.AddPoint(0,"Выход из программы");
            st.AddPoint(1,"Задание №1");
            var sel = st.UserSelTask();
            switch (sel)
            {
                    case 0:
                        Exit.ExitProgram();
                        return false;
                    case 1:

                        return true;
                    default:
                        return true;
            }
        }
    }
}
