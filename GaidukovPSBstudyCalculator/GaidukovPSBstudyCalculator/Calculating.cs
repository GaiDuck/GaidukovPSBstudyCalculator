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

        double CalculateAddiction(double FirstNumber, double SecondNumber)
        {
            TempResult = FirstNumber + SecondNumber;
            return TempResult;
        }

        double CalculateSubtraction(double FirstNumber, double SecondNumber)
        {
            TempResult = FirstNumber - SecondNumber;
            return TempResult;
        }

        double CalculateMultiplication(double FirstNumber, double SecondNumber)
        {
            TempResult = FirstNumber * SecondNumber;
            return TempResult;
        }

        double CalculateDivision(double FirstNumber, double SecondNumber)
        {
            TempResult = FirstNumber / SecondNumber;
            return TempResult;
        }

        double CalculatePower(double FirstNumber, double SecondNumber)
        {
            TempResult = Math.Pow(FirstNumber, SecondNumber);
            return TempResult;
        }

        void PublicLogs(double FirstNumber, double SecondNumber, char MathOperator, double TempResult)
        {
            Console.WriteLine($"{FirstNumber} {MathOperator} {SecondNumber} = {TempResult}");
        }

        public void Calculate(char MathOperator, double FirstNumber, double SecondNumber)
        {
            switch (MathOperator)
            {
                case '+':
                    PublicLogs(FirstNumber, SecondNumber, MathOperator, 
                        CalculateAddiction(FirstNumber, SecondNumber));
                    break;

                case '-':
                    PublicLogs(FirstNumber, SecondNumber, MathOperator, 
                        CalculateSubtraction(FirstNumber, SecondNumber));
                    break;

                case '*':
                    PublicLogs(FirstNumber, SecondNumber, MathOperator, 
                        CalculateMultiplication(FirstNumber, SecondNumber));
                    break;

                case '/':
                    PublicLogs(FirstNumber, SecondNumber, MathOperator, 
                        CalculateDivision(FirstNumber, SecondNumber));
                    break;

                case '^':
                    PublicLogs(FirstNumber, SecondNumber, MathOperator, 
                        CalculatePower(FirstNumber, SecondNumber));
                    break;

                default:
                    add.EnterIncorrectData();
                    break;
            }
            //add.WaitForEnterButtonPush();
        }
    }
}
