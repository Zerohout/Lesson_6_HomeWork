using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sepo
{
    public class SetLabel
        // Отрисовка меню
    {
        private int selectedTask;
        public void Label(string label) // Заголовок меню
        {
            Console.SetCursorPosition(5, Console.CursorTop + 2);
            Console.WriteLine($"{label}:");
        }

        public void AddPoint(int numTask, string nameTask) // Пункт меню
        {
            Console.SetCursorPosition(5, Console.CursorTop + 1);
            Console.WriteLine($"{numTask}) {nameTask}.");
        }

        public int UserSelTask() // Выбор пользователя
        {
            try
            {
                selectedTask = int.Parse(Console.ReadLine());
            }
            catch
            {
                selectedTask = -1;
            }
            return selectedTask;
        }
    }

    public static class Exit // Выход
    {
        public static int ExitTask() // Выход из задания
        {
            var sl = new SetLabel();

            while (true) // Цикл выбора после завершения задания
            {
                int i;
                sl.Label("Выберите необходимое действие");
                sl.AddPoint(1, "Повторить задание");
                sl.AddPoint(2, "Завершить задание");
                sl.AddPoint(3, "Выход в главное меню");
                try
                {
                    i = (int.Parse(Console.ReadLine()));
                }
                catch
                {
                    i = 0;
                }

                if (i > 0 && i < 4)
                {
                    return i;
                }
            }
        }

        public static void ExitProgram()
        // Выход из программы с сюрпризом (пасхалкой)
        {
            Console.Clear();
            Console.SetCursorPosition(Console.WindowWidth / 2 - 14, Console.WindowHeight / 2);
            Console.Write("Для Вас старался ");
            Console.ForegroundColor = ConsoleColor.Cyan;
            Console.WriteLine("Фарит Ахмеров.\n");
            Console.ResetColor();
            Console.SetCursorPosition(Console.WindowWidth / 2 - 12, Console.WindowHeight / 2 + 1);
            Console.WriteLine("Для выхода нажмите 'Enter'.");

            do
            {
                var cki = Console.ReadKey();
                if (cki.Key != ConsoleKey.Enter)
                {
                    var rnd = new Random();
                    var colors = (ConsoleColor[])Enum.GetValues(typeof(ConsoleColor));
                    do
                    {
                        Console.SetCursorPosition(rnd.Next(1, Console.WindowWidth - 2), rnd.Next(1, Console.WindowHeight - 1));

                    } while ((Console.CursorLeft > Console.WindowWidth / 2 - 16 &&
                              Console.CursorLeft < Console.WindowWidth / 2 + 18) &&
                             (Console.CursorTop >= Console.WindowHeight / 2 - 1 &&
                                 Console.CursorTop <= Console.WindowHeight / 2 + 2));

                    Console.ForegroundColor = colors[rnd.Next(0, colors.Length)];
                    Console.BackgroundColor = colors[rnd.Next(0, colors.Length)];
                }
                else
                {
                    break;
                }

            } while (true);
        }
    }

    public static class ColorText // Покраска текста 
    {
        public static void SetColorText(string firstText, ConsoleColor color, string colorText, string secondText)
        // Покраска текста в формате {Текст, Покрашенный текст, Текст}
        {
            Console.Write(firstText);
            Console.ForegroundColor = color;
            Console.Write(colorText);
            Console.ResetColor();
            Console.WriteLine(secondText);
        }
    }

    class Program
    {
        static void Main()
        {
        }
    }
}
