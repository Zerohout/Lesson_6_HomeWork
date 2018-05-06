using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;
//using Console = System.Console;

namespace Tasks
{
    class Tasks
    {
        static void Main()
        {
            while (true)
            {
                Console.Clear();
                Console.Write(
                    "\n\nВ данном модуле я произведу 2 операции над вашими 2-мя числами:\n\n1) Первое число умножу на второе число в квадрате.\n2) Первое число умножу на синус второго числа\n Теперь введите через пробел 2 числа: ");
                try
                {
                    var ans = Array.ConvertAll(Console.ReadLine().Split(' '), int.Parse);
                    break;
                }
                catch
                {
                    return;
                }
            }

            Task_1.startTask_1(Task_1.MyFunc1, Task_1.MyFunc2, 2, 3);
            Console.ReadLine();
        }
    }

    public class Task_1
    {

        public delegate double Fun(double fNum, double sNum);

        public static void startTask_1(Fun fun1, Fun fun2, double f1, double f2)
        {
            Console.WriteLine("Первое число умноженное на квадрат второго числа: {0,7:0}", fun1(f1, f2));
            Console.WriteLine("Первое число умноженное на синус второго числа: {0,8:0.000}", fun2(f1, f2));
        }

        public static double MyFunc1(double f1, double f2)
        {
            return f1 * Math.Pow(f2, 2);
        }

        public static double MyFunc2(double f1, double f2)
        {
            return f1 * Math.Sin(f2);
        }
    }

}