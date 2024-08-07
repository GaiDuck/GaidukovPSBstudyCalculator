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
        List<string> _bracket;

        public InputData()
        {
            _splitedInput = new List<string>();
            _numbers = new List<double>();
            _operators = new List<char>();
            _bracket = new List<string>();
        }

        public int MathOperatorCount { get; private set; }  
        public int OpenBracketNumber { get; private set; }
        public int CloseBracketNumber { get; private set; }
        public bool BracketIsFound { get; private set; }
        public double BracketResult { get; private set; }

        //калькулятор с вводом по действиям

        double GetNumber() //метод, парясящий вводимое пользователем число из строки в числовое значение
        {
            bool parsed;

            do
            {
                parsed = double.TryParse(Console.ReadLine(), out var input);

                if (parsed)
                    return input;
                else
                    AdditionalFunctions.EnterIncorrectData();
            }
            while (!parsed); //будет запрашивать ввод числа пока пользователь не введет корректное значение

            return 0;
        }

        void GetFirstNumber() //метод, записывающий первое число в свойство
        {
            Console.Write("Введите первое число: ");
            FirstNumber = GetNumber();
        }

        void GetSecondNumber() //метод, записывающий второе число в свойство
        {
            Console.Write("Введите второе число: ");
            do
            {
                SecondNumber = GetNumber();
            }
            while (!Validation(MathOperator, FirstNumber, SecondNumber));
        }

        void GetMathOperator() //метод, записывающий математический оператор в свойство
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
                    AdditionalFunctions.EnterIncorrectData();
            }
            while (!mathOperatorFound);
        }

        public void GetDataV1() //комплекс методов, получающих два числа и математический оператор
        {
            GetFirstNumber();
            GetMathOperator();
            GetSecondNumber();
        }

        //калькулятор с вводом строкой

        public void StringInput() //принимает на вход строку и записывает ее по частям в массив строк
        {
            Console.Write("Введите математическое выражение одной строкой, разделяя все числа и математические операции " +
                          "пробелами. Используйте запятую для записи чисел с дробной частью.  \n\n");

            try
            {
                string[] input = Console.ReadLine().Split(' ');

                foreach (string s in input)
                {
                    _splitedInput.Add(s);
                }
            }
            catch
            {
                _splitedInput.Add("0");
            }
        }

        bool SeachForOpenBracket()
        {
            int openBracketNumber = 0;
            bool openBracketIsFound = false;
            foreach (string s in _splitedInput)
            {
                if (s != "(")
                    openBracketNumber++;
                else
                {
                    openBracketIsFound = true;
                    OpenBracketNumber = openBracketNumber;
                    break;
                }
            }
            return openBracketIsFound;
        }

        bool SeachForCloseBracket()
        {
            int closeBracketNumber = 0;
            bool closeBracketIsFound = false;
            foreach (string s in _splitedInput)
            {
                if (s != ")")
                    closeBracketNumber++;
                else
                {
                    closeBracketIsFound = true;
                    CloseBracketNumber = closeBracketNumber;
                    break;
                }
            }
            return closeBracketIsFound;
        }

        void CompliteBracketList(bool bracketIsOpen, bool bracketIsClosed)
        {
            BracketIsFound = false;
            _bracket.Clear();

            if (bracketIsOpen && bracketIsClosed)
            {
                for (int i = OpenBracketNumber + 1; i < CloseBracketNumber; i++)
                {
                    _bracket.Add(_splitedInput[i]);
                }

                BracketIsFound = true;
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

        public void GetBrackets()
        {
            CompliteBracketList(
                SeachForOpenBracket(),
                SeachForCloseBracket());

            CompliteLists(_bracket);
        }

        public void SplitedInputRemoveBracket(double tempResult)
        {
            _splitedInput[OpenBracketNumber] = Convert.ToString(tempResult);
            _splitedInput.RemoveRange(OpenBracketNumber + 1, CloseBracketNumber);
            foreach (var bracket in _splitedInput) { Console.Write(bracket + " "); }
        }

        //калькулятор с вводом строкой с учетом скобок


        //общие методы

        bool Validation(char mathOperator, double firstNumber, double secondNumber)
        {
            if (mathOperator == '/' && secondNumber == 0)
            {
                AdditionalFunctions.EnterIncorrectData();
                return false;
            }
            else if (mathOperator == '^' && firstNumber < 0 && secondNumber > -1 && secondNumber < 1)
            {
                AdditionalFunctions.EnterIncorrectData();
                return false;
            }
            else
                return true;
        }
    }
}
