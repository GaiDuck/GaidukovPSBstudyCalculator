using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GaidukovPSBstudyCalculator
{
    internal class InputData 
    {
        AddictionalFunctions add = new AddictionalFunctions();

        public double FirstNumber { get; private set; }
        public double SecondNumber { get; private set; }
        public char MathOperator { get; private set; }

        char[] mathOperators = { '+', '-', '*', '/', '^' };

        static string input = "22 + 22";
        string[] output = input.Split(' ');

        List<double> numbers = new List<double>();
        List<char> operators = new List<char>();

        //калькулятор с вводом по действиям

        double GetNumber()
        {
            bool parsed;

            do
            {
                parsed = double.TryParse(Console.ReadLine(), out var input);

                if (parsed)
                    return input;
                else
                    add.EnterIncorrectData();
            }
            while (!parsed); //будет запрашивать ввод числа пока пользователь не введет корректное значение

            return 0;
        }

        void GetFirstNumber()
        {
            Console.Write("Введите первое число: ");
            FirstNumber = GetNumber();
        }

        void GetSecondNumber()
        {
            Console.Write("Введите второе число: ");
            do
            {
                SecondNumber = GetNumber();
            }
            while (!Validation(MathOperator, SecondNumber));
        }

        void GetMathOperator()
        {
            Console.Write("Введите символ операции: ");

            bool mathOperatorFound = false;
            bool parsed;

            do
            {
                parsed = char.TryParse(Console.ReadLine(), out var input);

                if (parsed)
                {
                    foreach (char m in mathOperators)
                        if (m == input)
                        {
                            MathOperator = input;
                            mathOperatorFound = true;
                            break;
                        }
                }

                if (!mathOperatorFound || !parsed)
                    add.EnterIncorrectData();
            }
            while (!mathOperatorFound);
        }

        public void GetDataV1()
        {
            GetFirstNumber();
            GetMathOperator();
            GetSecondNumber();
        }

        //калькулятор с вводом строкой

        void StringInput()
        {
            Console.Write("Введите математическое выражение одной строкой, разделяя все числа и математические операции " +
                          "пробелами. Используйте запятую для записи чисел с дробной частью.");
            input = Console.ReadLine();

            if (input == null)
                Console.WriteLine("0");
        }

        void CompliteLists()
        {
            char tempMathOper;

            foreach (string simbol in output)
            {
                bool parced = double.TryParse(simbol, out var result);
                if (parced)
                    numbers.Add(result);
                else
                {
                    tempMathOper = Convert.ToChar(simbol);
                    operators.Add(tempMathOper);
                }
            }
        }

        void SetNumbersByMathoperator(int MathOperatorNumber)
        {
            FirstNumber = numbers[MathOperatorNumber];
            SecondNumber = numbers[MathOperatorNumber + 1];
            MathOperator = operators[MathOperatorNumber];
        }

        //общие методы

        bool Validation(char mathOperator, double number)
        {
            if (mathOperator == '/' && number == 0)
            {
                add.EnterIncorrectData();
                return false;
            }
            else
                return true;
        }
    }
}
