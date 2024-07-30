using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GaidukovPSBstudyCalculator
{
    internal class AddictionalFunctions //Методы, не отвечающие за функционал программы
    {
        public void WaitForAnyButtonPush()
        {
            Console.WriteLine("\nДля продолжения нажмите любую клавишу... \n ");
            Console.ReadKey();
        }
        public void WaitForEnterButtonPush()
        {
            Console.WriteLine(" ");
            Console.WriteLine("Нажмите Enter...");
            while (Console.ReadKey().Key != ConsoleKey.Enter) { }
            Console.WriteLine(" ");

        }

        public void EnterIncorrectData()
        {
            ConsoleColor defaltColor = Console.ForegroundColor;
            Console.ForegroundColor = ConsoleColor.Red;
            Console.Write("Вы ввели не корректные данные. \nПопробуйте ввести данные повторно:");
            Console.ForegroundColor = defaltColor;
        }
        public void Greeting()
        {
            Console.WriteLine("Добро пожаловать в Калькулятор\n");
            Console.WriteLine("Мой калькулятор может выполнять следующие операции: " +
                              "\nСложение: + " +
                              "\nВычитание: - " +
                              "\nУмножение: * " +
                              "\nДеление: / " +
                              "\nВозведение в степень: ^");
            WaitForEnterButtonPush();
        }
    }
}
