namespace Tasks
{
    using System;
    using System.IO;
    using System.Threading;
    using Sepo;

    public class AllTasks
    {
        static void Main()
        {

        }

        public static bool TaskTumbler(int taskNum)
        {
            var t1 = new Task_1();
            var t2 = new Task_2();
            var t5 = new Task_5();


            switch (taskNum)
            {
                case 1:
                    t1.Task1();
                    break;
                case 2:
                    t2.Task2();
                    break;
                case 5:
                    t5.Save("newData.bin", 10000000);
                    t5.Load("newData.bin");
                    break;
            }

            switch (Exit.ExitTask())
            {
                case 1:
                    return true;
                default:
                    return false;

            }
        }
    }

    #region Задание №1

    public class Task_1
    {
        delegate double Fun(double fNum, double sNum);

        public void Task1()
        {
            while (true)
            {
                var sl = new SetLabel();
                Console.Clear();
                sl.Label("В данном модуле я произведу 2 операции над вашими 2-мя числами");
                sl.AddPoint(1, "Первое число умножу на второе число в квадрате");
                sl.AddPoint(2, "Первое число умножу на синус второго числа");
                sl.InputDescript("Теперь введите через пробел 2 числа");
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

            startTask_1(MyFunc1, MyFunc2, 2, 3);

            void startTask_1(Fun fun1, Fun fun2, double f1, double f2)
            {
                Console.WriteLine("Первое число умноженное на квадрат второго числа: {0,7:0}", fun1(f1, f2));
                Console.WriteLine("Первое число умноженное на синус второго числа: {0,8:0.000}", fun2(f1, f2));
            }

            double MyFunc1(double f1, double f2)
            {
                return f1 * Math.Pow(f2, 2);
            }

            double MyFunc2(double f1, double f2)
            {
                return f1 * Math.Sin(f2);
            }
        }
    }

    #endregion

    #region Задание №2

    public class Task_2
    {
        delegate void SaveFunction(string fileName, double a, double b, double h);

        delegate double Functions(double x, int i);

        double F(double x, int i)
        {
            switch (i)
            {
                case 1:
                    return x * x - 50 * x + 10;
                case 2:
                    return x * Math.Pow(x, 2);
                default:
                    return x * Math.Sin(x);
            }
        }

        double Load(string fileName)
        {
            var fs = new FileStream(fileName, FileMode.Open, FileAccess.Read);
            var bw = new BinaryReader(fs);
            var min = double.MaxValue;

            for (var i = 0; i < fs.Length / sizeof(double); i++)
            {
                var d = bw.ReadDouble();
                if (d < min)
                {
                    min = d;
                }
            }

            bw.Close();
            fs.Close();
            return min;
        }

        private void SaveFunc​(string fileName​, double a​, double b, double h)
        {
            var fs = new FileStream(fileName​, FileMode.Create, FileAccess.Write);
            var bw = new BinaryWriter(fs);
            Functions f = F;
            var x = a​;
            int num = 0;

            while (x <= b)
            {
                bw.Write(f(x, num));
                x += h;
            }
            bw.Close();
            fs.Close();
        }

        public void Task2()
        {

            SaveFunction f = SaveFunc​;
            Functions func = F;

            f("data.bin", func(-100, Tumbler()), 100, 0.5);

            Console.WriteLine(Load("data.bin"));
            Console.ReadKey();
        }

        int Tumbler()
        {
            while (true)
            {
                Console.Clear();
                SetLabel sl = new SetLabel();
                sl.Label("Выберите функцию, минимум которой будет найден (x = -100)");
                sl.AddPoint(1, "x * x - 50 * x + 10");
                sl.AddPoint(2, "x * x^2");
                sl.AddPoint(3, "x * sin(x)");
                sl.InputDescript("Введите пункт");
                int i;

                try
                {
                    i = int.Parse(Console.ReadLine());
                }
                catch
                {
                    continue;
                }

                return i;
            }
        }
    }

    #endregion

    #region Задание №5

    public class Task_5
    {
        private static int max1;
        private static int max2;
        private static int max3;
        private static int max4;

        public void Save(string fileName, int n)
        {
            var rnd = new Random();
            var fs = new FileStream(fileName, FileMode.Create, FileAccess.Write);
            var bw = new BinaryWriter(fs);
            for (var i = 0; i < n; i++)
            {
                bw.Write(rnd.Next(0, n + 1));
            }
            fs.Close();
            bw.Close();
        }

        public void Load(string fileName)
        {
            var d = DateTime.Now;
            var fs = new FileStream(fileName, FileMode.Open, FileAccess.Read);
            var br = new BinaryReader(fs);

            var a = new int[fs.Length / 4];

            for (var i = 0; i < fs.Length / 4; i++)
            {
                a[i] = br.ReadInt32();
            }

            br.Close();
            fs.Close();

            var thread1 = new Thread(Thread1);
            var thread2 = new Thread(Thread2);
            var thread3 = new Thread(Thread3);
            var thread4 = new Thread(Thread4);

            thread1.Start(a);
            thread2.Start(a);
            thread3.Start(a);
            thread4.Start(a);

            int endMax1;
            int endMax2;
            int endMax;
            endMax1 = max1 > max2 ? max1 : max2;
            endMax2 = max3 > max4 ? max3 : max4;
            endMax = endMax1 > endMax2 ? endMax1 : endMax2;

            Console.WriteLine(endMax);
            Console.WriteLine(DateTime.Now - d);
        }

        void Thread1(object b)
        {
            int[] a = (int[])b;
            for (var i = 0; i < a.Length / 4; i++)
            {
                for (var j = 0; j < a.Length / 4; j++)
                {
                    if (Math.Abs(i - j) >= 8 && a[i] * a[j] > max1)
                    {
                        max1 = a[i] * a[j];
                    }
                }
            }
        }

        void Thread2(object b)
        {
            int[] a = (int[])b;
            for (var i = a.Length / 4; i < a.Length / 2; i++)
            {
                for (var j = a.Length / 4; j < a.Length / 2; j++)
                {
                    if (Math.Abs(i - j) >= 8 && a[i] * a[j] > max2)
                    {
                        max2 = a[i] * a[j];
                    }
                }
            }
        }

        void Thread3(object b)
        {
            int[] a = (int[])b;
            for (var i = a.Length / 2; i < a.Length - a.Length / 4; i++)
            {
                for (var j = a.Length / 2; j < a.Length - a.Length / 4; j++)
                {
                    if (Math.Abs(i - j) >= 8 && a[i] * a[j] > max3)
                    {
                        max3 = a[i] * a[j];
                    }
                }
            }
        }

        void Thread4(object b)
        {
            int[] a = (int[])b;
            for (var i = a.Length - a.Length / 4; i < a.Length; i++)
            {
                for (var j = a.Length - a.Length / 4; j < a.Length; j++)
                {
                    if (Math.Abs(i - j) >= 8 && a[i] * a[j] > max4)
                    {
                        max4 = a[i] * a[j];
                    }
                }
            }
        }
    }

    #endregion

}