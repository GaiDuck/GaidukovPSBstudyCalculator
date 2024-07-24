using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GaidukovPSBstudyCalculator
{
    internal class Calculating
    {
        public double CalculateAddiction(double FirstNumber, double SecondNumber)
        {
            Console.WriteLine($"Считаем: {FirstNumber} + {SecondNumber}");
            double result = FirstNumber + SecondNumber;
            Console.WriteLine($"результат: {result}");
            return result;
        }

        public double CalculateSubtraction(double FirstNumber, double SecondNumber)
        {
            Console.WriteLine($"Считаем: {FirstNumber} - {SecondNumber}");
            double result = FirstNumber - SecondNumber;
            Console.WriteLine($"результат: {result}");
            return result;
        }

        public double CalculateMultiplication(double FirstNumber, double SecondNumber)
        {
            Console.WriteLine($"Считаем: {FirstNumber} * {SecondNumber}");
            double result = FirstNumber * SecondNumber;
            Console.WriteLine($"результат: {result}");
            return result;
        }

        public double CalculateDivision(double FirstNumber, double SecondNumber)
        {
            Console.WriteLine($"Считаем: {FirstNumber} / {SecondNumber}");
            double result = FirstNumber / SecondNumber;
            Console.WriteLine($"результат: {result}");
            return result;
        }

        public double CalculatePower(double FirstNumber, double SecondNumber)
        {
            Console.WriteLine($"Считаем: {FirstNumber} ^ {SecondNumber}");
            double result = Math.Pow(FirstNumber, SecondNumber);
            Console.WriteLine($"результат: {result}");
            return result;
        }
    }
}
