using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GaidukovPSBstudyCalculator
{
    internal class InputData
    {
        public double FirstNumber { get; private set; }
        public double SecondNumber { get; private set; }
        public char MathOperator { get; private set; }

        private static char[] mathOperators = { '+', '-', '*', '/', '^', '(', ')' }; //при попытке сделать const выбрасывает две ошибки

        List<string> _splitedInput;
        List<double> _numbers;
        List<char> _operators;

        public InputData()
        {
            _splitedInput = new List<string>();
            _numbers = new List<double>();
            _operators = new List<char>();
        }

        public int MathOperatorCount { get; private set; }  

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
                    AddictionalFunctions.EnterIncorrectData();
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
            while (!Validation(MathOperator, FirstNumber, SecondNumber));
        }

        void GetMathOperator()
        {
            Console.Write("Введите символ операции: ");

            bool mathOperatorFound = false;

            do
            {
                bool parsed = char.TryParse(Console.ReadLine(), out var input);

                if (parsed)
                {
                    if(mathOperators.Contains(input))
                    {
                        MathOperator = input;
                        mathOperatorFound = true;
                    }
                }

                if (!(mathOperatorFound && parsed))
                    AddictionalFunctions.EnterIncorrectData();
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

        public void StringInput()
        {
            Console.Write("Введите математическое выражение одной строкой, разделяя все числа и математические операции " +
                          "пробелами. Используйте запятую для записи чисел с дробной частью.\n\n");
            
            string[] input = Console.ReadLine().Split(' ');

            if (input == null)
                _splitedInput.Add("0");
            else
            {
                foreach (string s in input) 
                { 
                    _splitedInput.Add(s);
                } 
            }
        }

        void CompliteLists(List<string> SplitedInput)
        {
            foreach (string simbol in SplitedInput)
            {
                bool parced = double.TryParse(simbol, out var result);

                if (parced)
                    _numbers.Add(result);
                else
                    _operators.Add(Convert.ToChar(simbol));
            }
            MathOperatorCount = _operators.Count;
        }

        public void SetNumbersByMathoperator(int mathOperatorNumber)
        {
            FirstNumber = _numbers[mathOperatorNumber];
            SecondNumber = _numbers[mathOperatorNumber + 1];
            MathOperator = _operators[mathOperatorNumber];
        }

        public void UpdateExpression(double tempResult, int mathOperatorNumber)
        {
            _numbers[mathOperatorNumber] = tempResult;
            _numbers.RemoveAt(mathOperatorNumber+1);
            _operators.RemoveAt(mathOperatorNumber);
        }

        public void GetDataV2()
        {
            StringInput();
            CompliteLists(_splitedInput);
        }

        //общие методы

        bool Validation(char mathOperator, double firstNumber, double secondNumber)
        {
            if (mathOperator == '/' && secondNumber == 0)
            {
                AddictionalFunctions.EnterIncorrectData();
                return false;
            }
            else if (mathOperator == '^' && firstNumber < 0 && secondNumber > -1 && secondNumber < 1)
            {
                AddictionalFunctions.EnterIncorrectData();
                return false;
            }
            else
                return true;
        }
    }
}
