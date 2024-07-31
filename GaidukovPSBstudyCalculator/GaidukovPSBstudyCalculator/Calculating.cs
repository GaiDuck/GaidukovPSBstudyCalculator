using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GaidukovPSBstudyCalculator
{
    internal class Calculating
    {
        public double TempResult { get; private set; }

        double CalculateAddiction(double firstNumber, double secondNumber)
        {
            TempResult = firstNumber + secondNumber;
            return TempResult;
        }

        double CalculateSubtraction(double firstNumber, double secondNumber)
        {
            TempResult = firstNumber - secondNumber;
            return TempResult;
        }

        double CalculateMultiplication(double firstNumber, double secondNumber)
        {
            TempResult = firstNumber * secondNumber;
            return TempResult;
        }

        double CalculateDivision(double firstNumber, double secondNumber)
        {
            TempResult = firstNumber / secondNumber;
            return TempResult;
        }

        double CalculatePower(double firstNumber, double secondNumber)
        {
            TempResult = Math.Pow(firstNumber, secondNumber);
            return TempResult;
        }

        void PublicLogs(double firstNumber, double secondNumber, char mathOperator, double tempResult)
        {
            Console.WriteLine($"{firstNumber} {mathOperator} {secondNumber} = {tempResult}");
        }

        public void Calculate(char mathOperator, double firstNumber, double secondNumber)
        {
            switch (mathOperator)
            {
                case '+':
                    PublicLogs(firstNumber, secondNumber, mathOperator, 
                        CalculateAddiction(firstNumber, secondNumber));
                    break;

                case '-':
                    PublicLogs(firstNumber, secondNumber, mathOperator, 
                        CalculateSubtraction(firstNumber, secondNumber));
                    break;

                case '*':
                    PublicLogs(firstNumber, secondNumber, mathOperator, 
                        CalculateMultiplication(firstNumber, secondNumber));
                    break;

                case '/':
                    PublicLogs(firstNumber, secondNumber, mathOperator, 
                        CalculateDivision(firstNumber, secondNumber));
                    break;

                case '^':
                    PublicLogs(firstNumber, secondNumber, mathOperator, 
                        CalculatePower(firstNumber, secondNumber));
                    break;

                default:
                    AddictionalFunctions.EnterIncorrectData();
                    break;
            }
            //add.WaitForEnterButtonPush();
        }
    }
}
