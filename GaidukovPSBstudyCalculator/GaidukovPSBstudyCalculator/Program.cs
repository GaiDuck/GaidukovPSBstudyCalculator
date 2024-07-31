using GaidukovPSBstudyCalculator;

Calculating calc = new Calculating();
InputData input = new InputData();

AddictionalFunctions.Greeting();
Console.WriteLine("1 - пошаговый, 2 - строкой");

switch (Convert.ToByte(Console.ReadLine()))
{
    case 1:
        CalculatingStepByStep();
    break;

    case 2:  //калькулятор, считающий из строки
        CalculatingByString();
    break;

    default:
        Console.WriteLine("Эта функция находится в разработке.");
    break;
}

void CalculatingStepByStep()  //калькулятор с пошаговым рассчестом
{
    input.GetDataV1();
    calc.Calculate(input.MathOperator, input.FirstNumber, input.SecondNumber);
}

void CalculatingFromString(int i)
{ 
    calc.Calculate(input.MathOperator, input.FirstNumber, input.SecondNumber);
    input.UpdateExpression(calc.TempResult, i); 
}

void CalculatingByString()      //Приоритеты выполнения операций:
{                               //Возведение в степень -> Умножение и деление -> Сложение и вычитание
    input.GetDataV2();

    int i = input.MathOperatorCount - 1;
    Console.WriteLine($"Найдено {i + 1} математических операций.");

    for (int a = i; a > -1; a--) //цикл для вычисления степеней
    {
        input.SetNumbersByMathoperator(a);
        if (input.MathOperator == '^')
        {
            CalculatingFromString(a);
            i--;
        }
    }

    for (int b = i; b > -1; b--) //цикл для вычисления умножений и делений
    {
        input.SetNumbersByMathoperator(b);
        if (input.MathOperator == '*' || input.MathOperator == '/')
        {
            CalculatingFromString(b);
            i--;
        }
    }

    for (int c = i; c > -1; c--) //цикл для вычисления сложений и вычитаний
    {
        input.SetNumbersByMathoperator(c);
        if (input.MathOperator == '+' || input.MathOperator == '-')
        {
            CalculatingFromString(c);
            i--;
        }
    }
}


