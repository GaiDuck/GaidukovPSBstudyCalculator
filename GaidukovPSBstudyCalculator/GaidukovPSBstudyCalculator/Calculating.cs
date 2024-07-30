using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GaidukovPSBstudyCalculator
{
    internal class Calculating
    {
        AddictionalFunctions add = new AddictionalFunctions();

        public double TempResult { get; private set; }

        public double CalculateAddiction(double FirstNumber, double SecondNumber)
        {
            Console.WriteLine($"Считаем: {FirstNumber} + {SecondNumber}");
            TempResult = FirstNumber + SecondNumber;
            Console.WriteLine($"результат: {TempResult}");
            return TempResult;
        }

        public double CalculateSubtraction(double FirstNumber, double SecondNumber)
        {
            Console.WriteLine($"Считаем: {FirstNumber} - {SecondNumber}");
            TempResult = FirstNumber - SecondNumber;
            Console.WriteLine($"результат: {TempResult}");
            return TempResult;
        }

        public double CalculateMultiplication(double FirstNumber, double SecondNumber)
        {
            Console.WriteLine($"Считаем: {FirstNumber} * {SecondNumber}");
            TempResult = FirstNumber * SecondNumber;
            Console.WriteLine($"результат: {TempResult}");
            return TempResult;
        }

        public double CalculateDivision(double FirstNumber, double SecondNumber)
        {
            Console.WriteLine($"Считаем: {FirstNumber} / {SecondNumber}");
            TempResult = FirstNumber / SecondNumber;
            Console.WriteLine($"результат: {TempResult}");
            return TempResult;
        }

        public double CalculatePower(double FirstNumber, double SecondNumber)
        {
            Console.WriteLine($"Считаем: {FirstNumber} ^ {SecondNumber}");
            TempResult = Math.Pow(FirstNumber, SecondNumber);
            Console.WriteLine($"результат: {TempResult}");
            return TempResult;
        }

        public void Calculate(char MathOperator, double FirstNumber, double SecondNumber)
        {
            switch (MathOperator)
            {
                case '+':
                    CalculateAddiction(FirstNumber, SecondNumber);
                    break;

                case '-':
                    CalculateSubtraction(FirstNumber, SecondNumber);
                    break;

                case '*':
                    CalculateMultiplication(FirstNumber, SecondNumber);
                    break;

                case '/':
                    CalculateDivision(FirstNumber, SecondNumber);
                    break;

                case '^':
                    CalculatePower(FirstNumber, SecondNumber);
                    break;

                default:
                    add.EnterIncorrectData();
                    break;
            }
            add.WaitForEnterButtonPush();
        }
    }
}
