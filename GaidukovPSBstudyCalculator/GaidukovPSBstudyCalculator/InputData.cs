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

        bool parsed;
        bool mathOperatorFound;
        char[] mathOperators = { '+', '-', '*', '/', '^' };

        double GetNumber()
        {
            do
            {
                parsed = double.TryParse(Console.ReadLine(), out var input);

                if (parsed)
                    return input;
                else
                    add.EnterIncorrectData();
            }
            while (!parsed);

            return 0;
        }

        public void GetFirstNumber()
        {
            Console.Write("Введите первое число: ");
            FirstNumber = GetNumber();
        }

        public void GetSecondNumber()
        {
            Console.Write("Введите второе число: ");
            do
            {
                SecondNumber = GetNumber();
            }
            while (!DataTesting(MathOperator, SecondNumber));
        }

        public void GetMathOperator()
        {
            Console.Write("Введите символ операции: ");

            mathOperatorFound = false;

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

        bool DataTesting(char mathOperator, double number)
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
